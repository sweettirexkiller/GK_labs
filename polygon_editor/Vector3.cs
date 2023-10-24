using System;

namespace polygon_editor
{
    public class Vector3
    {
        private double x;
        private double y;
        private double z;
        
        //constructor
        public Vector3(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.Z=0.0;
        }

        public Vector3 Copy()
        {
            return new Vector3(X, Y, Z);
        }
        
        //constructor 
        public Vector3(double x, double y, double z) : this(x,y)
        {
            this.Z=z;
        }
        
        //getters and setters
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        //getters and setters
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        //getters and setters
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        
        // system drawing pointF
        public System.Drawing.PointF ToPointF()
        {
            return new System.Drawing.PointF((float)X, (float)Y);
        }
        
        
        // static zero
        public static Vector3 Zero
        {
            get { return new Vector3(0.0, 0.0, 0.0); }
        }
        
        public double DistanceTo(Vector3 vector)
        {
            return Math.Sqrt(Math.Pow(this.X - vector.X, 2) + Math.Pow(this.Y - vector.Y, 2));
        }
        
        public Vector3 Transfer2D(double distance, double angle)
        {
            //angle to radians
            angle = angle * Math.PI / 180.0;
            double x = this.X + distance * Math.Cos(angle);
            double y = this.Y + distance * Math.Sin(angle);
            return new Vector3(x, y);
        }
        
    }
}