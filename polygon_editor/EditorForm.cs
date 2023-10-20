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
        
        private List<Entities.Polygon> polygons = new List<Entities.Polygon>();
        private Vector3 currentPosition;
        private Entities.Line currentLine;
        private Entities.Point previouslyAddedPoint;
        private bool is_adding_polygon = false;

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
            if (previouslyAddedPoint != null)
            {
                currentLine = new Line(previouslyAddedPoint.Position, currentPosition);
            }
            EditorPictureBox.Refresh();
        }

        private void EditorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (is_adding_polygon)
                {
                    Polygon currentPolygon = polygons.Last();
                    currentPolygon.AddPoint(new Entities.PolygonPoint(currentPolygon,currentPolygon.Points.Count, currentPosition));
                    previouslyAddedPoint = currentPolygon.Points.Last();

                    if (currentPolygon.IsClosed)
                    {
                        currentLine = null;
                        is_adding_polygon = false;
                        EditorPictureBox.Cursor = Cursors.Default;
                        previouslyAddedPoint = null;
                    }
                    
                    EditorPictureBox.Refresh();
                }
            }
            
        }

        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            is_adding_polygon = true;
            EditorPictureBox.Cursor = Cursors.Cross;
            Polygon newPolygon = new Polygon();
            polygons.Add(newPolygon);
        }


        private void EditorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(PixelsToMillimeters(EditorPictureBox.Height));

            if (polygons.Count > 0)
            {
                //for each polygon draw points and lines
                foreach (Entities.Polygon polygon in polygons)
                {
                    foreach(Entities.PolygonPoint point in polygon.Points)
                    {
                        if(previouslyAddedPoint != null && point == previouslyAddedPoint && !polygon.IsClosed)
                            e.Graphics.DrawPoint(new Pen(Color.Red, 0), point);
                        else
                            e.Graphics.DrawPoint(new Pen(Color.Black, 0), point);
                    }
                    
                    foreach (Entities.Line line in polygon.Lines)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Gray, 0), line);
                    }

                    if (currentLine != null && !polygon.IsClosed)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Gainsboro, 0), currentLine);
                    }
                }
                
            }
        }
    }
}