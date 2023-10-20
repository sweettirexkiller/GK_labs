namespace polygon_editor.Entities
{
    public class Line
    {
        private Vector3 startPoint;
        private Vector3 endPoint;
        private double thickness;

        public Line() : this(Vector3.Zero, Vector3.Zero)
        {
        }
       
        public Line(Vector3 startPoint, Vector3 endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.thickness = 0.0;
        }

        public Vector3 EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public Vector3 StartPoint
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