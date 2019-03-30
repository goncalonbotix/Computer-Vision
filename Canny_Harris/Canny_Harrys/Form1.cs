using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Canny_Harrys
{
    public partial class Form1 : Form
    {

        Bitmap bm;
        Image<Gray, Byte> img;
        Mat resImage = new Mat();
        Image<Gray, float> harrisImage = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CvInvoke.Canny(img, resImage, 50, 200);
            picProcImage.BackgroundImage = resImage.Bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {

                img = new Image<Gray, Byte>(dialog.FileName);
                picOrigImage.BackgroundImage = img.ToBitmap();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

                harrisImage = new Image<Gray, float>(img.Size);
                CvInvoke.CornerHarris(img, harrisImage, 2, 3, 0.01);
                picProcImage.BackgroundImage = harrisImage.ToBitmap();
           
        }
    }
}
