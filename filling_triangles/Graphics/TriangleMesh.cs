using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class TriangleMesh
{
    public List<Face> Faces { get; set;}
    public List<Vertex> Vertices { get; set; }

    private int _columnsCountX;
    private int _rowsCountY;
    private int _width;
    private int _height;
    
    public int Width
    {
        get => _width;
        set => _width = value;
    }
    
    public int Height
    {
        get => _height;
        set => _height = value;
    }

    public int ColumnsCountX
    {
        get => _columnsCountX;
        set => _columnsCountX = value;
    }

    public int RowsCountY
    {
        get => _rowsCountY;
        set => _rowsCountY = value;
    }
    
    public TriangleMesh(int columnsCountX, int rowsCountY, int width, int height)
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();
        _columnsCountX = columnsCountX;
        _rowsCountY = rowsCountY;
        _width = width;
        _height = height;
        
        GenerateTriangles();
    }

    public void GenerateTriangles()
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();
        // find triangles mesh vertices, faces;
        double x = 0;
        double y = 0;
        double stepX = _width / ColumnsCountX; // lenght of base of a triange
        double stepY = _height / RowsCountY; // height of a triangle
      
        // create a list of active edges
        for (int i = 1; i <= _columnsCountX; i++)
        {
            for (int j = 1; j <= _rowsCountY; j++)
            {
                // points
                Point3D upperLeft = new Point3D(x, y, 0); // upper left
                Point3D upperRight = new Point3D(x + stepX, y, 0); // upper right
                Point3D downLeft = new Point3D(x, y + stepY, 0); // down left
                Point3D downRight = new Point3D(x + stepX, y + stepY, 0); // down right

                // UPPER TRIANGLE
                // calculate upper triangle normal vector
                Vector3 upperTriangleNormal = CalculateTriangleNormal(upperLeft, upperRight, downLeft);
                // create vertices for upper triangle
                Vertex upperLeftVertex = new Vertex(upperLeft, i*10+j+1,upperTriangleNormal);
                Vertex upperRightVertex = new Vertex(upperRight, i*10+j+2,upperTriangleNormal);
                Vertex downLeftVertex = new Vertex(downLeft, i*10+j+3,upperTriangleNormal);


                // LOWER TRIANGLE
                // calculate lower triangle normal vector
                Vector3 lowerTriangleNormal = CalculateTriangleNormal(downRight, upperRight, downLeft);
                // create vertices for lower triangle
                Vertex downRightVertex = new Vertex(downRight, i*10+j+4,lowerTriangleNormal);
                Vertex upperRightVertex2 = new Vertex(upperRight, i*10+j+5,lowerTriangleNormal);
                Vertex downLeftVertex2 = new Vertex(downLeft, i*10+j+6,lowerTriangleNormal);
                
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

                y += stepY;

            }
            x += stepX;
            y = 0;
        
        }
    }

   

    
    // this function calculates normal vector for a triangle
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
    public void DrawAllEdges(DirectBitmap bitmap)
    {
       //draw all edges in all faces
       using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap.Bitmap))
         foreach (var face in Faces)
         {
              foreach (var edge in face.Edges)
              {
                  g.DrawLine(new Pen(Color.Black), (int)edge.V1.X, (int)edge.V1.Y, (int)edge.V2.X, (int)edge.V2.Y);
              }
         }
    }
    
}