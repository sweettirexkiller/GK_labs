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
            BresenhamAlg = false;
            LibraryAlg = false;
            SymetricBresenham = false;
            
        }
        
        #endregion
        
        #region Properties
        
        private enum Mode
        {
            Add,
            Catch,
            Move,
            Delete,
            None,
            CatchPolygon,
            MovePolygon,
            AddVerRestriction,
            RemoveVerRestriction,
            AddHorRestriction,
            RemoveHorRestriction,
            OffsetPolygonSelect,
            OffsetPolygonShow,
            LineSelect
            
        }

        private bool LibraryAlg;
        private bool BresenhamAlg;
        private bool SymetricBresenham;
        private List<Entities.Polygon> polygons = new List<Entities.Polygon>();
        private Entities.Point currentPoint;
        private Entities.Line currentLine;
        private Entities.Polygon currentPolygon;
        private Entities.PolygonPoint previouslyAddedPoint;
        private Entities.PolygonPoint movingPoint;
        private Polygon coughtPolygon;
        private Polygon offsetPolygon;
        private Polygon offsetedPolygon;
        private Polygon temporalMovingPolygon;
        private Vector3 movingPointBeginPosition;
        private Vector3 catchingPolygonBeginPosition;
        private Line selectedLine;
        private Mode mode;

        #endregion
        
        #region EditorForm_Load
        private void EditorForm_Load(object sender, EventArgs e)
        {
            mode = Mode.None;
            libraryAlgBtn.Checked = true;
            LibraryAlg = true;
            BresenhamAlg = false;
            SymetricBresenham = false;
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
                    
                    if (movingPoint.LineIn != null && movingPoint.LineIn.MustBeHorizontal)
                    {
                        movingPoint.LineIn.StartPoint.Position.Y = movingPoint.Position.Y;
                    } 
                    
                    if (movingPoint.LineOut != null && movingPoint.LineOut.MustBeHorizontal)
                    {
                        movingPoint.LineOut.EndPoint.Position.Y = movingPoint.Position.Y;
                    } 
                    
                    if (movingPoint.LineIn != null && movingPoint.LineIn.MustBeVertical)
                    {
                        
                        movingPoint.LineIn.StartPoint.Position.X = movingPoint.Position.X;
                    } 
                    
                    if (movingPoint.LineOut != null && movingPoint.LineOut.MustBeVertical)
                    {
                       
                        movingPoint.LineOut.EndPoint.Position.X = movingPoint.Position.X;
                    }
                    
                    
                    movingPoint.Position = currentPoint.Position;

                    
                    break;
                
                case Mode.MovePolygon:
                    
                    // move each point in temporalMovingPolygon by the same distance as mouse moved from the begining of catching   
                    Vector3 distance = new Vector3(currentPoint.Position.X - catchingPolygonBeginPosition.X, currentPoint.Position.Y - catchingPolygonBeginPosition.Y);
                    for(int i = 0; i < temporalMovingPolygon.Points.Count; i++)
                    {
                        temporalMovingPolygon.Points[i].Position.X = coughtPolygon.Points[i].Position.X + distance.X;
                        temporalMovingPolygon.Points[i].Position.Y = coughtPolygon.Points[i].Position.Y + distance.Y;
                    }
                    
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
                        if (currentPolygon.Points.Count == 0)
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
                    
                    case Mode.CatchPolygon:
                        
                        
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.PolygonPoint point in polygon.Points)
                            {
                                if (point.Position.DistanceTo(currentPoint.Position) < 2)
                                {
                                    catchingPolygonBeginPosition = currentPoint.Position;
                                    polygon.IsCought = true;
                                    coughtPolygon = polygon;
                                    break;
                                }
                            }

                            if (polygon.IsCought) break;
                            
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    catchingPolygonBeginPosition = currentPoint.Position;
                                    polygon.IsCought = true;
                                    coughtPolygon = polygon;
                                    break;
                                }
                            }
                            
                            if(polygon.IsCought) break;
                        }

                        if (coughtPolygon != null)
                        {
                            mode = Mode.MovePolygon;
                            temporalMovingPolygon = new Polygon();
                            // make a deep copy of coughtPolygon to temporalMovingPolygon
                            foreach (Entities.PolygonPoint point in coughtPolygon.Points)
                            {
                                temporalMovingPolygon.AddPoint(new PolygonPoint(temporalMovingPolygon, temporalMovingPolygon.Points.Count, new Vector3(point.Position.X, point.Position.Y)));
                            }
                            temporalMovingPolygon.Lines.Add(new Line(temporalMovingPolygon.Points[0], temporalMovingPolygon.Points.Last()));
                            
                            EditorPictureBox.Cursor = Cursors.SizeAll;
                        }

                        break;
                    
                    case Mode.MovePolygon:
                        
                        //move each point in coughtPolygin to position of temporalMovingPolygon points
                        for(int i = 0; i < coughtPolygon.Points.Count; i++)
                        {
                            coughtPolygon.Points[i].Position.X = temporalMovingPolygon.Points[i].Position.X;
                            coughtPolygon.Points[i].Position.Y = temporalMovingPolygon.Points[i].Position.Y;
                        }
                        
                        CancelAll();
                        break;
                    
                    case Mode.AddHorRestriction:
                        
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    //if lineOut or LineIn of startPoint or EndPoint is already set as mustBeHorizontal then do nothing
                                    if (line.StartPoint.LineOut != null && line.StartPoint.LineOut.MustBeHorizontal)
                                        break;
                                    else if (line.StartPoint.LineIn != null && line.StartPoint.LineIn.MustBeHorizontal)
                                        break;
                                    else if(line.EndPoint.LineOut != null && line.EndPoint.LineOut.MustBeHorizontal)
                                        break;
                                    else if (line.EndPoint.LineIn != null && line.EndPoint.LineOut.MustBeHorizontal)
                                        break;
                                    else
                                    {
                                        // add restriction to this line that is has to be Horizontal
                                        line.MustBeHorizontal = true;
                                        // change end point of this line to be on the same height as start point
                                        line.EndPoint.Position.Y = line.StartPoint.Position.Y;
                                        break;
                                    }
                                }
                            }
                        }

                        break;
                    
                    case Mode.AddVerRestriction:

                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    //if lineOut or LineIn of startPoint or EndPoint is already set as mustBeHorizontal then do nothing
                                    if (line.StartPoint.LineOut != null && line.StartPoint.LineOut.MustBeVertical)
                                        break;
                                    else if (line.StartPoint.LineIn != null && line.StartPoint.LineIn.MustBeVertical)
                                        break;
                                    else if(line.EndPoint.LineOut != null && line.EndPoint.LineOut.MustBeVertical)
                                        break;
                                    else if (line.EndPoint.LineIn != null && line.EndPoint.LineOut.MustBeVertical)
                                        break;
                                    else
                                    {
                                        // add restriction to this line that is has to be Horizontal
                                        line.MustBeVertical = true;
                                        // change end point of this line to be on the same height as start point
                                        line.EndPoint.Position.X = line.StartPoint.Position.X;
                                        break;
                                    }
                                }
                            }
                        }
                        
                        break;
                    
                    case Mode.RemoveVerRestriction:
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    line.MustBeVertical = false;
                                    break;
                                }
                            }
                        }
                        
                        break;
                    
                    case Mode.RemoveHorRestriction:
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    line.MustBeHorizontal = false;
                                    break;
                                }
                            }
                        }
                        break;
                    
                    case Mode.OffsetPolygonSelect:

                        bool selectedPolygon = false;
                         foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.PolygonPoint point in polygon.Points)
                            {
                                if (point.Position.DistanceTo(currentPoint.Position) < 2)
                                {
                                    offsetPolygon = polygon;
                                    selectedPolygon = true;
                                    break;
                                }
                            }

                            if (selectedPolygon) break;
                            
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    offsetPolygon = polygon;
                                    selectedPolygon = true;
                                    break;
                                }
                            }
                            
                            if(selectedPolygon) break;
                        }

                        if (selectedPolygon != null)
                        {
                            mode = Mode.OffsetPolygonShow;
                        }


                        break;
                    
                    case Mode.OffsetPolygonShow:
                        
                        offsetedPolygon = offsetPolygon.Offset(trackBar1.Value);

                        break;

                    
                    case Mode.LineSelect:
                        foreach (Entities.Polygon polygon in polygons)
                        {
                            foreach (Entities.Line line in polygon.Lines)
                            {
                                if (currentPoint.DistanceToLine(line) < 1)
                                {
                                    selectedLine = line;
                                    break;
                                }
                            }
                        }

                        if (selectedLine != null)
                        {
                            //open form to set line parameters
                            LineForm lineForm = new LineForm(ref selectedLine);
                            lineForm.ShowDialog();
                        }

                        break;
                    default:
                        
                        break;
                }

            }
            
        }
        
        #endregion
        
        #region Paint Picture box
        private void EditorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(PixelsToMillimeters(EditorPictureBox.Height));


            if (LibraryAlg)
            {
                 // if currentPolygon is not null draw current polygon
            if (currentPolygon != null)
            {
                foreach (Entities.PolygonPoint point in currentPolygon.Points)
                {
                    if(previouslyAddedPoint != null && point == previouslyAddedPoint && !currentPolygon.IsClosed)
                        e.Graphics.DrawPoint(new Pen(Color.DarkRed, 1), point);
                    else 
                        e.Graphics.DrawPoint(new Pen(Color.Black, 1), point);
                }
                
                foreach (Entities.Line line in currentPolygon.Lines)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray, 1), line);
                }

                if (currentLine != null && !currentPolygon.IsClosed)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gainsboro, 1), currentLine);
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
                            e.Graphics.DrawPoint(new Pen(Color.CornflowerBlue, 1), point);
                        else 
                            e.Graphics.DrawPoint(new Pen(Color.Black, 1), point);
                    }
                    
                    foreach (Entities.Line line in polygon.Lines)
                    {
                        if (line.MustBeHorizontal)
                        {
                            Pen pen = new Pen(Color.Red, 1);
                            pen.DashPattern = new float[] { 2, 2 };
                            e.Graphics.DrawLine(pen, line);
                        }
                        else if(line.MustBeVertical)
                        {
                            e.Graphics.DrawLine(new Pen(Color.Blue, 1), line);}
                        else
                        {
                            e.Graphics.DrawLine(new Pen(Color.Gray, 1), line);
                        }
                       
                    }
                    
                }
            }
            
                  
            //draw temporal moving polygon
            if (temporalMovingPolygon != null)
            {
                Pen dashedCyanPen = new Pen(Color.Pink, 1);
                dashedCyanPen.DashPattern = new float[] { 2, 2 };
                
                foreach (Entities.PolygonPoint point in temporalMovingPolygon.Points)
                {
                    e.Graphics.DrawPoint(dashedCyanPen, point);
                }
                    
                foreach (Entities.Line line in temporalMovingPolygon.Lines)
                {
                    e.Graphics.DrawLine(dashedCyanPen, line);
                }
            }

            if (offsetedPolygon != null)
            {
                Pen dashedCyanPen = new Pen(Color.Indigo, 0);
                dashedCyanPen.DashPattern = new float[] { 2, 2 };
                
                foreach (Entities.PolygonPoint point in offsetedPolygon.Points)
                {
                    e.Graphics.DrawPoint(dashedCyanPen, point);
                }
                    
                foreach (Entities.Line line in offsetedPolygon.Lines)
                {
                    e.Graphics.DrawLine(dashedCyanPen, line);
                }
            }
            }

            if (BresenhamAlg)
            {
                
                 // if currentPolygon is not null draw current polygon
            if (currentPolygon != null)
            {
                foreach (Entities.PolygonPoint point in currentPolygon.Points)
                {
                    if(previouslyAddedPoint != null && point == previouslyAddedPoint && !currentPolygon.IsClosed)
                        e.Graphics.DrawPoint(new Pen(Color.DarkRed, 1), point);
                    else 
                        e.Graphics.DrawPoint(new Pen(Color.Black, 1), point);
                }
                
                foreach (Entities.Line line in currentPolygon.Lines)
                {
                    e.Graphics.DrawLineBresenham(new Pen(Color.Gray, 1), line);
                }

                if (currentLine != null && !currentPolygon.IsClosed)
                {
                    e.Graphics.DrawLineBresenham(new Pen(Color.Gainsboro, 1), currentLine);
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
                            e.Graphics.DrawPoint(new Pen(Color.CornflowerBlue, 1), point);
                        else 
                            e.Graphics.DrawPoint(new Pen(Color.Black, 1), point);
                    }
                    
                    foreach (Entities.Line line in polygon.Lines)
                    {
                        if (line.MustBeHorizontal)
                        {
                            Pen pen = new Pen(Color.Red, 1);
                            pen.DashPattern = new float[] { 2, 2 };
                            e.Graphics.DrawLineBresenham(pen, line);
                        }
                        else if(line.MustBeVertical)
                        {
                            e.Graphics.DrawLineBresenham(new Pen(Color.Blue, 1), line);}
                        else
                        {
                            e.Graphics.DrawLineBresenham(new Pen(Color.Gray, 1), line);
                        }
                       
                    }
                    
                }
            }
            
                  
            //draw temporal moving polygon
            if (temporalMovingPolygon != null)
            {
                Pen dashedCyanPen = new Pen(Color.Pink, 1);
                dashedCyanPen.DashPattern = new float[] { 2, 2 };
                
                foreach (Entities.PolygonPoint point in temporalMovingPolygon.Points)
                {
                    e.Graphics.DrawPoint(dashedCyanPen, point);
                }
                    
                foreach (Entities.Line line in temporalMovingPolygon.Lines)
                {
                    e.Graphics.DrawLineBresenham(dashedCyanPen, line);
                }
            }

            if (offsetedPolygon != null)
            {
                Pen dashedCyanPen = new Pen(Color.Indigo, 0);
                dashedCyanPen.DashPattern = new float[] { 2, 2 };
                
                foreach (Entities.PolygonPoint point in offsetedPolygon.Points)
                {
                    e.Graphics.DrawPoint(dashedCyanPen, point);
                }
                    
                foreach (Entities.Line line in offsetedPolygon.Lines)
                {
                    e.Graphics.DrawLineBresenham(dashedCyanPen, line);
                }
            }
                
            }

            if (SymetricBresenham)
            {
                
            }
           
        }
        
        #endregion
        
        #region Add Polygon Click
        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            CancelAll();
            if (mode != Mode.Add)
            {
                mode = Mode.Add;
                EditorPictureBox.Cursor = Cursors.Cross;
                currentPolygon = new Polygon();
                addBtn.Checked = true;
            }
           
        }
        
        #endregion
        
        #region Cancel All

        private void CancelAll()
        {
            mode = Mode.None;
            EditorPictureBox.Cursor = Cursors.Default;
            if (movingPoint != null && mode == Mode.Move)
            {
                movingPoint.Position.X = movingPointBeginPosition.X;
                movingPoint.Position.Y = movingPointBeginPosition.Y;
                movingPointBeginPosition = null;
                movingPoint.IsMoving = false;
            }

            if (temporalMovingPolygon != null)
                temporalMovingPolygon = null;

            if (coughtPolygon != null)
            {
                coughtPolygon.IsCought = false;
                coughtPolygon = null;
            }

            // if (offsetPolygon != null)
            // {
            //     offsetPolygon = null;
            //     offsetedPolygon = null;
            // }
            //   
           
            currentLine = null;
            previouslyAddedPoint = null;
            currentPolygon = null;
            addBtn.Checked = false;
            catchBtn.Checked = false;
            removeBtn.Checked = false;
            catchPolygonBtn.Checked = false;
            addHRestrictionBtn.Checked = false;
            addVRestrictionBtn.Checked = false;
            removeHRestrictionBtn.Checked = false;
            removeVRestrictionBtn.Checked = false;
            ofsetBtn.Checked = false;
            thicknessChangeBtn.Checked = false;
            // trackBar1.Visible = false;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        #endregion

        #region Catch point

        private void catchBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
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
            CancelAll();
            if (mode != Mode.Delete)
            {
                mode = Mode.Delete;
                EditorPictureBox.Cursor = Cursors.No;
                removeBtn.Checked = true;
            }
        }

        #endregion

        #region Restrictions
        
        private void catchPolygonBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
            if (mode != Mode.CatchPolygon)
            {
                mode = Mode.CatchPolygon;
                EditorPictureBox.Cursor = Cursors.Hand;
                catchPolygonBtn.Checked = true;
            }
        }

        private void addHRestrictionBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
            addHRestrictionBtn.Checked = true;
            EditorPictureBox.Cursor = Cursors.Hand;
            mode = Mode.AddHorRestriction;
        }

        private void removeHRestrictionBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
            removeHRestrictionBtn.Checked = true;
            EditorPictureBox.Cursor = Cursors.No;
            mode = Mode.RemoveHorRestriction;
        }

        private void addVRestrictionBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
            addVRestrictionBtn.Checked = true;
            EditorPictureBox.Cursor = Cursors.Hand;

            mode = Mode.AddVerRestriction;
        }

        private void removeVRestrictionBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
            removeVRestrictionBtn.Checked = true;
            EditorPictureBox.Cursor = Cursors.No;
            mode = Mode.RemoveVerRestriction;
        }
        #endregion

        private void ofsetBtn_Click(object sender, EventArgs e)
        {
            // trackBar1.Visible = true;
            CancelAll();
            ofsetBtn.Checked = true;
            mode = Mode.OffsetPolygonSelect;
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            //change offset of offsetPolygon
            if (offsetPolygon != null)
            {
                offsetedPolygon = offsetPolygon.Offset(trackBar1.Value);
                offsetLabel.Text =  string.Format("Offset {0}", trackBar1.Value);
                EditorPictureBox.Refresh();
            }
        }

     

        private void bresenhamAlgBtn_CheckedChanged(object sender, EventArgs e)
        {
            BresenhamAlg = (bresenhamAlgBtn.Checked == true);
            EditorPictureBox.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SymetricBresenham = (radioButton1.Checked == true);
            EditorPictureBox.Refresh();
        }

        private void libraryAlgBtn_CheckedChanged(object sender, EventArgs e)
        {
            LibraryAlg = (libraryAlgBtn.Checked == true);
            EditorPictureBox.Refresh();
        }

        private void thicknessChangeBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void thicknessChangeBtn_Click_1(object sender, EventArgs e)
        {
            CancelAll();
            mode = Mode.LineSelect;
            EditorPictureBox.Cursor = Cursors.Hand;
            thicknessChangeBtn.Checked = true;
        }
    }
}