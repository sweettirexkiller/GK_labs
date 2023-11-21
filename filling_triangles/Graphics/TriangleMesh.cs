using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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


        //write a function that calculates normal vector for a triangle, it takes three Point3D and return one Vector3
        


        // create a list of active edges
        for (int i = 1; i <= columnsCountX; i++)
        {
            for (int j = 1; j <= rowsCountY; j++)
            {
                // points
                Point3D upperLeft = new Point3D(x, y, 0); // upper left
                Point3D upperRight = new Point3D((int)(x + stepX), y, 0); // upper right
                Point3D downLeft = new Point3D(x, (int)(y + stepY), 0); // down left
                Point3D downRight = new Point3D((int)(x + stepX), (int)(y + stepY), 0); // down right
                
                
                // UPPER TRIANGLE
                // calculate upper triangle normal vector
                Vector3 upperTriangleNormal = CalculateTriangleNormal(upperLeft, upperRight, downLeft);
                // create vertices for upper triangle
                Vertex upperLeftVertex = new Vertex(upperLeft, x+y+i+j+1,upperTriangleNormal);
                Vertex upperRightVertex = new Vertex(upperRight, x+y+i+j+2,upperTriangleNormal);
                Vertex downLeftVertex = new Vertex(downLeft, x+y+i+j+3,upperTriangleNormal);


                // LOWER TRIANGLE
                // calculate lower triangle normal vector
                Vector3 lowerTriangleNormal = CalculateTriangleNormal(downRight, upperRight, downLeft);
                // create vertices for lower triangle
                Vertex downRightVertex = new Vertex(downRight, x+y+i+j+4,lowerTriangleNormal);
                Vertex upperRightVertex2 = new Vertex(upperRight, x+y+i+j+5,lowerTriangleNormal);
                Vertex downLeftVertex2 = new Vertex(downLeft, x+y+i+j+6,lowerTriangleNormal);
                
                // create lower triangle face
                Face lowerTriangle = new Face(new List<Vertex>{downRightVertex, upperRightVertex2, downLeftVertex2});
                // create upper triangle face
                Face upperTriangle = new Face(new List<Vertex>{upperLeftVertex, upperRightVertex, downLeftVertex});
                
        
                // add these two triangels to the list of faces
                Faces.Add(lowerTriangle);
                Faces.Add(upperTriangle);
                
                // add vertices to the list
                Vertices.Add(upperLeftVertex);
                Vertices.Add(upperRightVertex);
                Vertices.Add(downLeftVertex);
                Vertices.Add(downRightVertex);
                Vertices.Add(upperRightVertex2);
                Vertices.Add(downLeftVertex2);
                
                // add edges to the list
                Edges.Concat(upperTriangle.Edges);
                Edges.Concat(lowerTriangle.Edges);
                
                
                y += (int)stepY;

            }
            x += (int)stepX;
            y = 0;
        
        }
       
        static Vector3 CalculateTriangleNormal(Point3D A, Point3D B, Point3D C)
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