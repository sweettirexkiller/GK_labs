using System.Collections.Generic;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class TriangleMesh
{
    public List<Face> Faces { get; }
    public List<Vertex> Vertices { get; }
    public IEnumerable<Edge> Edges { get; }
    
    public TriangleMesh(List<Face> faces, List<Vertex> vertices)
    {
        Faces = faces;
        Vertices = vertices;
        Edges = Faces.SelectMany(face => face.Edges).Distinct();
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