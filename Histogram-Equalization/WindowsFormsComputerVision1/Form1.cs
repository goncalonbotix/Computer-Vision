using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsComputerVision1
{
    public partial class Form1 : Form
    {

        int gray = 0;
        int image = 0;
        int equalized = 0;

        public Form1()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (image == 0) MessageBox.Show("No image has been loaded");
            if (gray == 0) MessageBox.Show("Image has not yet been converted to Gray-scale");


            try
            {
                Bitmap result = new Bitmap(this.OriginalPicBox.Image);
                //Vision1.CovertToGray(result, gray);
                Vision1.Histogram_Equalization(result, gray, image, equalized);
                this.ResultPicBox.Image = result;
                MessageBox.Show("Ran thw ");
                //ResultImageBox.Image = result;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            equalized = 1;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                Bitmap pic = new Bitmap(dialog.FileName);

                while (pic.Width > OriginalPicBox.Width || pic.Height > OriginalPicBox.Height)
                    pic = new Bitmap(pic, new Size(pic.Width / 2, pic.Height / 2));
                this.OriginalPicBox.Image = pic;

                FileInfo finfo = new FileInfo(dialog.FileName);

                SizeInfo.Text = OriginalPicBox.Image.Width.ToString();
                SizeInfo.Text = OriginalPicBox.Image.Height.ToString();
            }

            image = 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                Bitmap result = new Bitmap(this.OriginalPicBox.Image);
                Vision1.CovertToGray(result, gray);
                this.ResultPicBox.Image = result;
                //ResultImageBox.Image = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            gray = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Brighten dlg = new Brighten();
                dlg.Brightness = 0;

                if (DialogResult.OK == dlg.ShowDialog())
                {

                    Bitmap bright = new Bitmap(this.OriginalPicBox.Image);
                    bright = Vision1.Brighten(bright, dlg.Brightness);
                    ResultPicBox.Image = null;
                    ResultPicBox.Image = bright;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
