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
    }
}