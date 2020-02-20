using SNTN3_Forms.PictureEdit;
using System.Drawing;
using System.Windows.Forms;

namespace SNTN3_Forms
{
    public partial class EditPreviewPB : PictureBox
    {
        public EditPreviewPB()
        {
            this.Size = BasicSize;
            InitializeComponent();
            IsImageFlipped = false;
        }

        private bool IsImageFlipped { get; set; }
        private PictureEditParams _picEditParams;
        public PictureEditParams PicEditParams
        {
            get => _picEditParams;
            set
            {
                _picEditParams = value;

                if (_picEditParams is null)
                {
                    return;
                }
                if ((PicEditParams.IsFlipped) && !IsImageFlipped)
                {
                    this.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    IsImageFlipped = true;
                }

                if ((!PicEditParams.IsFlipped) && IsImageFlipped)
                {
                    this.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    IsImageFlipped = false;
                }

                Invalidate();
            }
        }

        public void SetImage(string pathToImage)
        {
            IsImageFlipped = false;
            if (pathToImage == null)
            {
                Image = null;
            }
            else
            {
                Bitmap orig = new Bitmap(pathToImage);
                Image = new Bitmap(orig, AdjustImageSize(orig.Size, BasicSize));
                orig.Dispose();
                this.Size = Image.Size;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Image != null)
            {
                Rectangle wholePictureRectangle = new Rectangle(new Point(0, 0), this.Size);

                if (PicEditParams.Tone.HasValue)
                {
                    pe.Graphics.FillRectangle(new SolidBrush(PicEditParams.Tone.Value.Color), wholePictureRectangle);
                }

                if (PicEditParams.Brightness.HasValue)
                {
                    pe.Graphics.FillRectangle(new SolidBrush(PicEditParams.Brightness.Value.Color), wholePictureRectangle);
                }

                if (PicEditParams.Frames.HasValue)
                {
                    pe.Graphics.DrawRectangle(new Pen(Color.White, (this.Width / 2f) * (PicEditParams.Frames.Value.Size / 100f)), wholePictureRectangle);
                }
            }
        }

        #region Size Related

        private readonly Size BasicSize = new Size(200, 200);

        public static Size AdjustImageSize(Size imageSize, Size controlSize)
        {
            double ratio = imageSize.Width / (double)imageSize.Height;

            //if pic is horizontal
            if (ratio > 1)
            {
                int newWidth = controlSize.Width;
                int newHeight = (int)(controlSize.Height / ratio);
                return new Size(newWidth, newHeight);
            }
            else
            //if pic is vertical
            if (ratio < 1)
            {
                int newHeight = controlSize.Height;
                int newWidth = (int)(controlSize.Width * ratio);
                return new Size(newWidth, newHeight);
            }
            else
            //if pic is square
            {
                return controlSize;
            }
        }

        #endregion
    }
}