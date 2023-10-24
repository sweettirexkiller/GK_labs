using System;
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

            if (lastPoint != null)
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

        public Polygon Offset(double offsetValue)
        {
            List<PolygonPoint> newPoints = new List<PolygonPoint>();
            List<Line> newLines = new List<Line>();
            Polygon offsetPolygon = new Polygon();


            double angle;

            for (int i = 0; i < this.Points.Count; i++)
            {
                //find center of a polygon
                Vector3 center = this.Center();
                
                int next = (i == 0) ? this.Points.Count - 1 : i - 1;
                Line l1 = new Line(this.Points[i].Copy(), this.Points[next].Copy());
                angle = l1.Angle();

                bool flg = l1.DeterminePointOfLine(center) > 0 ? true : false;
                
               if (flg) //if center of a polygon is under the line then add 90
               {
                   angle = angle-90.0;
               }
               else // if center of a polygon is over the line then subtract 90
               {
                   angle = angle+90.0;
               }

                Vector3 start = l1.StartPoint.Position.Transfer2D(offsetValue, angle);
                Vector3 end = l1.EndPoint.Position.Transfer2D(offsetValue, angle);
                newLines.Add(new Line(new PolygonPoint(offsetPolygon , -1, start), new PolygonPoint(offsetPolygon, -1, end)));
            }
            
            for (int j = 0; j < lines.Count; j++)
            {
                int next = (j== this.Points.Count -1) ? 0 : j + 1;
                Vector3 intersection = GraphicsExtension.LineLineIntersection(lines[j], lines[next], true);
                offsetPolygon.AddPoint(new PolygonPoint(offsetPolygon,offsetPolygon.Points.Count,intersection));
            }
            
            offsetPolygon.AddLine(new Line(offsetPolygon.Points[0], offsetPolygon.Points.Last()));

            return offsetPolygon;

        }

        public double Area
        {
            get
            {
                int length = this.Points.Count;
                Vector3[] _points = new Vector3[length+1];
                for (int i = 0; i < length; i++)
                {
                    _points[i] = this.Points[i].Position;
                }
                _points[length] = this.Points[0].Position;

                double result = 0;
                
                for (int i = 0; i < length; i++)
                {
                    result += (_points[i+1].X - _points[i].X) * (_points[i + 1].Y + _points[i].Y)/2;
                }

                return Math.Abs(result);

            }
        }

        public Vector3 Center()
        {
            
                int length = this.Points.Count;
                Vector3[] _points = new Vector3[length+1];
                for (int i = 0; i < length; i++)
                {
                    _points[i] = this.Points[i].Position.Copy();
                }
                _points[length] = this.Points[0].Position;

                double X = 0, Y = 0, factor;
                for(int j=0; j<length; j++)
                {
                    factor = _points[j].X * _points[j + 1].Y - _points[j + 1].X * _points[j].Y;
                    X+= (_points[j].X+_points[j+1].X)*factor;
                    Y+= (_points[j].Y+_points[j+1].Y)*factor;
                }
                
                X/= (6*Area);
                Y/= (6*Area);

                if (X < 0)
                {
                    X = -X;
                    Y = -Y;
                }


                return new Vector3(X, Y);
            
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