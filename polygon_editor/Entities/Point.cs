using System.Collections.Generic;

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
    } 
}