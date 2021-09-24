using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBDecomposer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static Bitmap[] GetRGBChannels(Bitmap source)
        {
            Bitmap[] result = new Bitmap[3] { new Bitmap(source.Width, source.Height), new Bitmap(source.Width, source.Height), new Bitmap(source.Width, source.Height) };
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    result[0].SetPixel(i, j, Color.FromArgb(color.A, color.R, 0, 0));
                    result[1].SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                    result[2].SetPixel(i, j, Color.FromArgb(color.A, 0, 0, color.B));
                }
            }
            return result;
        }

        private void findPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    OriginalPicture.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        public void CreateChart(Bitmap image)
        {
            int width = 256;
            int height = 200;

            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    Color color = image.GetPixel(i, j);
                    ++R[color.R];
                    ++G[color.G];
                    ++B[color.B];
                }
            }
            int maxR = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (R[i] > maxR)
                    maxR = R[i];
            }
            int maxG = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (G[i] > maxG)
                    maxG = G[i];
            }
            int maxB = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (B[i] > maxB)
                    maxB = B[i];
            }

            Bitmap gistReBitmap = new Bitmap(width, height);
            Bitmap gistGrBitmap = new Bitmap(width, height);
            Bitmap gistBlBitmap = new Bitmap(width, height);
            double pointR = (double)maxR / height;
            double pointG = (double)maxG / height;
            double pointB = (double)maxB / height;
            for (int i = 0; i < width - 1; ++i)
            {
                for (int j = height - 1; j > height - R[i] / pointR; --j)
                {
                    gistReBitmap.SetPixel(i, j, Color.Red);
                }
                for (int j = height - 1; j > height - G[i] / pointG; --j)
                {
                    gistGrBitmap.SetPixel(i, j, Color.Green);
                }
                for (int j = height - 1; j > height - B[i] / pointB; --j)
                {
                    gistBlBitmap.SetPixel(i, j, Color.Blue);
                }
            }

            gistogramR.Image = gistReBitmap;
            gistogramG.Image = gistGrBitmap;
            gistogramB.Image = gistBlBitmap;
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            if (OriginalPicture.Image != null)
            {
                Bitmap[] RGBMap = GetRGBChannels(new Bitmap(OriginalPicture.Image));

                RedPicture.Image = RGBMap[0];
                GreenPicture.Image = RGBMap[1];
                BluePicture.Image = RGBMap[2];

                CreateChart(new Bitmap(OriginalPicture.Image));
            }
        }

        private void gistogram_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
