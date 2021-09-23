using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsLab2Task1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();

            openFileDialog = new OpenFileDialog();
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog.FileName);
                    DrawPictureFromFile(openFileDialog.FileName);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

        }
        private void DrawPictureFromFile(string fileName)
        {
            // Create a new bitmap.
            Bitmap bmp = new Bitmap(fileName);

            pictureBox.Image = bmp;
            Bitmap firstWay = ToGrey(bmp, formula1);
            Bitmap secondWay = ToGrey(bmp, formula2);
            Bitmap picturesDif = PicturesDif(firstWay, secondWay, bmp);

            pictureBox1.Image = firstWay;
            pictureBox2.Image = secondWay;
            pictureBox3.Image = picturesDif;
        }
        private UInt32 formula1(UInt32 pixel)
        {
            float R = (float)((pixel & 0x00FF0000) >> 16);
            float G = (float)((pixel & 0x0000FF00) >> 8);
            float B = (float)(pixel & 0x000000FF);

            R = G = B = 0.299f * R + 0.587f * G + 0.114f * B;

            // собираем новый пиксель по частям (по каналам)
            UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
            return newPixel;
        }
        private UInt32 formula2(UInt32 pixel)
        {
            float R = (float)((pixel & 0x00FF0000) >> 16); // красный
            float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
            float B = (float)(pixel & 0x000000FF); // синий
                                                   // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
            R = G = B = 0.2126f * R + 0.7152f * G + 0.0722f * B;
            // собираем новый пиксель по частям (по каналам)
            UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
            return newPixel;
        }
        private Bitmap ToGrey(Bitmap bitmap, Func<UInt32, UInt32> formula)
        {
            Bitmap bmp = (Bitmap)bitmap.Clone();

            int width = bmp.Width;
            int height = bmp.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    UInt32 pixel = (UInt32)(bitmap.GetPixel(x, y).ToArgb());

                    UInt32 newPixel = formula(pixel);
                    bmp.SetPixel(x, y, Color.FromArgb((int)newPixel));
                }
            }
            return bmp;
        }

        private Bitmap PicturesDif(Bitmap picture1, Bitmap picture2, Bitmap common)
        {
            Bitmap bmp = (Bitmap)common.Clone();

            int width = bmp.Width;
            int height = bmp.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p1 = picture1.GetPixel(x, y);
                    Color p2 = picture2.GetPixel(x, y);

                    UInt32 pixel1 = (UInt32)(picture1.GetPixel(x, y).ToArgb());
                    UInt32 pixel2 = (UInt32)(picture2.GetPixel(x, y).ToArgb());
                    float R1 = (float)((pixel1 & 0x00FF0000) >> 16); // красный
                    float G1 = (float)((pixel1 & 0x0000FF00) >> 8); // зеленый
                    float B1 = (float)(pixel1 & 0x000000FF); // синий

                    float R2 = (float)((pixel2 & 0x00FF0000) >> 16); // красный
                    float G2 = (float)((pixel2 & 0x0000FF00) >> 8); // зеленый
                    float B2 = (float)(pixel2 & 0x000000FF); // синий

                    float R = 10*Math.Abs(R1 - R2);
                    float G = 10*Math.Abs(G1 - G2);
                    float B = 10*Math.Abs(B1 - B2);
                    UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    bmp.SetPixel(x, y, Color.FromArgb((int)newPixel));
                }
            }
            return bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(new Bitmap(pictureBox1.Image))
            {
                Text = "0.299R + 0.587G + 0.114B"
            };
            form.Paint += Form1_Paint;
            
            form.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int[] redCount = new int[256];
            int[] blueCount = new int[256];
            int[] greenCount = new int[256];
            Bitmap bmp = (sender as Form2).Bitmap;

            int width = bmp.Width;
            int height = bmp.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    redCount[pixel.R]++;
                    blueCount[pixel.B]++;
                    greenCount[pixel.G]++;
                }
            }
            Graphics graphics = e.Graphics;
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            Pen bluePen = new Pen(Color.Blue, 3);

            int formHeight = (sender as Form2).Height;
            int formWidth = (sender as Form2).Width;
            DrawHist(redCount, graphics, redPen, formHeight);
            DrawHist(blueCount, graphics, bluePen, formHeight);
            DrawHist(greenCount, graphics, greenPen, formHeight);
        }

        private static void DrawHist(int[] colorCount, Graphics graphics, Pen pen, int formHeight)
        {
            for (int i = 1; i < colorCount.Length; i++)
            {
                graphics.DrawLine(pen, 2 * i, -(float)colorCount[i] / 10 + formHeight, 2 * (i - 1), -(float)colorCount[i - 1] / 10 + formHeight);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(new Bitmap(pictureBox.Image))
            {
                Text = "normal picture"
            };
            form.Paint += Form1_Paint;

            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(new Bitmap(pictureBox2.Image))
            {
                Text = "0.2126R + 0.7152G + 0.0722B"
            };
            form.Paint += Form1_Paint;

            form.Show();
        }
    }
}
