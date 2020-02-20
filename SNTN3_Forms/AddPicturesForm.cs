using SNTN3_Forms.PictureEdit;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VkNet;

namespace SNTN3_Forms
{
    public partial class AddPicturesForm : Form
    {
        public AddPicturesForm(VkApi api)
        {
            InitializeComponent();
            _api = api;
            if (_api.IsAuthorized)
            {
                var acc = _api.Users.Get(new long[] { })[0];
                AccountNameL.Text = acc.FirstName + " " + acc.LastName;
            }
            PathsToPictures = new ObservableCollection<string>();
            PathsToPictures.CollectionChanged += PathsToPictures_CollectionChanged;
            DialogResult = DialogResult.Cancel;
        }

        #region Свойства

        private VkApi _api { get; }
        private ObservableCollection<string> PathsToPictures { get; set; }
        private readonly string[] AllowedExtensions = { "*.jpg", "*.jpeg", "*.png", "*.jfif", "*.gif" };

        private Bitmap _deleteIcon;
        private Bitmap DeleteIcon 
        {
            get
            {
                if (_deleteIcon is null)
                {
                    _deleteIcon = new Bitmap(200, 140);
                    using (Graphics g = Graphics.FromImage(_deleteIcon))
                    {
                        g.FillRectangle(
                            new SolidBrush(Color.FromArgb(128, 255, 255, 255)),
                            new Rectangle(new Point(0, 0), _deleteIcon.Size));
                        g.DrawImage(
                            Properties.Resources.RemovePictureIcon,
                            new Rectangle(
                                new Point(
                                    (_deleteIcon.Width / 2) - (Properties.Resources.RemovePictureIcon.Width / 2),
                                    (_deleteIcon.Height / 2) - (Properties.Resources.RemovePictureIcon.Height / 2)),
                                Properties.Resources.RemovePictureIcon.Size));
                    }
                }
                return _deleteIcon;
            } 
        }

        #endregion

        #region Обработчики событий

        private void AddImagesBt_Click(object sender, EventArgs e)
        {
            string[] paths;
            var ofd = new OpenFileDialog()
            {
                Filter = $"Изображения|{string.Join(";", AllowedExtensions)}",
                Multiselect = true,
                Title = "Выберите изображения"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                paths = ofd.FileNames;
                foreach (var path in paths)
                {
                    PathsToPictures.Add(path);
                }
            }
        }

        private void AddFolderBt_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var directoryInfo = new DirectoryInfo(fbd.SelectedPath);
                FileInfo[] filesInfo = directoryInfo.GetFiles();

                foreach (var fileInfo in filesInfo)
                {
                    if (AllowedExtensions.Any(ext => fileInfo.Extension == ext.Substring(1)))
                    {
                        PathsToPictures.Add(fileInfo.FullName);
                    }
                }
            }
        }

        private void PathsToPictures_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (string pathToNewPicture in e.NewItems)
                {
                    Bitmap orig = new Bitmap(pathToNewPicture);
                    Size btSize = new Size(200, 140);
                    var adjustedSize = PictureEditParams.AdjustImageSizeToControlSize(orig.Size, btSize);
                    Bitmap thumb = new Bitmap(orig, adjustedSize);
                    orig.Dispose();
                    Button pictureBt = new Button()
                    {
                        Text = string.Empty,
                        BackgroundImage = thumb,
                        BackgroundImageLayout = ImageLayout.Zoom,
                        Size = btSize,
                        Tag = pathToNewPicture
                    };
                    pictureBt.Click += (s, ea) =>
                    {
                        var dr = MessageBox.Show("Убрать картинку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            PathsToPictures.Remove(pictureBt.Tag.ToString());
                        }
                    };
                    pictureBt.MouseEnter += (s, ea) =>
                    {
                        pictureBt.Image = DeleteIcon;
                    };
                    pictureBt.MouseLeave += (s, ea) =>
                    {
                        pictureBt.Image = null;
                    };
                    PicturesFLP.Controls.Add(pictureBt);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (string pathToOldPicture in e.OldItems)
                {
                    var button = PicturesFLP.Controls.OfType<Button>().Single(bt => bt.Tag.ToString() == pathToOldPicture);
                    button.BackgroundImage.Dispose();
                    PicturesFLP.Controls.Remove(button);
                }
            }
        }

        private void PrevStepBt_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                        "Выйти из аккаунта? Все добавленные картинки будут утеряны!",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
                foreach (Button bt in PicturesFLP.Controls)
                {
                    bt.BackgroundImage.Dispose();
                }
                Close();
            }
        }

        private void NextStepBt_Click(object sender, EventArgs e)
        {
            if (PathsToPictures.Count == 0)
            {
                return;
            }

            Hide();
            /* Раньше я хранил в BackgroundImage оригинальную картинку, поэтому
             * необходимо было ее диспоузить, чтобы при переходе на другую форму
             * освобождалась память. Позже я сделал так, что в BackgroundImage
             * хранится уменьшенная версия картинки (thumbnail), поэтому надобности
             * в этом коде больше нет, так как влияние на память незначительное. */

            //foreach (Button bt in PicturesFLP.Controls)
            //{
            //    bt.BackgroundImage.Dispose();
            //}

            var editPicsForm = new EditPicturesForm(_api, PathsToPictures.ToArray());
            editPicsForm.ShowDialog();
            if (editPicsForm.DialogResult == DialogResult.No)
            {
                //for (int i = 0; i < PicturesFLP.Controls.Count; ++i)
                //{
                //    Button bt = (Button)PicturesFLP.Controls[i];
                //    Bitmap orig = new Bitmap(PathsToPictures[i]);
                //    var adjustedSize = PictureEditParams.AdjustImageSizeToControlSize(orig.Size, bt.Size);
                //    Bitmap thumb = new Bitmap(orig, adjustedSize);
                //    orig.Dispose();
                //    bt.BackgroundImage = thumb;
                //}
                Show();
            }
            else
            {
                Close();
            }
        }

        #endregion
    }
}
