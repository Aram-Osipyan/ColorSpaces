using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Bitmap bmpHSV;
        private Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    pictureBox2.ImageLocation = imageLocation;
                    bmp = new Bitmap(pictureBox1.ImageLocation);
                    bmpHSV = new Bitmap(pictureBox1.ImageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозмоно открыть выбранный файл","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            int b = trackBar2.Value;
            int c = trackBar3.Value;
            HSV(a, b, c);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            int b = trackBar2.Value;
            int c = trackBar3.Value;
            HSV(a, b, c); 
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            int b = trackBar2.Value;
            int c = trackBar3.Value;
            HSV(a, b, c); 
        }
        /**/
        private void HSV(int a, int b, int c)
        {
            double h, s, v;
            for (int y = 0; y < bmpHSV.Height; y++)
                for (int x = 0; x < bmpHSV.Width; x++)
                {
                    RGBtoHSV(bmp.GetPixel(x, y), out h, out s, out v);
                    h = ((int)(h + a * 10 + 180)) % 360;
                    int s1 = ((int)((s * 100) + b * 10 - 100));
                    if (s1 > 100)
                        s = 1;
                    else if (s1 < 0)
                        s = 0;
                    else s = s1 * 0.01;

                    int v1 = ((int)((v * 100) + c * 10 - 100));
                    if (v1 > 100)
                        v = 1;
                    else if (v1 < 0)
                        v = 0;
                    else v = v1 * 0.01;
                    bmpHSV.SetPixel(x, y, HSVtoRGB(h, s, v));
                }
            pictureBox2.Image = bmpHSV;
        }
        private void RGBtoHSV(Color c, out double h, out double s, out double v)
        {
            double r = c.R / (255 * 1.0);
            double g = c.G / (255 * 1.0);
            double b = c.B / (255 * 1.0);
            double min_ = Math.Min(r, Math.Min(g, b));
            double max_ = Math.Max(r, Math.Max(g, b));
            if (max_ == min_)
                h = 0;
            else if (max_ == r)
            {
                h = 60 * (g - b) / (max_ - min_);
                if (g < b)
                    h += 360;
            }
            else if (max_ == g)
                h = 60 * (b - r) / (max_ - min_) + 120;
            else
                h = 60 * (r - g) / (max_ - min_) + 240;

            s = max_ == 0 ? 0 : 1 - (min_ / max_);

            v = max_;           

        }
        private Color HSVtoRGB(double h, double s, double v)
        {
            int H_i = ((int)Math.Floor(h / 60)) % 6;
            double f = h / 60 - Math.Floor(h / 60);
            int p = (int)(v * (1 - s) * 255);
            int q = (int)(v * (1 - f * s) * 255);
            int t = (int)(v * (1 - (1 - f) * s) * 255);
            int V = (int)(v * 255);

            switch (H_i)
            {
                case 0: return Color.FromArgb(V, t, p);
                case 1: return Color.FromArgb(q, V, p);
                case 2: return Color.FromArgb(p, V, t);
                case 3: return Color.FromArgb(p, q, V);
                case 4: return Color.FromArgb(t, p, V);
                default: return Color.FromArgb(V, p, q);               
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image.Save(pictureBox2.ImageLocation.Replace(".", "(1)."));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(pictureBox1.ImageLocation.Replace(".", "(0)."));
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox2, "Чтобы сохранить изображение, нажмите на него");

        }
    }
}
