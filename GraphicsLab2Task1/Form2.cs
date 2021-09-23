using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsLab2Task1
{
    public partial class Form2 : Form
    {
        public Bitmap Bitmap
        {
            get;set;
        }
        public Form2(Bitmap bitmap)
        {
            InitializeComponent();
            Bitmap = bitmap;
        }
    }
}
