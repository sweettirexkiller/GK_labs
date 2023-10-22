namespace polygon_editor.Entities
{
    public class Line
    {
        private Point startPoint;
        private Point endPoint;
        private double thickness;

        public Line()
        {
        }
       
        public Line(Point startPoint, Point endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.thickness = 0.0;
        }

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public double Thikness
        {
            get { return thickness; }
            set { thickness = value; }
        }
    }
}