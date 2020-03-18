using SNTN3_Forms.PictureEdit;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SNTN3_Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm(VkApi api, DateTime[] dateTimes, long groupId, string[] pathsToPictures, PictureEditParams[] pictureEditParams)
        {
            InitializeComponent();
            Api = api;
            DateTimes = dateTimes;
            GroupId = groupId;
            PathsToPictures = pathsToPictures;
            PictureEditParams = pictureEditParams;
            CurrentPostDateTime = new DateTime(9999, 12, 31, 23, 59, 59);
            MainPBr.Maximum = dateTimes.Length;

            List<bool?> list = new List<bool?>();
            for (int i = 0; i < PathsToPictures.Length; ++i)
            {
                list.Add(null);
            }
            PicsLoadedCorrectly = list.ToArray();
        }

        private VkApi Api { get; }
        private DateTime[] DateTimes { get; }
        private long GroupId { get; }
        private string[] PathsToPictures { get; }
        private PictureEditParams[] PictureEditParams { get; }
        private bool?[] PicsLoadedCorrectly { get; }

        private DateTime _currentPostDateTime;
        private DateTime CurrentPostDateTime
        {
            get => _currentPostDateTime;
            set
            {
                _currentPostDateTime = value;
                MainPBr.Increment(1);
                DetailsL.Text = $"Пост на {_currentPostDateTime.ToLongDateString()} в {_currentPostDateTime.ToLongTimeString()}";
            }
        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {
            var dateTimePr = new Progress<DateTime>(i => CurrentPostDateTime = i );
            var result = await StartPosting(dateTimePr);
            if (result)
            {
                DialogResult = DialogResult.Yes;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
            Close();
        }

        private async Task<bool> StartPosting(IProgress<DateTime> dateTimePr)
        {
            var uploadServerInfo = Api.Photo.GetWallUploadServer(GroupId);
            for (int i = 0; i < DateTimes.Length; ++i)
            {
                string pathToPicture = PathsToPictures[i];
                var picEditParams = PictureEditParams[i];
                DateTime dateTime = DateTimes[i];

                dateTimePr.Report(dateTime);

                Bitmap picture = new Bitmap(pathToPicture);
                picture = PictureEdit.PictureEditParams.Edit(picture, picEditParams);
                byte[] pictureBytes = ToByteArray(picture);
                picture.Dispose();

                try
                {
                    var response = await UploadImage(uploadServerInfo.UploadUrl, pictureBytes);
                    var wallPhoto = Api.Photo.SaveWallPhoto(response, null, (ulong)GroupId);

                    Api.Wall.Post(new VkNet.Model.RequestParams.WallPostParams
                    {
                        OwnerId = - GroupId,
                        FromGroup = true,
                        PublishDate = dateTime,
                        Attachments = wallPhoto
                    });
                }
                catch (VkNet.Exception.ParameterMissingOrInvalidException e)
                {
                    if (e.Message.Contains("publish_date"))
                    {
                        MessageBox.Show("Неверная дата! Повторите попытку.");
                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла ошибка на стороне ВК!\n" + e.Message);
                    PicsLoadedCorrectly[i] = false;
                    continue;
                }
                PicsLoadedCorrectly[i] = true;
            }

            StringBuilder messageBuilder = new StringBuilder();
            if (PicsLoadedCorrectly.Any(p => !p.Value))
            {
                messageBuilder.Append("Не загруженные фото: ");
                for (int j = 0; j < PicsLoadedCorrectly.Length; ++j)
                {
                    if (!PicsLoadedCorrectly[j].Value)
                    {
                        messageBuilder.Append(Path.GetFileName(PathsToPictures[j]));
                    }
                    if (j != PicsLoadedCorrectly.Length - 1)
                    {
                        messageBuilder.Append(",");
                    }
                    messageBuilder.Append(" ");
                }
            }
            else
            {
                messageBuilder.Append("Все фото успешно загружены!");
            }
            messageBuilder.Append("\nУдалить загруженные фото?");
            var dr = MessageBox.Show(messageBuilder.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int i = 0; i < PathsToPictures.Length; i++)
                {
                    if (PicsLoadedCorrectly[i].Value)
                    {
                        System.IO.File.Delete(PathsToPictures[i]);
                    }
                }
            }

            return true;
        }

        public static byte[] ToByteArray (Bitmap image)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        private async Task<string> UploadImage(string url, byte[] data)
        {
            using (var client = new HttpClient())
            {
                var requestContent = new MultipartFormDataContent();
                var imageContent = new ByteArrayContent(data);
                imageContent.Headers.ContentType =
                    System.Net.Http.Headers.MediaTypeHeaderValue.Parse("image/jpeg");
                requestContent.Add(imageContent, "photo", "image.jpg");

                var response = await client.PostAsync(url, requestContent);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
