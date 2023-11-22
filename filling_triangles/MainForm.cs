using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using filling_triangles.Graphics;

namespace filling_triangles
{
    public partial class MainForm : Form
    {
        static System.Windows.Forms.Timer _myTimer = new System.Windows.Forms.Timer();
        private readonly string _projectDir;
        
        private bool _isMeshVisible;
        private Color _objectColor;
        
        private Drawing _drawing;
        private TriangleMesh _triangleMesh;
        private Configuration _config;
        public MainForm()
        {
            string workingDirectory = Environment.CurrentDirectory;

            _projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            _isMeshVisible = true;
            _objectColor = Color.White;
            
            InitializeComponent();
            pictureBox.CreateGraphics(); 
            
            _config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            _triangleMesh = new TriangleMesh((int)this.columnCountX.Value, (int)this.columnCountY.Value,
                pictureBox.Width, pictureBox.Height, _objectColor);
            _drawing = new Drawing(pictureBox, _triangleMesh);
         
            

            // _scene.AdjustSizes();
            _myTimer.Tick += _drawing.StartDrawing;
            _myTimer.Interval = 500;
            _myTimer.Start();
        }

        private void columnCountX_ValueChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            
            // change triangles in scene
            _triangleMesh.ColumnsCountX = (int)columnCountX.Value;
            _triangleMesh.RowsCountY = (int)columnCountY.Value;
            _triangleMesh.GenerateTriangles();
            
            _myTimer.Start();
        }

        private void columnCountY_ValueChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change triangles in scene
            _triangleMesh.ColumnsCountX = (int)columnCountX.Value;
            _triangleMesh.RowsCountY = (int)columnCountY.Value;
            _triangleMesh.GenerateTriangles();
            _myTimer.Start();
        }

        private void triangleMeshVisibilityButton_Click(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change triangles in scene
            _isMeshVisible = !_isMeshVisible;
            _triangleMesh.IsMeshVisible = _isMeshVisible;
            
            //change button text
            triangleMeshVisibilityButton.Text = _isMeshVisible ? "Hide" : "Show";
            _myTimer.Start();
          
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            // Update the text box color if the user clicks OK 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _myTimer.Stop();
                // change scene values
                // change chosenColorPanel backgroundcolor
                chosenColorPanel.BackColor =  colorDialog1.Color;
                _objectColor = pickedColorRadioButton.Checked ? chosenColorPanel.BackColor : Color.White;
                _triangleMesh.ObjectColor = _objectColor;
                _myTimer.Start();
            }
              
        }

        private void pickedColorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            // change chosenColorPanel backgroundcolor
            _triangleMesh.IsColorFilled = pickedColorRadioButton.Checked;
            _triangleMesh.IsTextureFilled = !pickedColorRadioButton.Checked;
            
            _myTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var workingDirectory = Environment.CurrentDirectory;
            var imagesDirectory = Path.Combine(_projectDir, "Images");

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = workingDirectory;
            openFileDialog.Filter = @"png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
 
            _myTimer.Stop();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                var image = Image.FromFile(filePath);
                _triangleMesh.SetTexture(new Bitmap(image));
            }else
            {
                _triangleMesh.IsColorFilled = true;
                _triangleMesh.IsTextureFilled = false;
                pickedColorRadioButton.Checked = true;
                imageRadioButton.Checked = false;
            }
            _myTimer.Start();
        }

        private void imageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            // change chosenColorPanel backgroundcolor
            _triangleMesh.IsTextureFilled = imageRadioButton.Checked;
            _triangleMesh.IsColorFilled = !imageRadioButton.Checked;
            
            if(_triangleMesh._textureBitmap == null)
            {
                var filePath = string.Empty;
                var workingDirectory = Environment.CurrentDirectory;
                var imagesDirectory = Path.Combine(_projectDir, "Images");

                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = imagesDirectory;
                openFileDialog.Filter = @"png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    var image = Image.FromFile(filePath);
                    _triangleMesh.SetTexture(new Bitmap(image));
                }else
                {
                    _triangleMesh.IsColorFilled = true;
                    _triangleMesh.IsTextureFilled = false;
                    pickedColorRadioButton.Checked = true;
                    imageRadioButton.Checked = false;
                }
               
            }
            
            _myTimer.Start();
        }
    }
}