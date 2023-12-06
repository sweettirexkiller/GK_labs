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

namespace octree_visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // get lena_color image from images folder and set it as image of originalPictureBox
            string workingDirectory = Environment.CurrentDirectory;
            var projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = Path.Combine(projectDir, "octree_visual\\Images\\lena_color32.png");
            Image image = Image.FromFile(fileName);

            originalPictureBox.Image = image;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}