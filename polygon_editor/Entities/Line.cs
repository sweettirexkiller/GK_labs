using System;

namespace polygon_editor.Entities
{
    public class Line
    {
        private PolygonPoint startPoint;
        private PolygonPoint endPoint;
        private double thickness;

        public Line()
        {
        }
       
        public Line(PolygonPoint startPoint, PolygonPoint endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.thickness = 0.0;
        }

        public PolygonPoint EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public PolygonPoint StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public double Thikness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        
        public double DistanceToPoint(Point point)
        {
            double x1 = startPoint.Position.X;
            double y1 = startPoint.Position.Y;
            double x2 = endPoint.Position.X;
            double y2 = endPoint.Position.Y;
            double x0 = point.Position.X;
            double y0 = point.Position.Y;
            double numerator = Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1);
            double denominator = Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
            return numerator / denominator;
        }
    }
}