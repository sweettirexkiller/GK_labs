using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using octree_visual.Entities;

namespace octree_visual
{
    public partial class Form1 : Form
    {
        
        OctreeNode octreeRoot;
        public Form1()
        {
            InitializeComponent();
            // get lena_color image from images folder and set it as image of originalPictureBox
            string workingDirectory = Environment.CurrentDirectory;
            var projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = Path.Combine(projectDir, "octree_visual\\Images\\pallete.png");
            Image image = Image.FromFile(fileName);

            // resize image to pictureBox width and height 
            originalPictureBox.Image  = new Bitmap(image, originalPictureBox.Width, originalPictureBox.Height);
            reducedPictureBox.Image = new Bitmap(image, reducedPictureBox.Width, reducedPictureBox.Height);

            octreeRoot = new OctreeNode(7);
            octreePictureBox.Image = new Bitmap(octreePictureBox.Width, octreePictureBox.Height);
            octreeRoot.BuildOctree(image);
            
            originalNumberOfColors.Text = $"{octreeRoot.colorCount}";
            reducedNumberOfColors.Text = $"{octreeRoot.colorCount}";
            
            octreePictureBox.Refresh();
            originalPictureBox.Refresh();
            reducedPictureBox.Refresh();
            
        }

        private void octreePictureBox_Paint(object sender, PaintEventArgs e)
        {
            octreeRoot.DrawOctree(octreePictureBox);
        }

        private void loadPictureButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var workingDirectory = Environment.CurrentDirectory;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = workingDirectory;
            openFileDialog.Filter = @"png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                
                Image image = Image.FromFile(filePath);

                originalPictureBox.Image  = new Bitmap(image, originalPictureBox.Width, originalPictureBox.Height);
                reducedPictureBox.Image = new Bitmap(image, reducedPictureBox.Width, reducedPictureBox.Height);

                octreeRoot = new OctreeNode(7);
                octreePictureBox.Image = new Bitmap(octreePictureBox.Width, octreePictureBox.Height);
                octreeRoot.BuildOctree(image);



                originalNumberOfColors.Text = $"{octreeRoot.colorCount}";
                reducedNumberOfColors.Text = $"{octreeRoot.colorCount}";

             
                octreePictureBox.Refresh();
                originalPictureBox.Refresh();
                reducedPictureBox.Refresh();
                
                this.Refresh();
            }
        }

        private void reduceButton_Click(object sender, EventArgs e)
        {
            // modify recudedPictureBox image based on octree reduction
            // reduce octree
            
            int reduceBy = int.Parse(reduceNumber.Value.ToString());
            octreeRoot.ReduceOctree(reduceBy);
            octreeRoot.DrawOctree(octreePictureBox);
            
           
            
            // reduce image
            Image image = reducedPictureBox.Image;
            Bitmap bitmap = new Bitmap(image);
            Bitmap reducedBitmap = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j <image.Height; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);
                    Color reducedColor = octreeRoot.GetReducedColor(pixelColor);
                    reducedBitmap.SetPixel(i, j, reducedColor);
                }
            }
            
            // set reduced map as reducedPictureBox image
            reducedPictureBox.Image = reducedBitmap;
            reducedPictureBox.Refresh();
            reducedNumberOfColors.Text = $"{octreeRoot.colorCount}";
            this.Refresh();

            
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            // generate image with 8 rectanges with different colors
            Bitmap originalBitmap = new Bitmap(originalPictureBox.Width, originalPictureBox.Height);
            Bitmap reducedBitmap = new Bitmap(reducedPictureBox.Width, reducedPictureBox.Height);
            
            Put8Rectangles(originalPictureBox,originalBitmap);
            Put8Rectangles(reducedPictureBox, reducedBitmap);
            
            octreeRoot = new OctreeNode(7);
            octreeRoot.BuildOctree(originalPictureBox.Image);
            
            originalNumberOfColors.Text = $"{octreeRoot.colorCount}";
            reducedNumberOfColors.Text = $"{octreeRoot.colorCount}";
            this.Refresh();

        }
        
        private void Put8Rectangles(PictureBox pictureBox,Bitmap bitmap)
        {
            // generate original image
            for (int x = 0; x < pictureBox.Width; x++)
            {
                for (int y = 0; y < pictureBox.Height; y++)
                {
                    
                    if(y <= pictureBox.Height / 2) // upper rectangles
                    {
                        if (x <= pictureBox.Width / 4)
                        {
                            bitmap.SetPixel(x, y, Color.Red);
                        }
                        else if (x >= pictureBox.Width / 4 && x < 2*(pictureBox.Width / 4))
                        {
                            bitmap.SetPixel(x, y, Color.Green);
                        } else if(x >= 2* pictureBox.Width / 4 && x < 3 *(pictureBox.Width / 4))
                        {
                            bitmap.SetPixel(x, y, Color.Blue);
                        }
                        else
                        {
                            bitmap.SetPixel(x, y, Color.White);
                        }
                    }
                    else // lower rectangles
                    {
                        if (x < pictureBox.Width / 4)
                        {
                            bitmap.SetPixel(x, y, Color.Cyan);
                        }
                        else if (x > pictureBox.Width / 4 && x < 2*(pictureBox.Width / 4))
                        {
                            bitmap.SetPixel(x, y, Color.Magenta);
                        } else if(x > 2* pictureBox.Width / 4 && x < 3 *(pictureBox.Width / 4))
                        {
                            bitmap.SetPixel(x, y, Color.Yellow);
                        }
                        else
                        {
                            bitmap.SetPixel(x, y, Color.Black);
                        }
                    }

                }
            }
            
            pictureBox.Image = bitmap;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // generate bitmap with HSV colors
            Bitmap originalBitmap = new Bitmap(originalPictureBox.Width, originalPictureBox.Height);
            Bitmap reducedBitmap = new Bitmap(reducedPictureBox.Width, reducedPictureBox.Height);
            
            Bitmap image1 = PutHSVColors(originalPictureBox,originalBitmap);
            Bitmap image2 = PutHSVColors(reducedPictureBox, reducedBitmap);
            
            
            originalPictureBox.Image =  new Bitmap(image1, originalPictureBox.Width, originalPictureBox.Height);
            
            originalPictureBox.Refresh();
            reducedPictureBox.Refresh();
            
            
            
            octreeRoot = new OctreeNode(7);
            octreeRoot.BuildOctree(image1); 
            
            if(octreeRoot.colorCount > 10000)
                octreeRoot.ReduceOctree(10000);
            
                 
            octreeRoot.DrawOctree(octreePictureBox);
            
            octreePictureBox.Refresh();
            
            originalNumberOfColors.Text = $"{octreeRoot.colorCount}";
            reducedNumberOfColors.Text = $"{octreeRoot.colorCount}";
            
            
       
            
          
            this.Refresh();
            
        }

        private Bitmap PutHSVColors(PictureBox p0, Bitmap bm)
        {
            
            // Color color = new Color();
            // color = Color.FromArgb(255, 255, 0, 0);
            // int brightness = 255;
            // Bitmap bitmap = new Bitmap(255, 6*255);
            // for (int y = 0; y < 255; y++)
            // {
            //     for (int x = 0; x < 255 * 6; x++)
            //     {
            //         //Red 255 - Green 0-254
            //         if (color.R == brightness && color.G < brightness && color.B == 0)
            //         {
            //             // color.G += 1;
            //             color = Color.FromArgb(255, color.G + 1, color.R - 1, color.B);
            //             //color.R -= (byte)y;
            //             //color.G += (byte)y;
            //             //color.B += (byte)y;
            //         }
            //         //Green 255 - Red 255-0
            //         else if (color.R > 0 && color.G == brightness && color.B == 0)
            //         {
            //             // color.R -= 1;
            //             color = Color.FromArgb(255, color.G, color.R - 1, color.B);
            //             //color.R -= (byte)y;
            //             //color.G -= (byte)y;
            //             //color.B += (byte)y;
            //         }
            //         //Green 255 - Blue 0-255
            //         else if (color.R == 0 && color.G == brightness && color.B < brightness)
            //         {
            //             // color.B += 1;
            //             color = Color.FromArgb(255, color.G, color.R, color.B + 1);
            //
            //             //color.R += (byte)y;
            //             //color.G -= (byte)y;
            //             //color.B += (byte)y;
            //         }
            //         //Blue 255 - Green 255-0
            //         else if (color.R == 0 && color.G > 0 && color.B == brightness)
            //         {
            //             // color.G -= 1;
            //
            //             color = Color.FromArgb(255, color.G - 1, color.R, color.B);
            //             //color.R += (byte)y;
            //             //color.G -= (byte)y;
            //             //color.B -= (byte)y;
            //         }
            //         //Blue 255 - Red 0-255
            //         else if (color.R < brightness && color.G == 0 && color.B == brightness)
            //         {
            //             // color.R += 1;
            //             color = Color.FromArgb(255, color.G, color.R + 1, color.B);
            //             //color.R += (byte)y;
            //             //color.G += (byte)y;
            //             //color.B -= (byte)y;
            //         }
            //         //Red 255 - Blue 255-0
            //         else if (color.R == brightness && color.G == 0 && color.B > 0)
            //         {
            //             // color.B -= 1;
            //             color = Color.FromArgb(255, color.G, color.R, color.B - 1);
            //             //color.R -= (byte)y;
            //             //color.G += (byte)y;
            //             //color.B -= (byte)y;
            //         }
            //
            //         bm.SetPixel((int)x, (int)y, color);
            //     }

                    //brightness--;
            // }

            Bitmap image = new  Bitmap(240, 220);
            HSLColor hslColor = new HSLColor();
            System.Drawing.Color systemColor = new System.Drawing.Color();
            Color pixelcolor = new Color();
            
            pixelcolor = Color.Red;
            hslColor.SetRGB(pixelcolor.R, pixelcolor.G, pixelcolor.B);

            for (int y = 0; y < 220; y++)
            {
                // pixelcolor = Color.Red;
                // hslColor.SetRGB(pixelcolor.R, pixelcolor.G, pixelcolor.B);
                hslColor.Hue = 0;
                for (int x = 0; x < 240; x++)
                {
                    systemColor = hslColor;
                    pixelcolor = Color.FromArgb(systemColor.R, systemColor.G, systemColor.B);
                    image.SetPixel((int)x, (int)y, pixelcolor);
                    hslColor.Hue += 1;
                }
                hslColor.Saturation -= (y * 0.01);

            }
            
            // bm = new Bitmap(image, p0.Width, p0.Height);
            bm = new Bitmap(image, p0.Width, p0.Height);
            p0.Image = image;
            p0.Refresh();
            
            return bm;

        }
    
    
    }
}