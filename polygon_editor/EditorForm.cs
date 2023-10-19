using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using polygon_editor.Entities;

namespace polygon_editor
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
            previouslyAddedPoint = null;
        }

        private List<Entities.Point> points = new List<Entities.Point>();
        // private List<Entities.Polygon> polygons = new List<Entities.Polygon>();
        private Vector3 currentPosition;
        private Entities.Point previouslyAddedPoint;
        private int DrawIndex = -1;
        private bool active_drawing = false;

        private void EditorForm_Load(object sender, EventArgs e)
        {
            
        }

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
            return new Vector3(PixelsToMillimeters(point.X), PixelsToMillimeters(EditorPictureBox.Height - point.Y));
        }
        
        

        private void EditorPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            MovingMouseLabel.Text = string.Format("Mouse Position: ({0}, {1})", e.Location.X, e.Location.Y);
            EditorPictureBox.Refresh();
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
                            if (previouslyAddedPoint != null)
                            {
                                previouslyAddedPoint = points.Last();
                                points.Add(new Entities.Point(currentPosition));
                            }
                            else
                            {
                                Entities.Point newPoint = new Entities.Point(currentPosition);
                                previouslyAddedPoint = newPoint;
                                points.Add(newPoint);
                            }

                            break;
                    }
                    EditorPictureBox.Refresh();
                }
            }
            
        }

        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            DrawIndex = 0;
            active_drawing = true;
            EditorPictureBox.Cursor = Cursors.Cross;
        }


        private void EditorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(PixelsToMillimeters(EditorPictureBox.Height));

            if (points.Count > 0)
            {
                foreach(Entities.Point p in points)
                {
                    e.Graphics.DrawPoint(new Pen(Color.Black, 0), p);
                }
            }

            if (previouslyAddedPoint != null)
            {
                e.Graphics.DrawLine(new Pen(Color.Gray, 0), (float)previouslyAddedPoint.Position.X, (float)previouslyAddedPoint.Position.Y , (float)currentPosition.X, (float)currentPosition.Y );
            }
        }
    }
}