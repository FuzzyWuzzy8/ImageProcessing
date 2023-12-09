using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPO1
{
    public partial class ReadWriteImage : Form
    {
        public ReadWriteImage()
        {
            InitializeComponent();
            //OpacityUpDown1.Value = 255; //255


        }             

        private void SaveAsButton(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Tiff Image|*.tiff|Png Image|*.png|Gif Image|*.gif";       //selection of formats
            saveFileDialog1.Title = "Save an Image File";             //description of dialog file
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();             // save using OpenFile   
                switch (saveFileDialog1.FilterIndex)    //save with suitable format chose from the list
                {
                    case 1:
                        MyPictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        MyPictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        MyPictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case 4:
                        MyPictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 5:
                        MyPictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                fs.Close();
            }
        }
        Image myImage;
        private void OpenFromHDD_Button(object sender, EventArgs e)
        {
            
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true })  // Filter = "*.bmp|*.bmp|*.png|*.png|All files (*.*)|*.*" };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        MyPictureBox.Image = Image.FromFile(ofd.FileName);
                        myImage = MyPictureBox.Image;
                        WidthTextBox1.Text = myImage.Width.ToString();
                        HeightTextBox1.Text = myImage.Height.ToString();
                        VerticalTextBox1.Text = myImage.VerticalResolution.ToString();
                        HorizontalTextBox1.Text = myImage.HorizontalResolution.ToString();
                        //FileDescription2.Text = myImage.Flags.ToString();                        
                        //string directoryPath = Path.GetDirectoryName(ofd.FileName);                        
                        string fullPath = ofd.FileName;
                        string fileName = ofd.SafeFileName;
                        string path = fullPath.Replace(fileName, "");
                        FileDescription1.Text = "File name: " + fileName + "\r\n" +
                                 "Full path: " + fullPath + "\r\n" +
                                 "Folder name: " + path;


                    }
                MyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
        Image img2;


        private void OpenfromHDD2_Button(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true })  // Filter = "*.bmp|*.bmp|*.png|*.png|All files (*.*)|*.*" };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        MyPictureBox2.Image = Image.FromFile(ofd.FileName);
                        img2 = MyPictureBox2.Image;
                        WidthTextBox2.Text = img2.Width.ToString();
                        HeightTextBox2.Text = img2.Height.ToString();
                        VerticalTextBox2.Text = img2.VerticalResolution.ToString();
                        HorizontalTextBox2.Text = img2.HorizontalResolution.ToString();
                        //FileDescription2.Text = img2.Flags.ToString();
                        string fullPath = ofd.FileName;
                        string fileName = ofd.SafeFileName;
                        string path = fullPath.Replace(fileName, "");
                        FileDescription2.Text = "File name: " + fileName + "\r\n" +
                                 "Full path: " + fullPath + "\r\n" +
                                 "Folder name: " + path;

                    }
                MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage

            }
        }

        private void FlipX_Click(object sender, EventArgs e)
        {
            if (myImage != null)  //MyPictureBox
            {
                myImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                MyPictureBox2.Image = myImage;
                MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage
                //MyPictureBox.RotateFlip(RotateFlipType.Rotate180FlipX);   //img2

                WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
                HeightTextBox2.Text = myImage.Height.ToString();
                VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
                HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
            }
        }

        private void FlipY_Click(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                myImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                MyPictureBox2.Image = myImage;
                MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage
                                                                           //MyPictureBox2.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
                HeightTextBox2.Text = myImage.Height.ToString();
                VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
                HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();

            }
        }
        public Image PictureBoxZoom1(Image img, Size size)
        {
            //Bitmap zoombmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height * size.Height / 100);
            Bitmap zoombmp = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));
            Graphics g = Graphics.FromImage(zoombmp);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //interpolation method of Nearest Neighbors
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            return zoombmp;
        }

        private void ZoomBar(object sender, EventArgs e)
        {
            numericZoom1.Value = Zoom.Value;
            AddToPictureBox(PictureBoxZoom1(myImage, new Size(Zoom.Value, Zoom.Value)), 2);
            //MyPictureBox2.Image = PictureBoxZoom1(myImage, new Size(Zoom.Value, Zoom.Value));
            MyPictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;  //StretchImage  CenterImage
        }

        private void numericZoom1_ValueChanged(object sender, EventArgs e)
        {
            Zoom.Value = (int)numericZoom1.Value;
            AddToPictureBox(PictureBoxZoom1(myImage, new Size(Zoom.Value, Zoom.Value)), 2);
            //MyPictureBox2.Image = PictureBoxZoom1(myImage, new Size(Zoom.Value, Zoom.Value));
            MyPictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;  //StretchImage  CenterImage          
        }

        // /*
        private void AddToPictureBox(Image image, int pictureBoxNumber)
        {
            switch (pictureBoxNumber)
            {
                case 1:
                    MyPictureBox.Image = image;                  //load image to MyPictureBox              
                    this.MyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;   //StretchImage /CenterImage auto scale MyPictureBox to sice of loaded img
                    WidthTextBox1.Text = image.Width.ToString();
                    HeightTextBox1.Text = image.Height.ToString();
                    VerticalTextBox1.Text = image.VerticalResolution.ToString();
                    HorizontalTextBox1.Text = image.HorizontalResolution.ToString();
                    break;
                case 2:
                    MyPictureBox2.Image = image;                  //load image to MyPictureBox             
                    //this.MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;   //StretchImage/ CenterImage /AutoSize  auto scale MyPictureBox to sice of loaded img
                    WidthTextBox2.Text = image.Width.ToString();
                    HeightTextBox2.Text = image.Height.ToString();
                    VerticalTextBox2.Text = image.VerticalResolution.ToString();
                    HorizontalTextBox2.Text = image.HorizontalResolution.ToString();
                    break;
            }
        }
      

        private void Grey_Click(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                //MyPictureBox2.Image = Greyness(myImage);
                //MyPictureBox2.Image = Separation(myImage, SeparationChannel.GREYNESS, 0);
                AddToPictureBox(Separation(myImage, SeparationChannel.GREYNESS, 0, 0), 2);
                //MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage
            }
        }

        public static Bitmap RotateImage1(Image image, float angle)
        {

            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);        //declare variables describing the center of rotation (axis of rotation)

            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);                                                 //define a new bitmap

            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);   // define the resolution of the new bitmap

            Graphics g = Graphics.FromImage(rotatedBmp);  //FromImage method of Graphics class,  we create an object g - a copy of the input bitmap on which we will operate

            g.TranslateTransform(offset.X, offset.Y);   // set the center of rotation (axis of rotation)

            g.RotateTransform(angle);  // execute rotation

            g.DrawImage(image, new PointF(-offset.X, -offset.Y)); //g.DrawImage(image, new PointF(0, 0));  //draw the image in the specified location, newPoint are the coordinates of the upper left corner of the bitmap 

            return rotatedBmp;  //return the rotated bitmap

        }
        private void Identity_Click(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                //MyPictureBox2.Image = Identity(myImage);                
                //MyPictureBox2.Image = Separation(myImage, SeparationChannel.IDENTITY, 0);
                AddToPictureBox(Separation(myImage, SeparationChannel.IDENTITY, 0, 0), 2);

                //filter(myPictureBox.Image, new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 }, 1); // new function 

                //MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage                          

            }
        }

        private void RotateBar(object sender, EventArgs e)
        {

            numericRotate1.Value = Rotate.Value;
            MyPictureBox2.Image = RotateImage1(myImage, Rotate.Value);  //img2
            MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage 
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Rotate.Value = (int)numericRotate1.Value;
            MyPictureBox2.Image = RotateImage1(myImage, Rotate.Value);     //img2
            MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage           


            WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
            HeightTextBox2.Text = myImage.Height.ToString();
            VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
            HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
        }

        public static Bitmap Separation(Image input_Img, SeparationChannel separation, int opacity, int bright)
        {
            Bitmap new_Img = new Bitmap(input_Img);
            Bitmap output_Img = new Bitmap(new_Img);
            int red = 0;
            int green = 0;
            int blue = 0;
            int alpha = 0;

            for (int y = 0; y < new_Img.Height; y++)
            {
                for (int x = 0; x < new_Img.Width; x++)
                {
                    Color colorPixel = new_Img.GetPixel(x, y);
                    alpha = colorPixel.A;
                    if (separation == SeparationChannel.RED)
                    {
                        red = colorPixel.R;
                    }
                    else if (separation == SeparationChannel.GREEN)
                    {
                        green = colorPixel.G;
                    }
                    else if (separation == SeparationChannel.BLUE)
                    {
                        blue = colorPixel.B;
                    }
                    else if (separation == SeparationChannel.ALPHA)
                    {
                        alpha = opacity;
                        blue = colorPixel.B;
                        green = colorPixel.G;
                        red = colorPixel.R;
                    }
                    else if (separation == SeparationChannel.GRAYSCALE)
                    {
                        alpha = colorPixel.A;

                        red = (colorPixel.R + colorPixel.G + colorPixel.B) / 3;

                        green = (colorPixel.R + colorPixel.G + colorPixel.B) / 3;

                        blue = (colorPixel.R + colorPixel.G + colorPixel.B) / 3;

                    }
                    else if (separation == SeparationChannel.SEPIA)
                    {
                        alpha = colorPixel.A;

                        int red1 = (int)((0.393 * colorPixel.R) + (0.769 * colorPixel.G) + (0.189 * colorPixel.B));

                        int green1 = (int)((0.349 * colorPixel.R) + (0.686 * colorPixel.G) + (0.168 * colorPixel.B));

                        int blue1 = (int)((0.272 * colorPixel.R) + (0.534 * colorPixel.G) + (0.131 * colorPixel.B));

                        if (red1 > 255)
                        {
                            red = 255;
                        }
                        else
                        {
                            red = red1;
                        }
                        if (green1 > 255)
                        {
                            green = 255;
                        }
                        else
                        {
                            green = green1;
                        }
                        if (blue1 > 255)
                        {
                            blue = 255;
                        }
                        else
                        {
                            blue = blue1;
                        }


                    }
                    else if (separation == SeparationChannel.IDENTITY)
                    {
                        red = colorPixel.R;

                        green = colorPixel.G;

                        blue = colorPixel.B;

                    }
                    else if (separation == SeparationChannel.GREYNESS)
                    {
                        red = 127;

                        green = 127;

                        blue = 127;
                    }
                    else if (separation == SeparationChannel.BRIGHTNESS)
                    {

                        int red1 = colorPixel.R + bright; // +c -255 -255
                        int green1 = colorPixel.G + bright;
                        int blue1 = colorPixel.B + bright;

                        if (red1 > 255) red = 255;
                        else if (red1 < 0) red = 0;
                        else red = red1;
                        if (green1 > 255) green = 255;
                        else if (green1 < 0) green = 0;
                        else green = green1;
                        if (blue1 > 255) blue = 255;
                        else if (blue1 < 0) blue = 0;
                        else blue = blue1;

                    }
                    else if (separation == SeparationChannel.CONTRAST)
                    {
                        //unfinished
                        int red1 = colorPixel.R + bright; // +c -100 up to 100
                        int green1 = colorPixel.G + bright;
                        int blue1 = colorPixel.B + bright;

                        red = colorPixel.R; // *a -100 do 100. 
                        green = colorPixel.G;
                        blue = colorPixel.B;


                    }
                    output_Img.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                }
            }
            return output_Img;
        }
        public enum SeparationChannel
        {
            RED, GREEN, BLUE, ALPHA, GRAYSCALE, SEPIA, IDENTITY, GREYNESS, BRIGHTNESS, CONTRAST
        }

        private void RedButton1_click(object sender, EventArgs e)  //radioButton1_CheckedChanged
        {
            if (myImage != null)
            {
                //MyPictureBox2.Image = SeparationRed(myImage);
                MyPictureBox2.Image = Separation(myImage, SeparationChannel.RED, 0, 0);


                WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
                HeightTextBox2.Text = myImage.Height.ToString();
                VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
                HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
            }
        }
        private void GreenButton1_click(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                MyPictureBox2.Image = Separation(myImage, SeparationChannel.GREEN, 0, 0);

                WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
                HeightTextBox2.Text = myImage.Height.ToString();
                VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
                HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
            }
        }
        private void BlueButton1_click(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                MyPictureBox2.Image = Separation(myImage, SeparationChannel.BLUE, 0, 0);

                WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
                HeightTextBox2.Text = myImage.Height.ToString();
                VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
                HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
            }
        }

        private void GrayScaleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                //MyPictureBox2.Image = Separation(myImage, SeparationChannel.GRAYSCALE, 0);
                AddToPictureBox(Separation(myImage, SeparationChannel.GRAYSCALE, 0, 0), 2);
            }
        }
        private void SepiaButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (myImage != null)
            {                
                AddToPictureBox(Separation(myImage, SeparationChannel.SEPIA, 0, 0), 2);
                //MyPictureBox2.Image = Separation(myImage, SeparationChannel.SEPIA, 0);
            }
        }


        //moved to separation function
        public static Bitmap OpacityImage(Image myImage, int Alpha) //Byte 
        {
            Bitmap MainImage = new Bitmap(myImage);
            Bitmap TransparentImage = new Bitmap(MainImage.Width, MainImage.Height); // Determining Width and Height of the MyPictureBox Image

            Color c = Color.Black;
            Color v = Color.Black;

            for (int i = 0; i < TransparentImage.Width; i++)
            {
                for (int y = 0; y < TransparentImage.Height; y++)
                {
                    c = MainImage.GetPixel(i, y);
                    v = Color.FromArgb(Alpha, c.R, c.G, c.B); //Alpha is up to 255 
                    TransparentImage.SetPixel(i, y, v);   //sets pixel in new transparent img
                }
            }
            return TransparentImage;
        }

        private void OpacityBar1_Scroll(object sender, EventArgs e)
        {
            if (myImage != null && OpacityButton1.Checked)
            {
                //double BarToDouble = Convert.ToDouble(OpacityBar1.Value);

                OpacityUpDown1.Value = OpacityBar1.Value;
                //MyPictureBox2.Image = OpacityImage(myImage, (int)OpacityBar1.Value);  //up to 255 -Byte
                MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage

                MyPictureBox2.Image = (Separation(myImage, SeparationChannel.ALPHA, (int)OpacityBar1.Value, 0)); //ALPHA method

                WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
                HeightTextBox2.Text = myImage.Height.ToString();
                VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
                HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
            }
        }

        private void OpacityUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (myImage != null && OpacityButton1.Checked)
            {
                //double BarToDouble = Convert.ToDouble(OpacityBar1.Value);
                OpacityBar1.Value = (int)OpacityUpDown1.Value;
                //MyPictureBox2.Image = OpacityImage(myImage, (int)OpacityBar1.Value); //up to 255 -Byte

                //AddToPictureBox(Separation(myImage, SeparationChannel.ALPHA, OpacityBar1.Value), 2);
                MyPictureBox2.Image = (Separation(myImage, SeparationChannel.ALPHA, (int)OpacityBar1.Value, 0)); //ALPHA method

            }

        }
        private void OpacityButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                //MyPictureBox2.Image = OpacityImage(myImage, (int)OpacityBar1.Value); //up to 255 -Byte  
                MyPictureBox2.Image = (Separation(myImage, SeparationChannel.ALPHA, (int)OpacityBar1.Value, 0)); //ALPHA method

            }

        }

        private void BrightnessBar1_Scroll(object sender, EventArgs e)
        {
            BrightnessUpDown1.Value = BrightnessBar1.Value;
            MyPictureBox2.Image = (Separation(myImage, SeparationChannel.BRIGHTNESS, 0, (int)BrightnessUpDown1.Value));
        }

        private void BrightnessUpDown1_ValueChanged(object sender, EventArgs e)
        {
            BrightnessBar1.Value = (int)BrightnessUpDown1.Value;
            MyPictureBox2.Image = (Separation(myImage, SeparationChannel.BRIGHTNESS, 0, (int)BrightnessUpDown1.Value));
        }

        private void ContrastBar1_Scroll(object sender, EventArgs e)
        {
            ContrastUpDown1.Value = ContrastBar1.Value;
        }

        private void ContrastUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ContrastBar1.Value = (int)ContrastUpDown1.Value;
            MyPictureBox2.Image = AdjustContrast(myImage, (int)ContrastBar1.Value);
        }

        public static Bitmap AdjustContrast(Image myImage, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = new Bitmap(myImage);
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

            return NewBitmap;
        }

        //moved to function seperation1 
        private void AdjustBinarization(Image myImage, PaintEventArgs e)
        {

            Bitmap curBitmap = new Bitmap(myImage);
            // Establish a graphics object from external object
            Graphics g = e.Graphics;
            // if it is to open file successful.
            if (myImage != null)
            {
                // Red
                int iR = 0;
                // Green
                int iG = 0;
                // Blue
                int iB = 0;

                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    curBitmap.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * curBitmap.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                // Set every third value to 255. A 24bpp bitmap will binarization.  
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    // Get the red channel
                    iR = rgbValues[counter + 2];
                    // Get the green channel
                    iG = rgbValues[counter + 1];
                    // Get the blue channel
                    iB = rgbValues[counter + 0];
                    // If the gray value more than threshold and then set a white pixel.
                    if ((iR + iG + iB) / 3 > 100)
                    {
                        // White pixel
                        rgbValues[counter + 2] = 255;
                        rgbValues[counter + 1] = 255;
                        rgbValues[counter + 0] = 255;
                    }
                    else
                    {
                        // Black pixel
                        rgbValues[counter + 2] = 0;
                        rgbValues[counter + 1] = 0;
                        rgbValues[counter + 0] = 0;
                    }
                }

                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                // Unlock the bits.
                curBitmap.UnlockBits(bmpData);

                // Draw the modified image.
                g.DrawImage(curBitmap, 140, 10, curBitmap.Width, curBitmap.Height);
            }
        }
        private Bitmap GammaCorrection(Image myImage, double gamma, double c = 1d)
        {
            Bitmap img = new Bitmap(myImage);
            int width = img.Width;
            int height = img.Height;
            BitmapData srcData = img.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = srcData.Stride * srcData.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);
            img.UnlockBits(srcData);
            int current = 0;
            int cChannels = 3;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    current = y * srcData.Stride + x * 4;
                    for (int i = 0; i < cChannels; i++)
                    {
                        double range = (double)buffer[current + i] / 255;
                        double correction = c * Math.Pow(range, gamma);
                        result[current + i] = (byte)(correction * 255);
                    }
                    result[current + 3] = 255;
                }
            }
            Bitmap resImg = new Bitmap(width, height);
            BitmapData resData = resImg.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, resData.Scan0, bytes);
            resImg.UnlockBits(resData);
            return resImg;
        }

        private void GammaButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (myImage != null)
            {
                MyPictureBox2.Image = GammaCorrection(myImage, (int)GammaBar1.Value); //up to 255 -Byte  
                //MyPictureBox2.Image = (Separation(myImage, SeparationChannel.ALPHA, (int)OpacityBar1.Value, 0)); //ALPHA method
            }
        }

        private void GammaBar1_Scroll(object sender, EventArgs e)
        {
            if (myImage != null && GammaButton1.Checked)
            {
                GammaUpDown1.Value = GammaBar1.Value;
                MyPictureBox2.Image = GammaCorrection(myImage, (int)GammaBar1.Value);
            }
        }

        private void GammaUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (myImage != null && GammaButton1.Checked)
            {
                GammaBar1.Value = (int)GammaUpDown1.Value;
                MyPictureBox2.Image = GammaCorrection(myImage, (int)GammaBar1.Value);
            }
        }

        private void BinarizationButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (myImage != null)
            {

                MyPictureBox2.Image = (Separation1(myImage, SeparationChannelTwo.BINARIZATION, (int)BinarizationUpDown1.Value * 10));

            }
        }

        private void BinarizationBar1_Scroll(object sender, EventArgs e)
        {
            if (myImage != null && BinarizationButton1.Checked)
            {
                BinarizationUpDown1.Value = BinarizationBar1.Value;
                MyPictureBox2.Image = (Separation1(myImage, SeparationChannelTwo.BINARIZATION, (int)BinarizationUpDown1.Value * 10));
            }
        }

        private void BinarizationUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (myImage != null && BinarizationButton1.Checked)
            {
                BinarizationBar1.Value = (int)BinarizationUpDown1.Value;
                MyPictureBox2.Image = (Separation1(myImage, SeparationChannelTwo.BINARIZATION, (int)BinarizationUpDown1.Value * 10));
            }
        }

        public static Bitmap Separation1(Image input_Img, SeparationChannelTwo separation, int treshold)
        {
            Bitmap new_Img = new Bitmap(input_Img);
            Bitmap output_Img = new Bitmap(new_Img);
            int red = 0;
            int green = 0;
            int blue = 0;
            int alpha = 0;

            for (int y = 0; y < new_Img.Height; y++)
            {
                for (int x = 0; x < new_Img.Width; x++)
                {
                    Color colorPixel = new_Img.GetPixel(x, y);
                    alpha = colorPixel.A;
                    if (separation == SeparationChannelTwo.BINARIZATION)
                    {
                        if (colorPixel.R + colorPixel.G + colorPixel.B <= treshold)
                        {
                            red = 0;
                            blue = 0;
                            green = 0;
                        }
                        else if (colorPixel.R + colorPixel.G + colorPixel.B > treshold)
                        {
                            red = 255;
                            blue = 255;
                            green = 255;
                        }

                    }
                    output_Img.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                }
            }
            return output_Img;
        }
        public enum SeparationChannelTwo
        {
            BINARIZATION,
        }

        // /*
        private void filter(Image input_Img, int[] maskValues, int dzielnik)
        {
            int[,] mask = new int[3, 3] { { maskValues[0], maskValues[1], maskValues[2] }, { maskValues[3], maskValues[4], maskValues[5] }, { maskValues[6], maskValues[7], maskValues[8] } };     //filter mask definition 3x3
            Bitmap new_Img = new Bitmap(input_Img);
            Bitmap output_Img = new Bitmap(new_Img);

            for (int i = 1; i < new_Img.Height - 1; i++)    //column image bitmap scan loop
            {
                for (int j = 1; j < new_Img.Width - 1; j++)   //loop scan bitmap image rows 
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    for (int h_filter = -1; h_filter < 2; h_filter++)              //column filter mask loop
                    {
                        for (int w_filter = -1; w_filter < 2; w_filter++)         //lines filter mask loop
                        {
                            r += new_Img.GetPixel(j + w_filter, i + h_filter).R * mask[h_filter + 1, w_filter + 1] / dzielnik;   //convolution of a bitmap with a mask filter specified by a 3x3 mask
                            g += new_Img.GetPixel(j + w_filter, i + h_filter).G * mask[h_filter + 1, w_filter + 1] / dzielnik;
                            b += new_Img.GetPixel(j + w_filter, i + h_filter).B * mask[h_filter + 1, w_filter + 1] / dzielnik;

                            if (r > 255) r = 255;
                            if (r < 0) r = 0;
                            if (g > 255) g = 255;
                            if (g < 0) g = 0;
                            if (b > 255) b = 255;
                            if (b < 0) b = 0;
                        }
                    }
                    output_Img.SetPixel(j, i, Color.FromArgb(r, g, b));  //derivation of the result of the filter operation
                }
            }
            MyPictureBox2.Image = output_Img;
        }
        
        private void applyMaskButton_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                int[] mask = new int[] {
                    (int) maskOne1.Value,
                    (int) maskOne2.Value,
                    (int) maskOne3.Value,
                    (int) maskTwo1.Value,
                    (int) maskTwo2.Value,
                    (int) maskTwo3.Value,
                    (int) maskThree1.Value,
                    (int) maskThree2.Value,
                    (int) maskThree3.Value
                };

                if (mask.Any(num => num != 0))
                {
                    int dzielnik = mask.Sum();
                    Image image = MyPictureBox.Image;
                    filter(image, mask, dzielnik == 0 ? 1 : dzielnik);
                }
            }
        }

        private void ExactCopy_Click(object sender, EventArgs e)
        {
            {
                Image image = MyPictureBox.Image;
                Bitmap new_Img = new Bitmap(image);

                Bitmap output_Img = new Bitmap(new_Img);

                for (int y = 0; y < new_Img.Height; y++)
                {
                    for (int x = 0; x < new_Img.Width; x++)
                    {

                        Color colorPixel = new_Img.GetPixel(x, y);
                        int a = colorPixel.A;
                        int r = colorPixel.R;
                        int g = colorPixel.G;
                        int b = colorPixel.B;

                        output_Img.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }
                MyPictureBox2.Image = output_Img;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                int[] mask = new int[] {
                    (int) maskOne1.Value,
                    (int) maskOne2.Value,
                    (int) maskOne3.Value,
                    (int) maskTwo1.Value,
                    (int) maskTwo2.Value,
                    (int) maskTwo3.Value,
                    (int) maskThree1.Value,
                    (int) maskThree2.Value,
                    (int) maskThree3.Value
                };

                if (mask.Any(num => num != 0))
                {
                    int dzielnik = mask.Sum();
                    Image image = MyPictureBox.Image;
                    filter(image, mask, dzielnik == 0 ? 1 : dzielnik);
                }
            }
        }
        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                maskOne1.Value = 0;
                maskOne2.Value = 0;
                maskOne3.Value = 0;
                maskTwo1.Value = 0;
                maskTwo2.Value = 1;  
                maskTwo3.Value = 0;
                maskThree1.Value = 0;
                maskThree2.Value = 0;
                maskThree3.Value = 0;
            }
        }

        private void Averaging_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                filter(MyPictureBox.Image, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 9);
            }                
        }

        private void LowPassFilter_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                filter(MyPictureBox.Image, new int[] { 1, 1, 1, 1, 8, 1, 1, 1, 1 }, 16);
            }
        }

        private void HighPassFilter_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                filter(MyPictureBox.Image, new int[] { -1, -1, -1, -1, 8, -1, -1, -1, -1 }, 1);
            }
        }

        private void PrewittFilter_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                filter(MyPictureBox.Image, new int[] { -1, -1, -1, 0, 0, 0, 1, 1, 1 }, 1);
            }
        }

        private void SobelFilter_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                filter(MyPictureBox.Image, new int[] { 1, 0, -1, 2, 0, -2, 1, 0, -1 }, 1);
            }
        }

        private void LaplaceFilter_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null)
            {
                filter(MyPictureBox.Image, new int[] { 0, -2, 0, -2, 4, -2, 0, -2, 0 }, 1);
            }
        }     
                
        public static Bitmap DrawText1(Image myImage, int HorizontalValue, int VerticalValue, ColorChannel TextColors, string InputDrawText, int FontSize)
        {
            string firstText = InputDrawText;
            //string secondText = "SOMETHING";

            PointF firstLocation = new PointF((HorizontalValue +0f), (VerticalValue +0f));
            //PointF secondLocation = new PointF((HorizontalValue1 +100f), (VerticalValue1 +400f));

            Bitmap bitmap = new Bitmap(myImage);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font Calibri = new Font("Calibri", FontSize))
                {
                    if (TextColors == ColorChannel.RedText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Red, firstLocation);
                        //graphics.DrawString(secondText, Calibri, Brushes.LimeGreen, secondLocation);
                    }
                    else if (TextColors == ColorChannel.GreenText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Green, firstLocation);
                    }
                    else if (TextColors == ColorChannel.BlueText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Blue, firstLocation);
                    }
                    else if (TextColors == ColorChannel.YellowText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Yellow, firstLocation);
                    }
                    else if (TextColors == ColorChannel.OrangeText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Orange, firstLocation);
                    }
                    else if (TextColors == ColorChannel.BrownText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Brown, firstLocation);
                    }
                    else if (TextColors == ColorChannel.PurpleText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Purple, firstLocation);
                    }
                    else if (TextColors == ColorChannel.LimeText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Lime, firstLocation);
                    }
                    else if (TextColors == ColorChannel.PinkText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Pink, firstLocation);
                    }
                    else if (TextColors == ColorChannel.AquaText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Aqua, firstLocation);
                    }
                    else if (TextColors == ColorChannel.WhiteText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.White, firstLocation);
                    }
                    else if (TextColors == ColorChannel.BlackText)
                    {
                        graphics.DrawString(firstText, Calibri, Brushes.Black, firstLocation);
                    }
                }
            }
            return bitmap;
        }
        public enum ColorChannel
        {
            RedText, GreenText, BlueText, YellowText, OrangeText, BrownText, PurpleText, LimeText, PinkText, AquaText, WhiteText, BlackText 
        }

        private void DrawText_button_Click(object sender, EventArgs e)
        {
            if (MyPictureBox.Image != null && RedColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.RedText, InputText.Text, (int)numericFontSize.Value));
            }
            else if(MyPictureBox.Image != null && GreenColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.GreenText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && BlueColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.BlueText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && YellowColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.YellowText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && OrangeColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.OrangeText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && BrownColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.BrownText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && PurpleColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.PurpleText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && LimeColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.LimeText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && PinkColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.PinkText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && AquaColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.AquaText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && WhiteColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.WhiteText, InputText.Text, (int)numericFontSize.Value));
            }
            else if (MyPictureBox.Image != null && BlackColor1.Checked)
            {
                MyPictureBox2.Image = (DrawText1(myImage, (int)numericHorizontal1.Value, (int)numericVertical1.Value, ColorChannel.BlackText, InputText.Text, (int)numericFontSize.Value));
            }
            WidthTextBox2.Text = myImage.Width.ToString(); //MyPictureBox2
            HeightTextBox2.Text = myImage.Height.ToString();
            VerticalTextBox2.Text = myImage.VerticalResolution.ToString();
            HorizontalTextBox2.Text = myImage.HorizontalResolution.ToString();
            MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;  //StretchImage  CenterImage
        }

        private void HorizontalBar1_Scroll(object sender, EventArgs e)
        {            
            numericHorizontal1.Value = HorizontalBar1.Value;
        }

        private void numericHorizontal1_ValueChanged(object sender, EventArgs e)
        {
            HorizontalBar1.Value = (int)numericHorizontal1.Value;
        }

        private void VerticalBar1_Scroll(object sender, EventArgs e)
        {
            numericVertical1.Value = VerticalBar1.Value;            
        }

        private void numericVertical1_ValueChanged(object sender, EventArgs e)
        {
            VerticalBar1.Value = (int)numericVertical1.Value;
        }     

        private void BrightnessMenu_Click(object sender, EventArgs e)
        {
            BrightnessBox.Visible = BrightnessMenu.Checked;
        }

        private void CustomMaskMenu_Click(object sender, EventArgs e)
        {
            CustomMaskBox.Visible = CustomMaskMenu.Checked;
        }

        private void SeparationMenu_Click(object sender, EventArgs e)
        {
            SeparationBox.Visible = SeparationMenu.Checked;
        }

        private void FilterButtonsMenu_Click(object sender, EventArgs e)
        {
            FilterButtonsBox.Visible = FilterButtonsMenu.Checked;
        }

        private void FiltersMenu_Click(object sender, EventArgs e)
        {
            FiltersBox.Visible = FiltersMenu.Checked;
        }

        private void TransformationsMenu_Click(object sender, EventArgs e)
        {
            TransformationsBox.Visible = TransformationsMenu.Checked;
        }

        private void DrawTextMenu_Click(object sender, EventArgs e)
        {
            DrawTextBox.Visible = DrawTextMenu.Checked;
        }


    }
}





