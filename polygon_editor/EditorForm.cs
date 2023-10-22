using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using polygon_editor.Entities;
using Point = polygon_editor.Entities.Point;

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
        
        private enum Mode
        {
            Add,
            Catch,
            Move,
            Delete,
            None
        }
        
        private List<Entities.Polygon> polygons = new List<Entities.Polygon>();
        private Entities.Point currentPoint;
        private Entities.Line currentLine;
        private Entities.Polygon currentPolygon;
        private Entities.PolygonPoint previouslyAddedPoint;
        private Entities.PolygonPoint movingPoint;
        private Vector3 movingPointBeginPosition;
        private Mode mode;

        #endregion
        
        #region EditorForm_Load
        private void EditorForm_Load(object sender, EventArgs e)
        {
            mode = Mode.None;
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
            currentPoint = new Point(PointToCartesian(e.Location));
            coordinate.Text = string.Format("({0}, {1})", e.Location.X, e.Location.Y);

            switch (mode)
            {
                case Mode.Add:
                    if (previouslyAddedPoint != null)
                    {
                        currentLine = new Line(previouslyAddedPoint, new PolygonPoint(null, -1,currentPoint.Position));
                    }
                    break;
                
                case Mode.Move:
                    movingPoint.Position = currentPoint.Position;
                    break;
                
            }
           
            EditorPictureBox.Refresh();
        }
        
        #endregion

        #region MouseDown
        
        private void EditorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (mode)
                {
                    case Mode.None:


                        break;
                    
                    
                    case Mode.Add:
                        //if distance of current position from a line is less than 1.5 mm then add vertice to the line
                        if (currentPolygon == null)
                        {
                            #region Add Point On the existing Line
                            
                                bool addPointOnTheLine = false;
                                Line thisLine = null;
                                Polygon thisPolygon = null;
                                foreach (Entities.Polygon polygon in polygons)
                                {
                                    foreach (Entities.Line line in polygon.Lines)
                                    {
                                        if (currentPoint.DistanceToLine(line) < 1)
                                        {
                                            addPointOnTheLine = true;
                                            thisLine = line;
                                            thisPolygon = polygon;
                                        }
                                    }
                                }
                                
                                if (addPointOnTheLine && thisLine != null && thisPolygon != null)
                                {
                                        
                                    PolygonPoint end = thisLine.EndPoint;
                                    PolygonPoint start = thisLine.StartPoint;
                                    PolygonPoint middle = new PolygonPoint(thisPolygon, thisPolygon.Points.Count, currentPoint.Position);
                                    Line newIn = new Line(start, middle);
                                    Line newOut = new Line(middle, end);
                                    middle.LineIn = newIn;
                                    middle.LineOut = newOut;
                                    start.LineOut = newIn;
                                    end.LineIn = newOut;
                                    thisPolygon.Lines.Add(newIn);
                                    thisPolygon.Lines.Add(newOut);
                                    thisPolygon.Lines.Remove(thisLine);
                                    thisPolygon.Points.Add(middle);
                                  
                                    break;
                                }
                                
                            #endregion

                        }
                       

                        currentPolygon.AddPoint(new Entities.PolygonPoint(currentPolygon,currentPolygon.Points.Count, currentPoint.Position));
                        previouslyAddedPoint = currentPolygon.Points.Last();

                        if (currentPolygon.IsClosed)
                        {
                            polygons.Add(currentPolygon);
                            CancelAll();
                        }
                    
                        EditorPictureBox.Refresh();
                        break;
                    
                    
                    case Mode.Catch:
                        
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.PolygonPoint point in polygon.Points)
                            {
                                if (point.Position.DistanceTo(currentPoint.Position) < 2)
                                {
                                    mode = Mode.Move;
                                    movingPoint = point;
                                    movingPointBeginPosition = point.Position;
                                    movingPoint.IsMoving = true;
                                }
                            }
                        }
                        
                        
                        break;  
                    
                    case Mode.Move:
                        movingPoint.Position = currentPoint.Position;
                        movingPoint.IsMoving = false;
                        mode = Mode.None;
                        CancelAll();

                        break;
                    case Mode.Delete:
                        List<Entities.Polygon> polygonsToRemove = new List<Entities.Polygon>();
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.PolygonPoint point in polygon.Points)
                            {
                                if (point.Position.DistanceTo(currentPoint.Position) < 2)
                                {
                                    
                                    polygon.RemovePoint(point);
                                    if(polygon.Points.Count <3)
                                        polygonsToRemove.Add(polygon);

                                    mode = Mode.None;
                                    CancelAll();
                                    break;
                                }
                            }
                        }
                        
                        foreach (Entities.Polygon polygon in polygonsToRemove)
                        {
                            polygons.Remove(polygon);
                        }

                        break;
                    default:
                        break;
                }

            }
            
        }
        
        #endregion

        #region Add Polygon Click
        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            if (mode != Mode.Add)
            {
                mode = Mode.Add;
                EditorPictureBox.Cursor = Cursors.Cross;
                currentPolygon = new Polygon();
                addBtn.Checked = true;
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
                        if(point.IsMoving)
                            e.Graphics.DrawPoint(new Pen(Color.Blue, 1), point);
                        else 
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

        #region Cancel All

        private void CancelAll()
        {
            
            EditorPictureBox.Cursor = Cursors.Default;
            if (movingPoint != null && mode == Mode.Move)
            {
                movingPoint.Position.X = movingPointBeginPosition.X;
                movingPoint.Position.Y = movingPointBeginPosition.Y;
                movingPointBeginPosition = null;
                movingPoint.IsMoving = false;
            }
           
            currentLine = null;
            previouslyAddedPoint = null;
            currentPolygon = null;
            addBtn.Checked = false;
            catchBtn.Checked = false;
            removeBtn.Checked = false;
            mode = Mode.None;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        #endregion

        #region Catch

        private void catchBtn_Click(object sender, EventArgs e)
        {
            if (mode != Mode.Catch)
            {
                mode = Mode.Catch;
                EditorPictureBox.Cursor = Cursors.Hand;
                catchBtn.Checked = true;
            } 
         
        }

        #endregion


        #region Delete Click

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (mode != Mode.Delete)
            {
                mode = Mode.Delete;
                EditorPictureBox.Cursor = Cursors.No;
                removeBtn.Checked = true;
            }
        }

        #endregion
    }
}