using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class TriangleMesh
{
    public List<Face> Faces { get; }
    public List<Vertex> Vertices { get; }
    public IEnumerable<Edge> Edges { get; }
    
    public TriangleMesh(int columnsCountX, int rowsCountY, int width, int height)
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();
        
        // find triangles mesh vertices, faces;
        int x = 0;
        int y = 0;
        float stepX = width / columnsCountX; // lenght of base of a triange
        float stepY = height / rowsCountY; // height of a triangle
        // create a table of all edges 
        List<Edge> edges = new List<Edge>();
        
        
        // create a list of active edges
        for (int i = 1; i <= columnsCountX; i++)
        {
            for (int j = 1; j <= rowsCountY; j++)
            {
                // points and vertecies in 3D bezier triangluation
                Point3D upperLeft = new Point3D(x, y, 0); // upper left
                // Vertex upperLeftVertex = new Vertex(upperLeft, x + y + i + j, new Vector3(x, y, 0));
                Point3D upperRight = new Point3D((int)(x + stepX), y, 0); // upper right
                // Vertex 
                Point3D downLeft = new Point3D(x, (int)(y + stepY), 0); // down left
                Point3D downRight = new Point3D((int)(x + stepX), (int)(y + stepY), 0); // down right
                
                // create upper triangle face
                // freate lower triangle face
                
                
                
                
                // lines of a square with one diagonal (two triangles)
                // Edge upperLeftToUpperRight = new Edge(new Vertex(upperLeft, x+y+i+j, ),
                //     new Point2D(upperRight.X, upperRight.Y));
                // LineNode upLeftToDownLeft = new LineNode(new Point2D(upperLeft.X, upperLeft.Y),
                //     new Point2D(downLeft.X, downLeft.Y));
                // LineNode downLeftUpperRight = new LineNode(new Point2D(upperRight.X, upperRight.Y),
                //     new Point2D(downLeft.X, downLeft.Y));
                // LineNode upperRightToDownRight = new LineNode(new Point2D(downRight.X, downRight.Y),
                //     new Point2D(upperRight.X, upperRight.Y));
                // LineNode downRightToDownLeft = new LineNode(new Point2D(downRight.X, downRight.Y),
                //     new Point2D(downLeft.X, downLeft.Y));
        
                
                // by this we avoid adding duplicate edges
                // add edges to the edge table but avoid duplicates
                if (y == 0)
                {
                    // this is first column so add upperLeftDownLeft
                    edges.Add(upLeftToDownLeft);
                }
        
                if (x == 0)
                {
                    // this is fist row do add upperLeftToUpperRight
                    edges.Add(upperLeftToUpperRight);
                }
        
                edges.Add(downLeftUpperRight);
                edges.Add(upperRightToDownRight);
                edges.Add(downRightToDownLeft);
                
                //
                // if (_isMeshVisible)
                // {
                //     Point[] topTriangle = { upperLeft, upperRight, downLeft };
                //     Point[] lowerTriangle = { downRight, upperRight, downLeft };
                //     g.DrawPolygon(pen, topTriangle);
                //     g.DrawPolygon(pen, lowerTriangle);
                // }
                
                y += (int)stepY;
                
            }
            x += (int)stepX;
            y = 0;
        
        }
       
        static Vector3 CalculateTriangleNormal(Vector3 A, Vector3 B, Vector3 C)
        {
            // Wektor AB
            Vector3 AB = B - A;
            // Wektor AC
            Vector3 AC = C - A;
            // Wektor normalny
            Vector3 normalVector = Vector3.Cross(AB, AC);

            // Normalizacja wektora normalnego
            normalVector = Vector3.Normalize(normalVector);

            return normalVector;
        }
    }
}