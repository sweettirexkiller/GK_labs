using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using filling_triangles.Geometry;
using filling_triangles.Graphics;

namespace filling_triangles
{
    public partial class MainForm : Form
    {
        static System.Windows.Forms.Timer _myTimer = new System.Windows.Forms.Timer();
        private readonly string _projectDir;

        private bool _isMeshVisible;
        private Color _objectColor;

        private Painter _painter;
        private TriangleMesh _triangleMesh;
        private Configuration _config;
        private Color _lightColor;
        private Lamp _lamp;

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
            
            _lamp  = new Lamp(new Point3D(0, 0, 500), Color.White, new Point(_triangleMesh.Width / 2, _triangleMesh.Height / 2), _triangleMesh._xSpan / 2);
            
          

            
            _painter = new Painter(pictureBox, _triangleMesh, _lamp);



            // _scene.AdjustSizes();
            _myTimer.Tick += _painter.StartDrawing;
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
                chosenColorPanel.BackColor = colorDialog1.Color;
                _triangleMesh.IsColorFilled = true;
                _objectColor = pickedColorRadioButton.Checked ? chosenColorPanel.BackColor : Color.White;
                _triangleMesh.ObjectColor = _objectColor;
                if (_triangleMesh.IsColorFilled)
                {
                    _triangleMesh.SetTexture(_objectColor);
                }
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
            if (_triangleMesh.IsColorFilled)
            {
                _triangleMesh.SetTexture(_objectColor);
            }
            

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
                panel1.BackgroundImage = image;
            }
            else
            {
                panel1.BackgroundImage = null;
                _triangleMesh.IsColorFilled = true;
                _triangleMesh.IsTextureFilled = false;
                pickedColorRadioButton.Checked = true;
                imageRadioButton.Checked = false;
            }

            _myTimer.Start();
        }

        private void imageRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            // change scene values
            // change chosenColorPanel backgroundcolor
            _triangleMesh.IsTextureFilled = imageRadioButton.Checked;
            _triangleMesh.IsColorFilled = !imageRadioButton.Checked;

            if (_triangleMesh.Image == null&& imageRadioButton.Checked)
            {
                var filePath = string.Empty;
                var workingDirectory = Environment.CurrentDirectory;
                var imagesDirectory = Path.Combine(_projectDir, "Images");

                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = imagesDirectory;
                openFileDialog.Filter = @"png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                _myTimer.Stop();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    var image = Image.FromFile(filePath);
                    _triangleMesh.Image = image;
                    _triangleMesh.SetTexture(new Bitmap(image));
                    panel1.BackgroundImage = image;
                }
                else
                {
                    _triangleMesh._textureBitmap = null;
                    _triangleMesh.IsColorFilled = true;
                    _triangleMesh.IsTextureFilled = false;
                    pickedColorRadioButton.Checked = true;
                    imageRadioButton.Checked = false;
                    panel1.BackgroundImage = null;
                }

                _myTimer.Start();
            }
            else if(imageRadioButton.Checked)
            {
                _myTimer.Stop();
                _triangleMesh.SetTexture(new Bitmap(_triangleMesh.Image));
                _myTimer.Start();
            }


        }

        private void normalMapFileButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var workingDirectory = Environment.CurrentDirectory;
            var mapsDirectory = Path.Combine(_projectDir, "NormalMaps");

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = mapsDirectory;
            openFileDialog.Filter = @"jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|tif files (*.tif)|*.tif";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            _myTimer.Stop();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                var image = Image.FromFile(filePath);
                _triangleMesh.SetNormalMap(new Bitmap(image));
                _triangleMesh.IsNormalMap = true;
                constantVectorRadioButton.Checked = false;
                heightMapFromFileRadioButton.Checked = true;
                panel2.BackgroundImage = image;
            }
            else
            {
                _triangleMesh._normalBitMap = null;
                _triangleMesh.IsNormalMap = false;
                panel2.BackgroundImage = null;
                heightMapFromFileRadioButton.Checked = true;
            }

            _myTimer.Start();
        }

        private void constantVectorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            // change chosenColorPanel backgroundcolor
            _triangleMesh.IsNormalMap = !constantVectorRadioButton.Checked;
            _triangleMesh.IsConstantNormalVector = constantVectorRadioButton.Checked;
            _myTimer.Start();
        }

        private void heightMapFromFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            // change chosenColorPanel backgroundcolor
            _triangleMesh.IsNormalMap = heightMapFromFileRadioButton.Checked;
            _triangleMesh.IsConstantNormalVector = !heightMapFromFileRadioButton.Checked;


            if (_triangleMesh._normalBitMap == null)
            {
                var filePath = string.Empty;
                var workingDirectory = Environment.CurrentDirectory;
                var imagesDirectory = Path.Combine(_projectDir, "NormalMaps");

                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = imagesDirectory;
                openFileDialog.Filter = @"jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|tif files (*.tif)|*.tif";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                _myTimer.Stop();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    var image = Image.FromFile(filePath);
                    _triangleMesh.SetNormalMap(new Bitmap(image));
                    panel2.BackgroundImage = image;
                }
                else
                {
                    _triangleMesh._normalBitMap = null;
                    _triangleMesh.IsNormalMap = false;
                    panel2.BackgroundImage = null;
                    heightMapFromFileRadioButton.Checked = false;
                    constantVectorRadioButton.Checked = true;
                    _triangleMesh.IsConstantNormalVector = true;
                }

                _myTimer.Start();
            }

            _myTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _myTimer.Stop();
                // change scene values
                lightColorPanel.BackColor = colorDialog1.Color;
                _lightColor = lightColorPanel.BackColor;
                _lamp.Color = (_lightColor.R/255.0, _lightColor.G/255.0, _lightColor.B/2555.0);;
                _triangleMesh.LightColor = _lightColor;
                _myTimer.Start();
            }
        }

        private void interpolatedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            _triangleMesh.IsColorInterpolated = interpolatedCheckbox.Checked;
            _myTimer.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            _triangleMesh.IsLightConstant = constantLightVectorRadioButton.Checked;
            _lamp.IsConstant = constantLightVectorRadioButton.Checked;
            
            if(_lamp.IsConstant)
                _lamp.Position = new Point3D(0, 0, 500);
            
            _myTimer.Start();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            _triangleMesh.IsLightAnimated = animatedLightVectorRadioButton.Checked;
            _lamp.IsAnimated = animatedLightVectorRadioButton.Checked;
            _myTimer.Start();
            
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            _triangleMesh.Surface.M = mTrackBar.Value;
            mLabel.Text = mTrackBar.Value.ToString();
            _myTimer.Start();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // change scene values
            _triangleMesh.Surface.Ks = ksTrackBar.Value/10.0;
            ksLabel.Text = (ksTrackBar.Value/10.0).ToString();
            _myTimer.Start();
        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {  
            _myTimer.Stop();
            _triangleMesh.Surface.Kd = kdTrackBar.Value/10.0;
            kdLabel.Text = (kdTrackBar.Value/10.0).ToString();
            _myTimer.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // functional z instead of bezier 
            _myTimer.Stop();
            _triangleMesh.IsFunctionalZ = checkBox1.Checked;
            _triangleMesh.GenerateTriangles();
            _myTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _myTimer.Stop();
            _triangleMesh.ShouldRotateOnce = true;
            // _triangleMesh.GenerateTriangles();
            _myTimer.Start();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            _triangleMesh.AlfaForZRotation = (((double)numericUpDown1.Value)/180.0) * (Math.PI);
            _myTimer.Start();
        }

        private void betaUpDown_ValueChanged(object sender, EventArgs e)
        {
            _myTimer.Stop();
            // angel to radian
            _triangleMesh.BetaForXRotation = (((double)betaUpDown.Value)/180.0) * (Math.PI);
            _myTimer.Start();
        }

        private void MainForm_ResizeBegin_1(object sender, EventArgs e)
        {
            _myTimer.Stop();
            _triangleMesh.GenerateTriangles();
            _myTimer.Start();
        }

      
    }
}