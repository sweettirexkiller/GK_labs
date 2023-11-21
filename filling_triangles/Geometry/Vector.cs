namespace filling_triangles.Geometry
{
    public class Vector3D
    {
        private double x;
        private double y;
        private double z;
        
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Z { get { return z; } set { z = value; } }
    }
}