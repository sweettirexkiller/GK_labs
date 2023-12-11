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
    }
}