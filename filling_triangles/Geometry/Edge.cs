using System;

namespace filling_triangles.Geometry
{
    public class Edge
    {
        private Vertex _vertice1;
        private Vertex _vertice2;
        private double _slope;
        
        public Vertex V2 { get => _vertice2; set => _vertice2 = value; }
        public Vertex V1 { get => _vertice1; set => _vertice1 = value; }

        public Edge(Vertex v1, Vertex v2)
        {
            if (v1.Id < v2.Id)
            {
                _vertice1 = v1;
                _vertice2 = v2;
            }
            else
            {
                _vertice1 = v2;
                _vertice2 = v1;
            }
            
            _slope = CountSlope(this);
        }

        public double CountSlope(Edge e)
        {
            float dx = (float) (e.V2.X - e.V1.X);
            float dy = (float) (e.V2.Y - e.V1.Y);
            return Math.Abs(dx) < GeometryUtils.Eps ? GeometryUtils.Infinity : dy / dx;
        }
        
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 7) + V1.GetHashCode();
                hash = (hash * 7) + V2.GetHashCode();
        
                return hash;
            }
        }

        public bool Equals(Edge? e)
        {
            if (e is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (ReferenceEquals(this, e))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != e.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return ((_vertice1.Equals(V1)) && (_vertice2.Equals(e.V2))) || ((_vertice2.Equals(e.V1)) && (_vertice1.Equals(e.V2)));
        }

        public override bool Equals(object? obj)
        {
            Edge? other = obj as Edge;
            if (other != null)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }
        
        
        public void DrawXY(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            g.DrawLine(pen, (float) _vertice1.X, (float) _vertice1.Y, (float) _vertice2.X, (float) _vertice2.Y);
        }
        
        public void DrawXZ(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            g.DrawLine(pen, (float) _vertice1.X, (float) _vertice1.Z, (float) _vertice2.X, (float) _vertice2.Z);
        }
    }
}