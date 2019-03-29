using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace WindowsFormsComputerVision1 {

public class Vision1
{
        int gray=0;
        int image=0;

    public Vision1()
    {

    }

    public static bool CovertToGray(Bitmap b, int gray)
    {

        for (int i = 0; i < b.Width; i++)
        {
            for (int j = 0; j < b.Height; j++)
            {

                Color c1 = b.GetPixel(i, j);
                int r1 = c1.R;
                int g1 = c1.G;
                int b1 = c1.B;
                gray = (byte)(.299 * r1
                    + .587 * g1
                    + .114 * b1);
                r1 = gray;
                g1 = gray;
                b1 = gray;

                b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
            }
        }

        gray = 1;

        return true;
    }

    public static Bitmap Brighten(Bitmap b, int nBrightness)
    {

        int Red, Green, Blue;
        if (nBrightness < -255 || nBrightness > 255) return b;

        Bitmap Bright = new Bitmap(b.Width, b.Height);

        for (int r = 0; r < b.Height; r++)
        {
            for (int c = 0; c < b.Width; c++)
            {
                Color cr = b.GetPixel(c, r);
                Red = nBrightness + Convert.ToInt32(cr.R);
                Green = nBrightness + Convert.ToInt32(cr.G);
                Blue = nBrightness + Convert.ToInt32(cr.B);

                if (Red > 255) Red = 255;
                if (Red < 0) Red = 0;
                if (Green > 255) Green = 255;
                if (Green < 0) Green = 0;
                if (Blue > 255) Blue = 255;
                if (Blue < 0) Blue = 0;

                Bright.SetPixel(c, r, Color.FromArgb(Red, Green, Blue));

            }
        }

        return Bright;

    }

    public static Bitmap Contrast(Bitmap b, sbyte nContrast)
    {
        Bitmap Contrast = new Bitmap(b.Width, b.Height);

        if (nContrast < -100) nContrast = -100;
        if (nContrast > 100) nContrast = 100;

        double pixel = 0, contrast = (100.0 + nContrast) / 100.0;

        contrast *= contrast;

        int red, green, blue;

        for (int y = 0; y < b.Height; ++y)
        {
            for (int x = 0; x < b.Width; ++x)
            {
                Color cr = b.GetPixel(x, y);

                red = Convert.ToInt32(cr.R);
                green = Convert.ToInt32(cr.G);
                blue = Convert.ToInt32(cr.B);

                pixel = red / 255.0;
                pixel -= 0.5;
                pixel *= contrast;
                pixel += 0.5;
                pixel *= 255;
                if (pixel < 0) pixel = 0;
                if (pixel > 255) pixel = 255;
                red = (int)pixel;


                pixel = green / 255.0;
                pixel -= 0.5;
                pixel *= contrast;
                pixel += 0.5;
                pixel *= 255;
                if (pixel < 0) pixel = 0;
                if (pixel > 255) pixel = 255;
                green = (int)pixel;

                pixel = blue / 255.0;
                pixel -= 0.5;
                pixel *= contrast;
                pixel += 0.5;
                pixel *= 255;
                if (pixel < 0) pixel = 0;
                if (pixel > 255) pixel = 255;
                blue = (int)pixel;

                Contrast.SetPixel(x, y, Color.FromArgb(red, green, blue));
            }

        }

        return Contrast;
    }

    public static void Histogram_Equalization(Bitmap b, int gray, int image, int Equalized)
    {

        if (image != 1) MessageBox.Show("No image has been loaded");

        if (gray != 1) MessageBox.Show("Image has to be converted to Grayscale first");

        //Bitmap result = new Bitmap(b.Width, b.Height);


        int[] intensity = new int[256];
        int[] histogram = new int[256];
            int min = 0;
            int count = 0;
            



            for (int i=0; i < 256; i++)
            {
                intensity[i] = 0;
                histogram[i] = 0;
            }

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    Color c1 = b.GetPixel(x, y);
                    int pixel = Convert.ToInt32( c1.R);
                    intensity[pixel] = intensity[pixel] + 1;

                }
            }

            int pix = 0;


            for (int i = 1; i < 256; i++)
            {

                if(intensity[i] !=0)
                {
                    

                    intensity[i] = intensity[pix] + intensity[i];
                    pix=i;

                }
            }

            while (min == 0)
            {
                min = intensity[count];
                count++;
            }

            for (int i = 1; i < 256; i++)
            {
                if (intensity[i] != 0)
                {
                    histogram[i] = (int)( ( (intensity[i] - min) *255 ) / ( (b.Height * b.Width) - min));
                }
            }

            for (int y = 0; y < b.Height; ++y)
            {
                for (int x = 0; x < b.Width; ++x)
                {
                    int converted_pixel = 0;
                    Color c1 = b.GetPixel(x, y);
                    converted_pixel = histogram[c1.R];

                    b.SetPixel(x, y, Color.FromArgb(histogram[c1.R], histogram[c1.R], histogram[c1.R]));
                }
            }
                    Equalized += 1;
    }
            

    }
}