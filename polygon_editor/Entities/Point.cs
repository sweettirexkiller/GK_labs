using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace polygon_editor.Entities
{
    public class Point
    {
        private Vector3 vector3;
        private double thickness;

        //constructor
        public Point()
        {
            this.Position = Vector3.Zero;
            this.Thickness = 0.0;
        }

        //constructor
        public Point(Vector3 position)
        {
            this.Position = position;
            this.Thickness = 0.0;
        }

        //setter and getter thickness
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        //setter and getter vector
        public Vector3 Position
        {
            get { return vector3; }
            set { vector3 = value; }
        }

        public double DistanceToLine(Line line)
        {
            //disatnce between point and line
            Vector3 closestPoint;
            double x1 = line.StartPoint.Position.X;
            double y1 = line.StartPoint.Position.Y;
            double x2 = line.EndPoint.Position.X;
            double y2 = line.EndPoint.Position.Y;
            double x0 = this.Position.X;
            double y0 = this.Position.Y;

            double dx = x2 - x1;
            double dy = y2 - y1;

            if ((dx == 0) && (dy == 0))
            {
                closestPoint = line.StartPoint.Position;
                dx = x0 - x1;
                dy = y0 - y1;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            double k = ((x0 - x1) * dx + (y0 - y1) * dy) / (dx * dx + dy * dy);

            closestPoint = new Vector3(x1 + k * dx, y1 + k * dy);

            dx = x0 - closestPoint.X;
            dy = y0 - closestPoint.Y;

            if (k < 0)
            {
                closestPoint = new Vector3(x1, y1);
            }
            else if (k > 1)
            {
                closestPoint = new Vector3(x2, y2);
                dx = x0 - x2;
                dy = y0 - y2;
            }

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double DistanceFrom(Vector3 position)
        {
            return Math.Sqrt(Math.Pow(this.Position.X - position.X, 2) +
                             Math.Pow(this.Position.Y - position.Y, 2));
        }
    }

    public class PolygonPoint : Point
    {
        private int index;
        private bool isMoving;
        private Polygon polygon;
        private Line lineIn;
        private Line lineOut;

        //constructor
        public PolygonPoint(Polygon polygon, int index,Vector3 position) : base(position)
        {
            this.Polygon = polygon;
            this.Index = index;
            isMoving = false;
        }
        
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public Polygon Polygon
        {
            get { return polygon; }
            set { polygon = value; }
        }
        public Line LineIn
        {
            get => lineIn;
            set => lineIn = value;
        }
        
        public Line LineOut
        {
            get => lineOut;
            set => lineOut = value;
        }
        public bool IsMoving
        {
            get => isMoving;
            set => isMoving = value;
        }
        
        public PolygonPoint Copy()
        {
            return new PolygonPoint(this.Polygon,this.Index,this.Position.Copy());
        }
    } 
}