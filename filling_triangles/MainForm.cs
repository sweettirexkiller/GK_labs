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
        private bool _isFill;
        private bool _isMeshVisible;
        private Drawing _drawing;
        private TriangleMesh _triangleMesh;
        private Configuration _config;
        public MainForm()
        {
            string workingDirectory = Environment.CurrentDirectory;
            
            _projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            _isFill = false;
            _isMeshVisible = true;
            
            
            InitializeComponent();
            pictureBox.CreateGraphics(); 
            
            _config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            _triangleMesh = new TriangleMesh((int)this.columnCountX.Value, (int)this.columnCountY.Value,
                pictureBox.Width, pictureBox.Height);
            _drawing = new Drawing(pictureBox, _triangleMesh);
         
            

            // _scene.AdjustSizes();
            _myTimer.Tick += _drawing.DrawOnBitmap;
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
                _myTimer.Start();
            }
              
        }
    }
}