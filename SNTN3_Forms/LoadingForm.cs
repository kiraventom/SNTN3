using SNTN3_Forms.PictureEdit;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;

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
        }

        private VkApi Api { get; }
        private DateTime[] DateTimes { get; }
        private long GroupId { get; }
        private string[] PathsToPictures { get; }
        private PictureEditParams[] PictureEditParams { get; }

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
            await StartPosting(dateTimePr);
        }

        private async Task StartPosting(IProgress<DateTime> dateTimePr)
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
                catch
                {
                    MessageBox.Show("Произошла ошибка, связанная с ВК!");
                    continue;
                }
            }

            var dr = MessageBox.Show("Все фото загружены. Удалить их?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (var path in PathsToPictures)
                {
                    System.IO.File.Delete(path);
                }
            }

            Close();
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
