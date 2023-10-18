using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polygon_editor
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }
        
        private List<Entities.Point> points = new List<Entities.Point>();
        private Vector3 currentPosition;
        private int DrawIndex = -1;
        private bool active_drawing = false;

        // dots per inch
        private float DPI 
        {
            get
            {
                using (var g = CreateGraphics())
                {
                    return g.DpiX;
                }
            }
        }
        
        // convert pixels to millimeters
        private float PixelsToMillimeters(float pixels)
        {
            return pixels * 25.4f / DPI;
        }
        
        //convert system point to world point
        private Vector3 PointToCartesian(System.Drawing.Point point)
        {
            return new Vector3(PixelsToMillimeters(point.X), PixelsToMillimeters(point.Y));
        }
        
        

        private void EditorPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            MovingMouseLabel.Text = string.Format("({0}, {1})", e.Location.X, e.Location.Y);
        }

        private void EditorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (active_drawing)
                {
                    switch (DrawIndex)
                    {
                        case 0:
                            points.Add(new Entities.Point(currentPosition));
                            break;
                            break;
                    }
                    EditorPictureBox.Refresh();
                }
            }
            
        }
    }
}