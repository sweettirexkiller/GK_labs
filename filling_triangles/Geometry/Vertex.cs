using System;
using System.Numerics;

namespace filling_triangles.Geometry
{
    public class Vertex : Point3D
    {
        public Vector3 NormalVector { get; }
        public int Id { get; }
        
        public Point3D BeforeProjection { get; set; }

        public Vertex(Point3D point, int id, Vector3 normalVector) : base(point.X, point.Y, point.Z)
        {
            Id = id;
            //normalize a 3D vector
            NormalVector = Vector3.Normalize(normalVector);
            BeforeProjection = point;
        }

        // - operator
        public static Vertex operator -(Vertex p1, Vertex p2)
        {
            return new Vertex(new Point3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z), p1.Id, p1.NormalVector);
        }

        public void Scale(float kX, float kY, float kZ)
        {
            X *= kX;
            Y *= kY;
            Z *= kZ;
        }

        public void Translate(float dX, float dY, float dZ)
        {
            X += dX;
            Y += dY;
            Z += dZ;
        }

        public bool Equals(Vertex? v)
        {
            if (v is null)
            {
                return false;
            }

            if (ReferenceEquals(this, v))
            {
                return true;
            }
            if(GetType() != v.GetType())
            {
                return false;
            }

            return X.Equals(v.X) && Y.Equals(v.Y) && Z.Equals(v.Z);
        }
        
        public override bool Equals(object? obj)
        {
            if (obj is Vertex other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
        
        // casting operator to Vector3
        public static implicit operator Vector3(Vertex v)
        {
            return new Vector3((float)v.X, (float)v.Y, (float)v.Z);
        }

        public void Project(Matrix4x4 perspectiveLookAt)
        {
            // create Matrix4x4 from point
            Matrix4x4 pointMatrix = new Matrix4x4(
                (float)X, 0, 0, 0,
                0, (float)Y, 0, 0,
                0, 0, (float)Z, 0,
                0, 0, 0, 1
            );
            
            // multiply pointMatrix by perspectiveLookAt
            Matrix4x4 result = Matrix4x4.Multiply(pointMatrix, perspectiveLookAt);
            
            //change point to result
            X = result.M11;
            Y = result.M21;
            Z = result.M31;
            W = result.M41;
        }
    }
}