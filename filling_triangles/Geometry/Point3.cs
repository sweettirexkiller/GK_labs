using System.Numerics;

namespace filling_triangles.Geometry
{
    public class Point3D
    {
        private double x;
        private double y;
        private double z;
        
        //contructor
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Z { get { return z; } set { z = value; } }
        

        // create a Vector3 from two points
        public static Vector3 operator -(Point3D p1, Point3D p2)
        {
            return new Vector3((float)(p1.X - p2.X), (float)(p1.Y - p2.Y), (float)(p1.Z - p2.Z));
        }

    }
}