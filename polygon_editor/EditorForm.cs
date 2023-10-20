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
        
        #region Form Load
        public EditorForm()
        {
            InitializeComponent();
            previouslyAddedPoint = null;
        }
        
        #endregion
        
        #region Properties
        private List<Entities.Polygon> polygons = new List<Entities.Polygon>();
        private Vector3 currentPosition;
        private Entities.Line currentLine;
        private Entities.Polygon currentPolygon;
        private Entities.Point previouslyAddedPoint;
        private bool is_adding_polygon = false;
        #endregion
        
        #region EditorForm_Load
        private void EditorForm_Load(object sender, EventArgs e)
        {
            
        }
        
        #endregion

        #region dots per inch
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
        
        #endregion

        #region convert pixels to millimeters
        private float PixelsToMillimeters(float pixels)
        {
            return pixels * 25.4f / DPI;
        }
        
        
        #endregion
        
        #region convert system point to world point
        private Vector3 PointToCartesian(System.Drawing.Point point)
        {
            return new Vector3(PixelsToMillimeters(point.X), PixelsToMillimeters(EditorPictureBox.Height - point.Y));
        }
        
        #endregion

        #region MouseMove
        private void EditorPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            coordinate.Text = string.Format("({0}, {1})", e.Location.X, e.Location.Y);
            if (previouslyAddedPoint != null)
            {
                currentLine = new Line(previouslyAddedPoint.Position, currentPosition);
            }
            EditorPictureBox.Refresh();
        }
        
        #endregion

        #region MouseDown
        
        private void EditorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (is_adding_polygon)
                {
                    currentPolygon.AddPoint(new Entities.PolygonPoint(currentPolygon,currentPolygon.Points.Count, currentPosition));
                    previouslyAddedPoint = currentPolygon.Points.Last();

                    if (currentPolygon.IsClosed)
                    {
                        currentLine = null;
                        polygons.Add(currentPolygon);
                        currentPolygon = null;
                        is_adding_polygon = false;
                        EditorPictureBox.Cursor = Cursors.Default;
                        previouslyAddedPoint = null;
                    }
                    
                    EditorPictureBox.Refresh();
                }
            }
            
        }
        
        #endregion

        #region Add Polygon Click
        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            if (!is_adding_polygon)
            {
                is_adding_polygon = true;
                EditorPictureBox.Cursor = Cursors.Cross;
                currentPolygon = new Polygon();
            }
           
        }
        
        #endregion


        #region Paint Picture box
        private void EditorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(PixelsToMillimeters(EditorPictureBox.Height));
            
            // if currentPolygon is not null draw current polygon
            if (currentPolygon != null)
            {
                foreach (Entities.PolygonPoint point in currentPolygon.Points)
                {
                    if(previouslyAddedPoint != null && point == previouslyAddedPoint && !currentPolygon.IsClosed)
                        e.Graphics.DrawPoint(new Pen(Color.Red, 0), point);
                    else
                        e.Graphics.DrawPoint(new Pen(Color.Black, 0), point);
                }
                
                foreach (Entities.Line line in currentPolygon.Lines)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray, 0), line);
                }

                if (currentLine != null && !currentPolygon.IsClosed)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gainsboro, 0), currentLine);
                }
            }

            if (polygons.Count > 0)
            {
                //for each polygon draw points and lines
                foreach (Entities.Polygon polygon in polygons)
                {
                    foreach(Entities.PolygonPoint point in polygon.Points)
                    {
                        e.Graphics.DrawPoint(new Pen(Color.Black, 0), point);
                    }
                    
                    foreach (Entities.Line line in polygon.Lines)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Gray, 0), line);
                    }
                    
                }
                
            }
        }
        
        #endregion

        private void CancelAll()
        {
            is_adding_polygon = false;
            EditorPictureBox.Cursor = Cursors.Default;
            currentLine = null;
            previouslyAddedPoint = null;
            currentPolygon = null;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
    }
}