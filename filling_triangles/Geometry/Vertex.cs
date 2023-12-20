using System;
using System.Numerics;

namespace filling_triangles.Geometry
{
    public class Vertex : Point3D
    {
        public Vector3 NormalVector { get; }
        public int Id { get; }
        
        public Point3D BeforeProjection { get; set; }
        
        public bool isProjected = false;

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

        public void Project(Matrix4x4 lookAt, Matrix4x4 perspective)
        {
            // multiply pointMatrix by perspectiveLookAt
            Matrix4x4 lookAtPerspective =  lookAt * perspective ;
            
            // transform this point by lookAtPerspective
            Vector4 result = Vector4.Transform(this, lookAtPerspective);
            
            //change point to result
            X = result.X;
            Y = result.Y;
            Z = result.Z;
            W = result.W;
            
            isProjected = true;
        }
        
        // create copy method
        public Vertex Clone()
        {
            return new Vertex(new Point3D(X, Y, Z), Id, NormalVector);
        }

        public void FitToScreen(int width, int height)
        {
            X = X * width;
            Y = Y * height;
        }
        
        public void FitToScreenWithPerspective(int width, int height)
        {
            X = (X+1)/2 * width;
            Y = (Y+1)/2 * height;
        }
        
            
       
    }
}