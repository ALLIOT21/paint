using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        float angle = 0;
        Image img;
        Image baseImg;
        float brightness;
        int width, height;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int newWidth = 0;
            int newHeight = 0;

            Bitmap bmp = new Bitmap(width, height);

            if (angle > 0 && angle <= 90)
            {
                newWidth = (int)(bmp.Width * Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > 90 && angle <= 180)
            {
                newWidth = (int)(bmp.Width * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > 180 && angle <= 270)
            {
                newWidth = (int)(bmp.Width * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * -Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * -Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > 270 && angle <= 360)
            {
                newWidth = (int)(bmp.Width * Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * -Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * -Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > -90 && angle <= 0)
            {
                newWidth = (int)(bmp.Width * Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * -Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * -Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > -180 && angle <= -90)
            {
                newWidth = (int)(bmp.Width * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * -Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * -Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > -270 && angle <= -180)
            {
                newWidth = (int)(bmp.Width * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * -Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * Math.Sin(2 * Math.PI * angle / 360));
            }
            else if (angle > -360 && angle <= -270)
            {
                newWidth = (int)(bmp.Width * Math.Cos(2 * Math.PI * angle / 360) + bmp.Height * Math.Sin(2 * Math.PI * angle / 360));
                newHeight = (int)(bmp.Height * Math.Cos(2 * Math.PI * angle / 360) + bmp.Width * Math.Sin(2 * Math.PI * angle / 360));
            }


            Bitmap bm = new Bitmap(baseImg.Width, baseImg.Height);
            Graphics gfx = Graphics.FromImage(bm);
            gfx.TranslateTransform(newWidth / 2, newHeight / 2);
            gfx.RotateTransform(angle);
            gfx.TranslateTransform(-newWidth / 2, -newWidth / 2);
            gfx.DrawImage(img, 0, 0);
            gfx.InterpolationMode = InterpolationMode.Default;
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.DrawImage(bm, -bmp.Width / 2, -bmp.Height / 2, bmp.Width, bmp.Height);


            this.Text = GC.GetTotalMemory(false).ToString() + " width:" + width + " height:" + height; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            img = Image.FromFile("C:\\Users\\ASUS\\Pictures\\2.jpg");
            baseImg = (Image)img.Clone();
            FindOptimalSize(baseImg, out width, out height);
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            brightness = trackBarBrightness.Value;

            Bitmap bmp = new Bitmap(baseImg);
            Bitmap res = new Bitmap(img.Width, img.Height);
            float factor = brightness / 100;
            for (int x = 0; x < bmp.Width; ++x)
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Color curr = bmp.GetPixel(x, y);
                    Color next = Color.FromArgb((byte)(factor * curr.R), (byte)(factor * curr.G), (byte)(factor * curr.B));
                    res.SetPixel(x, y, next);

                    img = res;
                }
            Invalidate();
        }

        private void buttonTurnLeft_Click(object sender, EventArgs e)
        {
            TurnPicture(buttonTurnLeft);
        }

        private void buttonTurnRight_Click(object sender, EventArgs e)
        {
            TurnPicture(buttonTurnRight);
        }

        private void TurnPicture(Button b)
        {
            if (b == buttonTurnLeft)
            {
                angle = angle - GetAngleFromTextBox(textBoxAngle);
            }
            else
                angle = angle + GetAngleFromTextBox(textBoxAngle);
            angle %= 360;
            Invalidate();
        }

        private int GetAngleFromTextBox(TextBox textbox)
        {
            int result;
            try
            {
                result = int.Parse(textbox.Text);
                if (result < 0)
                {
                    throw new Exception("Число должно быть положительным");
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            float Value = trackBarContrast.Value / 100.0f;
            this.Text = Value.ToString();
            Bitmap NewBitmap = (Bitmap)baseImg.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            img = NewBitmap;
            Invalidate();
        }

        private int GCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * GCD(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return GCD(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return GCD(a, b / 2);
            return GCD(b, Math.Abs(a - b));
        }

        private void FindOptimalSize(Image img, out int width, out int height)
        {
            if ((img.Height > 800) || (img.Width > 800))
            {
                int gcd = GCD(img.Width, img.Height);
                int resolutionWidth = img.Width / gcd;
                int resolutionHeight = img.Height / gcd;
                int residue, quotient;
                if (resolutionWidth > resolutionHeight)
                {
                    residue = (img.Width - 800) % resolutionWidth;
                    quotient = (img.Width - 800) / resolutionWidth;
                    if (residue != 0)
                    {
                        width = 800 - (resolutionWidth - residue);
                        height = img.Height - (resolutionHeight * (quotient + 1));
                    }
                    else
                    {
                        width = 800;
                        height = img.Height - (resolutionHeight * quotient);
                    }
                }
                else
                {
                    residue = (img.Height - 800) % resolutionHeight;
                    quotient = (img.Height - 800) / resolutionHeight;
                    if (residue != 0)
                    {
                        height = 800 - (resolutionHeight - residue);
                        width = img.Width - (resolutionWidth * (quotient + 1));
                    }
                    else
                    {
                        width = 800;
                        height = img.Height - (resolutionHeight * quotient);
                    }
                }
            }
            else
            {
                width = img.Width;
                height = img.Height;
            }
        }
    }
}
