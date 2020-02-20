using SNTN3_Forms.PictureEdit;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VkNet;

namespace SNTN3_Forms
{
    public partial class EditPicturesForm : Form
    {
        public EditPicturesForm(VkApi api, string[] pathsToPictures)
        {
            InitializeComponent();
            Api = api;
            PathsToPictures = pathsToPictures;
            EditParams = new ObservableCollection<PictureEditParams>();
            EditParams.CollectionChanged += EditParams_CollectionChanged;
            for (int i = 0; i < pathsToPictures.Length; ++i)
            {
                EditParams.Add(PictureEditParams.GetRandomParams());
            }
        }

        #region Поля и свойства

        private VkApi Api { get; }
        public string[] PathsToPictures { get; }
         /// <summary>
         /// Коллекция параметров, с которыми должны быть отредактированы изображения. 
         /// Методы этой коллекции необходимо использовать для применения изменений к изображениям.
         /// </summary>
        private ObservableCollection<PictureEditParams> EditParams { get; } 

        private readonly Color UnselectedBtColor = Color.LightGray;
        private readonly Color SelectedBtColor = Color.DarkSlateBlue;
        private readonly Size BtSize = new Size(200, 200);

        private PictureEditParams _currentEditParams = new PictureEditParams();
        /// <summary>
        /// Свойство, хранящее данные о настройках, которые пользователь меняет в данный момент для выбранной картинки.
        /// Используется для превью, чтобы пользователь в прямом эфире мог видеть применяемые изменения.
        /// </summary>
        private PictureEditParams CurrentEditParams
        {
            get => _currentEditParams;
            set
            {
                _currentEditParams = value;
                editPreviewPB1.PicEditParams = CurrentEditParams;
            }
        }

        private string _pathToCurrentPicture;
        /// <summary>
        /// Путь к выделенному изображению. Используется для превью.
        /// </summary>
        private string PathToCurrentPicture
        {
            get => _pathToCurrentPicture;
            set
            {
                _pathToCurrentPicture = value;
                editPreviewPB1.SetImage(value);
            }
        }

        private int _selectedPictureIndex = -1;
        /// <summary>
        /// Свойство, хранящее индекс выделенной в данный момент картинки. При его изменении выбранные изменения сохраняются. 
        /// Значение -1 отвечает за отсутствие выделения.
        /// </summary>
        private int SelectedPictureIndex
        {
            get => _selectedPictureIndex;
            set
            {
                if (_selectedPictureIndex >= 0)
                {
                    EditParams[_selectedPictureIndex] = CurrentEditParams; // saving params
                    var previouslySelectedBt = 
                        PicturesFLP.Controls.OfType<Button>().Single(b => (int)b.Tag == _selectedPictureIndex);
                    previouslySelectedBt.BackColor = UnselectedBtColor;
                }

                _selectedPictureIndex = value;

                if (_selectedPictureIndex >= 0)
                {
                    var selectedBt = 
                        PicturesFLP.Controls.OfType<Button>().Single(b => (int)b.Tag == _selectedPictureIndex);
                    selectedBt.BackColor = SelectedBtColor;

                    EditGB.Enabled = true;
                    PathToCurrentPicture = PathsToPictures[_selectedPictureIndex];
                    CurrentEditParams = EditParams[_selectedPictureIndex];

                    CurrentParamsToControls();
                }
                else
                {
                    PathToCurrentPicture = null;
                    CurrentEditParams = null;
                    CurrentParamsToControls();
                    EditGB.Enabled = false;
                }
            }
        }

        #endregion

        #region Обработчики событий

        #region Обработчики событий коллекций

        private void EditParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                for (int i = 0; i < e.NewItems.Count; ++i)
                {
                    PictureEditParams editParams = (PictureEditParams)e.NewItems[i]; 
                    int originalCollectionIndex = EditParams.IndexOf(editParams);

                    Bitmap orig = new Bitmap(PathsToPictures[originalCollectionIndex]); 
                    Size btSize = BtSize;
                    var adjustedSize = PictureEditParams.AdjustImageSizeToControlSize(orig.Size, btSize);
                    Bitmap thumb = new Bitmap(orig, adjustedSize);
                    orig.Dispose(); 
                    Button pictureBt = new Button()
                    {
                        Text = string.Empty,
                        BackgroundImage = PictureEditParams.Edit(thumb, editParams),
                        BackgroundImageLayout = ImageLayout.Zoom,
                        Size = btSize,
                        BackColor = UnselectedBtColor,
                        Tag = EditParams.IndexOf(editParams)
                    };
                    pictureBt.Click += (s, ea) =>
                    {
                        SelectedPictureIndex = (int)pictureBt.Tag;
                    };
                    PicturesFLP.Controls.Add(pictureBt);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                for (int i = 0; i < e.NewItems.Count; ++i)
                {
                    PictureEditParams editParams = (PictureEditParams)e.NewItems[i];
                    int originalCollectionIndex = EditParams.IndexOf(editParams);
                    var buttonToReplace = PicturesFLP.Controls.OfType<Button>().Single(b => (int)b.Tag == originalCollectionIndex);

                    Bitmap orig = new Bitmap(PathsToPictures[originalCollectionIndex]);
                    var adjustedSize = PictureEditParams.AdjustImageSizeToControlSize(orig.Size, buttonToReplace.Size);
                    Bitmap thumb = new Bitmap(orig, adjustedSize);
                    orig.Dispose();
                    buttonToReplace.BackgroundImage = PictureEditParams.Edit(thumb, editParams);
                }
            }
        }

        #endregion

        #region Обработчики событий контролов

        #region Flip

        private void FlipCB_Click(object sender, EventArgs e)
        {
            bool isFlipped;
            if (FlipCB.Checked)
            {
                isFlipped = true;
            }
            else
            {
                isFlipped = false;
            }

            CurrentEditParams = new PictureEditParams(
                    isFlipped,
                    CurrentEditParams.Tone,
                    CurrentEditParams.Brightness,
                    CurrentEditParams.Frames);
        }

        #endregion

        #region Tone

        private void ToneCB_Click(object sender, EventArgs e)
        {
            Tone? tone;
            if (ToneCB.Checked)
            {
                tone = new Tone(ToneColorBt.BackColor, ToneTBr.Value);
            }
            else
            {
                tone = null;
            }

            CurrentEditParams = new PictureEditParams(
                    CurrentEditParams.IsFlipped,
                    tone,
                    CurrentEditParams.Brightness,
                    CurrentEditParams.Frames);
        }

        private void ToneColorBt_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog()
            {
                AllowFullOpen = true,
                AnyColor = true,
                Color = ToneColorBt.BackColor
            };
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ToneColorBt.BackColor = colorDialog.Color;
                CurrentEditParams = new PictureEditParams(
                    CurrentEditParams.IsFlipped, 
                    new Tone(ToneColorBt.BackColor, ToneTBr.Value),
                    CurrentEditParams.Brightness,
                    CurrentEditParams.Frames);
            }
        }

        private void ToneCB_CheckedChanged(object sender, EventArgs e)
        {
            ToneColorBt.Enabled = ToneCB.Checked;
            ToneTBr.Enabled = ToneCB.Checked;
        }

        private void ToneTBr_Scroll(object sender, EventArgs e)
        {
            CurrentEditParams = new PictureEditParams(
                CurrentEditParams.IsFlipped,
                new Tone(ToneColorBt.BackColor, ToneTBr.Value),
                CurrentEditParams.Brightness,
                CurrentEditParams.Frames);
        }

        #endregion

        #region Brightness

        private void BrightnessCB_Click(object sender, EventArgs e)
        {
            Brightness? br;
            if (BrightnessCB.Checked)
            {
                br = new Brightness(BrightnessColorBt.BackColor, BrightnessTBr.Value);
            }
            else
            {
                br = null;
            }

            CurrentEditParams = new PictureEditParams(
                    CurrentEditParams.IsFlipped,
                    CurrentEditParams.Tone,
                    br,
                    CurrentEditParams.Frames);
        }

        private void BrightnessCB_CheckedChanged(object sender, EventArgs e)
        {
            BrightnessColorBt.Enabled = BrightnessCB.Checked;
            BrightnessTBr.Enabled = BrightnessCB.Checked;
        }

        private void BrightnessColorBt_Click(object sender, EventArgs e)
        {
            // По какой-то причине задание цвета по названию не работает
            //if (BrightnessColorBt.BackColor == Color.White) 
            if (BrightnessColorBt.BackColor == Color.FromArgb(255, 255, 255, 255))
            {
                BrightnessColorBt.BackColor = Color.FromArgb(255, 0, 0, 0);
            }
            else
            {
                BrightnessColorBt.BackColor = Color.FromArgb(255, 255, 255, 255);
            }
            CurrentEditParams = new PictureEditParams(
                CurrentEditParams.IsFlipped,
                CurrentEditParams.Tone, 
                new Brightness(BrightnessColorBt.BackColor, BrightnessTBr.Value),
                CurrentEditParams.Frames);
        }

        private void BrightnessTBr_Scroll(object sender, EventArgs e)
        {
            CurrentEditParams = new PictureEditParams(
                CurrentEditParams.IsFlipped,
                CurrentEditParams.Tone,
                new Brightness(BrightnessColorBt.BackColor, BrightnessTBr.Value),
                CurrentEditParams.Frames);
        }

        #endregion

        #region Frames

        private void FramesCB_Click(object sender, EventArgs e)
        {
            Frames? frames;
            if (FramesCB.Checked)
            {
                frames = new Frames(FramesTBr.Value);
            }
            else
            {
                frames = null;
            }

            CurrentEditParams = new PictureEditParams(
                    CurrentEditParams.IsFlipped,
                    CurrentEditParams.Tone,
                    CurrentEditParams.Brightness,
                    frames);
        }

        private void FramesCB_CheckedChanged(object sender, EventArgs e)
        {
            FramesTBr.Enabled = FramesCB.Checked;
        }

        private void FramesTBr_Scroll(object sender, EventArgs e)
        {
            CurrentEditParams = new PictureEditParams(
                CurrentEditParams.IsFlipped,
                CurrentEditParams.Tone,
                CurrentEditParams.Brightness,
                new Frames(FramesTBr.Value));
        }

        #endregion

        private void RegenerateEditParamsBt_Click(object sender, EventArgs e)
        {
            SelectedPictureIndex = -1;
            for (int i  = 0; i < EditParams.Count; ++i)
            {
                EditParams[i] = PictureEditParams.GetRandomParams();
            }
        }

        private void PrevStepBt_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                        "Вернуться к добавлению картинок? Все изменения будут утеряны!",
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
                if (editPreviewPB1.Image != null)
                {
                    editPreviewPB1.Image.Dispose();
                }
                Close();
            }
        }

        private void NextStepBt_Click(object sender, EventArgs e)
        {
            if (PathsToPictures.Count() == 0)
            {
                return;
            }

            Hide();

            var postingForm = new PostingForm(Api, PathsToPictures, EditParams.ToArray());
            postingForm.ShowDialog();
            if (postingForm.DialogResult == DialogResult.No)
            {
                Show();
            }
            else
            {
                Close();
            }
        }

        private void PicturesFLP_Click(object sender, EventArgs e)
        {
            SelectedPictureIndex = -1;
        }

        private void SettingsBt_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        #endregion

        #endregion

        #region Методы

        /// <summary>
        /// Переносит параметры из CurrentEditParams на контролы панели редактирования.
        /// </summary>
        private void CurrentParamsToControls()
        {
            if (CurrentEditParams is null)
            {
                FlipCB.Checked = false;
                ToneCB.Checked = false;
                ToneColorBt.BackColor = Color.White;
                ToneTBr.Value = ToneTBr.Minimum;
                BrightnessCB.Checked = false;
                BrightnessColorBt.BackColor = Color.FromArgb(255, 255, 255, 255);
                BrightnessTBr.Value = BrightnessTBr.Minimum;
                FramesCB.Checked = false;
                FramesTBr.Value = FramesTBr.Minimum;
                return;
            }
            FlipCB.Checked = CurrentEditParams.IsFlipped;

            ToneCB.Checked = CurrentEditParams.Tone.HasValue;
            if (CurrentEditParams.Tone.HasValue)
            {
                ToneColorBt.BackColor = Color.FromArgb(
                    255,
                    CurrentEditParams.Tone.Value.Color.R,
                    CurrentEditParams.Tone.Value.Color.G,
                    CurrentEditParams.Tone.Value.Color.B);
                ToneTBr.Value = CurrentEditParams.Tone.Value.Color.A;
            }

            BrightnessCB.Checked = CurrentEditParams.Brightness.HasValue;
            if (CurrentEditParams.Brightness.HasValue)
            {
                BrightnessColorBt.BackColor = Color.FromArgb(
                    255, 
                    CurrentEditParams.Brightness.Value.Color.R,
                    CurrentEditParams.Brightness.Value.Color.G,
                    CurrentEditParams.Brightness.Value.Color.B);
                BrightnessTBr.Value = CurrentEditParams.Brightness.Value.Color.A;
            }

            FramesCB.Checked = CurrentEditParams.Frames.HasValue;
            if (CurrentEditParams.Frames.HasValue)
            {
                FramesTBr.Value = CurrentEditParams.Frames.Value.Size;
            }
        }

        #endregion
    }
}
