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
            string fileName = Path.Combine(projectDir, "octree_visual\\Images\\circle.jpg");
            Image image = Image.FromFile(fileName);

            // resize image to pictureBox width and height 
            Bitmap bitmap = new Bitmap(image, originalPictureBox.Width, originalPictureBox.Height);

            originalPictureBox.Image = bitmap;
            
            octreeRoot = new OctreeNode(7);

            octreePictureBox.Image = new Bitmap(octreePictureBox.Width, octreePictureBox.Height);
            octreeRoot.BuildOctree(image);
            
         

            int cnt = CountColors(bitmap);

            numberOfColors.Text = $"{cnt}";
            
            // octreePictureBox.Refresh();
        }

        private static unsafe int CountColors(Bitmap bmp)
        {
            // get the dimensions of the bitmap image
            int width = bmp.Width;
            int height = bmp.Height;
            // lock the bitmap in system memory
            var rect = new Rectangle(0, 0, width, height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            // create a hashset to store unique integer values
            var colors = new HashSet<int>();
            // get the address of the first pixel data in unmanaged memory
            var bmpPtr = (int*)bmpData.Scan0;
            // loop through the pixel data
            for (int i = 0; i < width * height; i++)
            {
                // add the 32-bit value to the hashset
                colors.Add(bmpPtr[0]);
                // move the pointer by 4 bytes
                bmpPtr++;
            }
            // unlock the bitmap from system memory
            bmp.UnlockBits(bmpData);
            // return the unique color count
            return colors.Count;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void octreePictureBox_Paint(object sender, PaintEventArgs e)
        {
            // draw octree on pictureBox
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

                // resize image to pictureBox width and height 
                Bitmap bitmap = new Bitmap(image, originalPictureBox.Width, originalPictureBox.Height);

                originalPictureBox.Image = bitmap;
            
                octreeRoot = new OctreeNode(7);

                octreePictureBox.Image = new Bitmap(octreePictureBox.Width, octreePictureBox.Height);
                octreeRoot.BuildOctree(image);
                
                int cnt = CountColors(bitmap);

                
                numberOfColors.Text = $"{cnt}";
             
            }
        }
    }
}