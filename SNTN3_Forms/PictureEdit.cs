using System;
using System.Drawing;

namespace SNTN3_Forms.PictureEdit
{
    public class PictureEditParams
    {
        public PictureEditParams()
        {
            IsFlipped = false;
            Tone = null;
            Brightness = null;
            Frames = null;
        }

        public bool IsFlipped { get; set; }
        public Tone? Tone { get; set; }
        public Brightness? Brightness { get; set; }
        public Frames? Frames { get; set; }
        private static Random Random { get; } = new Random();

        public PictureEditParams(bool isFlipped, Tone? tone, Brightness? brightness, Frames? frames)
        {
            IsFlipped = isFlipped;
            Tone = tone;
            Brightness = brightness;
            Frames = frames;
        }

        public static PictureEditParams GetRandomParams()
        {
            bool isFlipped = true;
            Tone tone = new Tone(color: Color.FromArgb(Random.Next(255), Random.Next(255), Random.Next(255)),
                                 opacity: Random.Next(Properties.Settings.Default.ToneBottomLimit,
                                                      Properties.Settings.Default.ToneUpLimit));
            Brightness br = new Brightness(color: (Random.Next(2) == 1 ? Color.White : Color.Black),
                                           opacity: Random.Next(Properties.Settings.Default.BrightnessBottomLimit,
                                                                Properties.Settings.Default.BrightnessUpLimit));
            Frames frames = new Frames(size: Random.Next(Properties.Settings.Default.FramesBottomLimit,
                                                         Properties.Settings.Default.FramesUpLimit));
            return new PictureEditParams(isFlipped, tone, br, frames);
        }

        public static Size AdjustImageSizeToSquareControl(Size imageSize, Size controlSize)
        {
            double ratio = imageSize.Width / (double)imageSize.Height;

            //if pic is horizontal
            if (ratio > 1)
            {
                int newWidth = controlSize.Width;
                int newHeight = (int)(imageSize.Height * (newWidth / (double)imageSize.Width));
                return new Size(newWidth, newHeight);
            }
            else
            //if pic is vertical
            if (ratio < 1)
            {
                int newHeight = controlSize.Height;
                int newWidth = (int)(imageSize.Width * (newHeight / (double)imageSize.Height));
                return new Size(newWidth, newHeight);
            }
            else
            //if pic is square
            {
                return controlSize;
            }
        }

        public static Bitmap Edit(Bitmap picture, PictureEditParams editParams)
        {
            Rectangle wholePictureRectangle = new Rectangle(new Point(0, 0), picture.Size);
            if (editParams.IsFlipped)
            {
                picture.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            using (Graphics g = Graphics.FromImage(picture))
            {
                if (editParams.Tone.HasValue)
                {
                    g.FillRectangle(new SolidBrush(editParams.Tone.Value.Color), wholePictureRectangle);
                }
                if (editParams.Brightness.HasValue)
                {
                    g.FillRectangle(new SolidBrush(editParams.Brightness.Value.Color), wholePictureRectangle);
                }
                if (editParams.Frames.HasValue)
                {
                    g.DrawRectangle(new Pen(Color.White, (picture.Width / 2f) * (editParams.Frames.Value.Size / 100f)), wholePictureRectangle);
                }
            }
            return picture;
        }
    }

    public struct Tone
    {
        public Tone (Color color, int opacity)
        {
            Color = Color.FromArgb(opacity, color);
        }

        public Color Color { get; }

        public override bool Equals(object obj)
        {
            if (obj is Tone)
            {
                return this.Color.Equals(((Tone)obj).Color);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        public static bool operator ==(Tone left, Tone right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Tone left, Tone right)
        {
            return !(left == right);
        }
    }

    public struct Brightness
    {
        public Brightness(Color color, int opacity)
        {
            Color = Color.FromArgb(opacity, color);
        }

        public Color Color { get; }

        public override bool Equals(object obj)
        {
            if (obj is Brightness)
            {
                return this.Color.Equals(((Brightness)obj).Color);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        public static bool operator ==(Brightness left, Brightness right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Brightness left, Brightness right)
        {
            return !(left == right);
        }
    }

    public struct Frames
    {
        public Frames(int size)
        {
            Size = size;
        }

        public int Size { get; }

        public override bool Equals(object obj)
        {
            if (obj is Frames)
            {
                return this.Size.Equals(((Frames)obj).Size);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Size.GetHashCode();
        }

        public static bool operator ==(Frames left, Frames right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Frames left, Frames right)
        {
            return !(left == right);
        }
    }
}
