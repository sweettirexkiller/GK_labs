using System.Collections.Generic;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class TriangleMesh
{
    public List<Face> Faces { get; }
    public List<Vertex> Vertices { get; }
    public IEnumerable<Edge> Edges { get; }
    
    public TriangleMesh(int columnsX, int rowsY)
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();
        
        //  // draw triangles mesh 
        //     int x = 0;
        //     int y = 0;
        //     // find graphis width and height
        //     float width = g.VisibleClipBounds.Width;
        //     float height = g.VisibleClipBounds.Height;
        //     float stepX = width / columnsX;
        //     float stepY = height / rowsY;
        //     
        //     // create a table of edges but not a list
        //     List<LineNode> edges = new List<LineNode>();
        //     
        //
        //     // create a list of active edges
        //     for (int i = 1; i <= columnCountX; i++)
        //     {
        //         for (int j = 1; j <= columnCountY; j++)
        //         {
        //             // g.DrawRectangle(pen, x + i * stepX, y + j * stepY, stepX, stepY);
        //
        //             Point upperLeft = new Point(x, y); // upper left
        //             Point upperRight = new Point((int)(x + stepX), y); // upper right
        //             Point downLeft = new Point(x, (int)(y + stepY)); // down left
        //             Point downRight = new Point((int)(x + stepX), (int)(y + stepY)); // down right
        //             
        //             // lines of a square with one diagonal (two triangles)
        //             LineNode upperLeftToUpperRight = new LineNode(new Point2D(upperLeft.X, upperLeft.Y),
        //                 new Point2D(upperRight.X, upperRight.Y));
        //             LineNode upLeftToDownLeft = new LineNode(new Point2D(upperLeft.X, upperLeft.Y),
        //                 new Point2D(downLeft.X, downLeft.Y));
        //             LineNode downLeftUpperRight = new LineNode(new Point2D(upperRight.X, upperRight.Y),
        //                 new Point2D(downLeft.X, downLeft.Y));
        //             LineNode upperRightToDownRight = new LineNode(new Point2D(downRight.X, downRight.Y),
        //                 new Point2D(upperRight.X, upperRight.Y));
        //             LineNode downRightToDownLeft = new LineNode(new Point2D(downRight.X, downRight.Y),
        //                 new Point2D(downLeft.X, downLeft.Y));
        //
        //             
        //             // by this we avoid adding duplicate edges
        //             // add edges to the edge table but avoid duplicates
        //             if (y == 0)
        //             {
        //                 // this is first column so add upperLeftDownLeft
        //                 edges.Add(upLeftToDownLeft);
        //             }
        //
        //             if (x == 0)
        //             {
        //                 // this is fist row do add upperLeftToUpperRight
        //                 edges.Add(upperLeftToUpperRight);
        //             }
        //
        //             edges.Add(downLeftUpperRight);
        //             edges.Add(upperRightToDownRight);
        //             edges.Add(downRightToDownLeft);
        //             
        //             
        //             if (_isMeshVisible)
        //             {
        //                 Point[] topTriangle = { upperLeft, upperRight, downLeft };
        //                 Point[] lowerTriangle = { downRight, upperRight, downLeft };
        //                 g.DrawPolygon(pen, topTriangle);
        //                 g.DrawPolygon(pen, lowerTriangle);
        //             }
        //             
        //             y += (int)stepY;
        //             
        //         }
        //         x += (int)stepX;
        //         y = 0;
        //
        //     }
        //     
        //
        //
        //
        // Faces = faces;
        // Vertices = vertices;
        // Edges = Faces.SelectMany(face => face.Edges).Distinct();
    }
    
    
    // public void FitToCanvas(float height, float width, int offset)
    // {
    //     var scale = Math.Min(height, width) - offset;
    //     var kX = scale / _xSpan;
    //     var kY = scale / _ySpan;
    //     var kZ = scale / _zSpan / 2;
    //     _xSpan *= kX;
    //     _ySpan *= kY;
    //     _zSpan *= kZ;
    //
    //     MoveCenter(0, 0, 0);
    //     foreach (var vertex in Vertices)
    //     {
    //         vertex.Scale((float)kX, (float)kY, (float)kZ);
    //     }
    //
    //     MoveCenter(width/2, height/2, 0);
    //
    //     _textureBitmap = new Bitmap(_textureImage, (int)width, (int)height);
    //     _normalMap?.Resize(new Size((int)width, (int)height));
    //     _heightMap?.Resize(new Size((int)width, (int)height));
    // }
    
    // public void FillFaces(GraphicTools.Painter painter, DirectBitmap bitmap, Illumination illumination, bool isVectorInterpolation, bool isVectorMapUsed)
    // {
    //     foreach (var face in Faces)
    //     {
    //         painter.FillPolygon(face, _textureBitmap, bitmap, illumination, _surface, _normalMap, _heightMap, isVectorInterpolation, isVectorMapUsed);
    //     }
    // }
}