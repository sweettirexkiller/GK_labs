using System.Collections.Generic;
using System.Linq;

namespace polygon_editor.Entities
{
    public class Polygon
    {
        private List<PolygonPoint> points;
        private List<Line> lines;
        private bool isClosed;
        private bool isCought;

        //constructor
        public Polygon()
        {
            Points = new List<PolygonPoint>();
            Lines = new List<Line>();
            IsClosed = false;
            IsCought = false;
            
        }

        public void AddPoint(PolygonPoint point)
        {

            PolygonPoint lastPoint = null;
            if (Points.Count > 0)
            {
               lastPoint = this.Points.Last();
            }
            
          
            // if this.points.Count >= 3 and current point is close to first point then set isClosed to true
            if (this.Points.Count >= 3 && point.Position.DistanceTo(this.Points[0].Position) < 2)
            {
                this.IsClosed = true;
                Line line = new Line(lastPoint, Points[0]);
                lastPoint.LineOut = line;
                Points[0].LineIn = line;
                this.AddLine(line);
                return;
            }
            else
            {
                points.Add(point);
            }
            
            PolygonPoint newPoint = this.Points.Last();
            
            if(lastPoint != null)
            {
                Line line = new Line(lastPoint, newPoint);
                lastPoint.LineOut = line;
                newPoint.LineIn = line;
                this.AddLine(line);
            }

        }
        
        //Remove point public function
        public void RemovePoint(PolygonPoint point)
        {
            if (points.Count <= 3)
            {
                this.Points.Remove(point);
                return;
            }
            else
            {
                PolygonPoint outEndPoint = point.LineOut.EndPoint;
                PolygonPoint inStartPoint = point.LineIn.StartPoint;
                Line line = new Line(inStartPoint, outEndPoint);
                Lines.Add(line);
                outEndPoint.LineIn = line;
                inStartPoint.LineOut = line;


                Lines.Remove(point.LineOut);
                Lines.Remove(point.LineIn);
                Points.Remove(point);
            }
        }
        
        
        

        public void AddLine(Line line)
        {
            lines.Add(line);
        }
        
        //setter and getter points
        public List<PolygonPoint> Points
        {
            get { return points; }
            set { points = value; }
        }
        
        //setter and getter is_cought
        public bool IsCought
        {
            get { return isCought; }
            set { isCought = value; }
        }
        
        //setter and getter lines
        public List<Line> Lines
        {
            get { return lines; }
            set { lines = value; }
        }
        
        //setter and getter is_closed
        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }
        
        
    
    }
}