using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class ColorCalculator
{
    private Bitmap _bitmap;
    private List<Vertex> _vertices;
    private Color[] _vertexColors;
    private Bitmap _objTexture;
    private TriangleMesh _triangleMesh;
    
    
    // contructor
    public ColorCalculator(Bitmap bitmap, List<Vertex> vertices,Bitmap objTexture = null)
    {
        _bitmap = bitmap;
        _vertices = vertices;
        _vertexColors = new Color[3];
        _objTexture = objTexture;
    }
    
   private Color CalculateColor(Vertex vertex)
   {
       // get color from bitmap
       return _bitmap.GetPixel((int)vertex.X, (int)vertex.Y);
   }
   

  
}