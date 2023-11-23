using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class ColorCalculator
{
    private Bitmap _bitmap;
    private List<Vertex> _vertices;
    private Color[] _vertexColors;
    private NormalBitMap _normalBitmap;
    private TriangleMesh _triangleMesh;
    private Lamp _lamp;
    
    
    // contructor
    public ColorCalculator(Lamp lamp, List<Vertex> vertices, TriangleMesh triangleMesh)
    {
        _vertices = vertices;
        _vertexColors = new Color[3];
        _triangleMesh = triangleMesh;
        _lamp = lamp;
        _vertexColors = ComputeColorsInVertices(_vertices);
      
    }
    
    
    private Color[] ComputeColorsInVertices(IReadOnlyList<Vertex> vertices)
    {
        var colors = new Color[3];
        for (int i = 0; i < 3; i++)
        {
            colors[i] = CalculateColor(vertices[i]);
        }

        return colors;
    }
    
    private Color CalculateColor(Vertex vertex)
    {
        Vector3 N = vertex.NormalVector;

       Vector3 lampToVertex =  new Vector3((float)(_lamp.Position.X - vertex.X),
            (float)(_lamp.Position.Y - vertex.Y),
            (float)(_lamp.Position.Z - vertex.Z));
       
        Vector3 L = Vector3.Normalize(lampToVertex);
        
        double cosNL = Math.Max(Vector3.Dot(N,L), 0);

        var R = Vector3.Subtract(2 * (float)cosNL * N, L);
        double cosVR = Math.Max(R.Z, 0);

        var pixelColor = _triangleMesh._textureBitmap.GetPixel((int)vertex.X - _triangleMesh._offset, (int)vertex.Y - _triangleMesh._offset);
    
        var objRedColor =  pixelColor.R / 255.0;
        var objGreenColor = pixelColor.G / 255.0;
        var objBlueColor = pixelColor.B / 255.0;

        var Ir = objRedColor * _lamp.Color.R * (_triangleMesh.Surface.Kd * cosNL + _triangleMesh.Surface.Ks * Math.Pow(cosVR, _triangleMesh.Surface.M));
        Ir = Math.Max(Ir, 0);
        Ir = Math.Min(Ir * 255, 255);
    
        var Ig = objGreenColor * _lamp.Color.G * (_triangleMesh.Surface.Kd * cosNL + _triangleMesh.Surface.Ks * Math.Pow(cosVR, _triangleMesh.Surface.M));
        Ig = Math.Max(Ig, 0);
        Ig = Math.Min(Ig * 255, 255);

        var Ib = objBlueColor * _lamp.Color.B * (_triangleMesh.Surface.Kd * cosNL + _triangleMesh.Surface.Ks * Math.Pow(cosVR, _triangleMesh.Surface.M));
        Ib = Math.Max(Ib, 0);
        Ib = Math.Min(Ib * 255, 255);

        return Color.FromArgb((byte)Ir, (byte)Ig, (byte)Ib);
    }
    
    
    public Color CalculateColorInPoint(int x, int y, Vector3 N)
    {
        var L = Vector3.Normalize(new Vector3((float)(_lamp.Position.X - x),
            (float)(_lamp.Position.Y - y),(float)_lamp.Position.Z));
        
        double cosNL = Math.Max(Vector3.Dot(N,L), 0);

        var R = Vector3.Subtract(2 * ((float)cosNL) * N, L);
        double cosVR = Math.Max(R.Z, 0);

        var pixelColor = _triangleMesh._textureBitmap.GetPixel(x, y);
    
        var objRedColor =  pixelColor.R / 255.0;
        var objGreenColor = pixelColor.G / 255.0;
        var objBlueColor = pixelColor.B / 255.0;

        var Ir = objRedColor * _lamp.Color.R * (_triangleMesh.Surface.Kd * cosNL + _triangleMesh.Surface.Ks * Math.Pow(cosVR, _triangleMesh.Surface.M));
        Ir = Math.Max(Ir, 0);
        Ir = Math.Min(Ir * 255, 255);
    
        var Ig = objGreenColor * _lamp.Color.G * (_triangleMesh.Surface.Kd * cosNL + _triangleMesh.Surface.Ks * Math.Pow(cosVR, _triangleMesh.Surface.M));
        Ig = Math.Max(Ig, 0);
        Ig = Math.Min(Ig * 255, 255);

        var Ib = objBlueColor * _lamp.Color.B * (_triangleMesh.Surface.Kd * cosNL + _triangleMesh.Surface.Ks * Math.Pow(cosVR, _triangleMesh.Surface.M));
        Ib = Math.Max(Ib, 0);
        Ib = Math.Min(Ib * 255, 255);

        return Color.FromArgb((byte)Ir, (byte)Ig, (byte)Ib);
    }
    
    public Vector3 InterpolateVector(float w, float u, float v)
    {
        return Vector3.Normalize(Vector3.Add(Vector3.Add(_vertices[0].NormalVector * w, _vertices[1].NormalVector * u),
            _vertices[2].NormalVector * v));
    }
    
    private Color InterpolateColor(float w, float u, float v)
    {
        // wektor normalny ma wspolrzedne barycentryczne
        // p = wV0 + uV1 + vV2 
        var R = Math.Min(_vertexColors[0].R * w + _vertexColors[1].R * u + _vertexColors[2].R * v, 255);
        var G = Math.Min(_vertexColors[0].G * w + _vertexColors[1].G * u + _vertexColors[2].G * v, 255);
        var B = Math.Min(_vertexColors[0].B * w + _vertexColors[1].B * u + _vertexColors[2].B * v, 255);

        return Color.FromArgb((int)R, (int)G, (int)B);
    }
    
   public Color CalculateColor(int x, int y)
   {
       // get color from bitmap
       Color calculateColor = Color.White;
     
       // get color from texture
       calculateColor = _triangleMesh._textureBitmap.GetPixel(x - _triangleMesh._offset, y - _triangleMesh._offset);
       
       // p = (x,y)
       // p = wV0 + uV1 + vV2 
       var v1p = new Vector3((int)(x - _vertices[1].X), (int)(y - _vertices[1].Y), 0);
       var v1v2 = new Vector3((int)(_vertices[2].X - _vertices[1].X), (int)(_vertices[2].Y - _vertices[1].Y), 0);
       var w = Vector3.Cross(v1p, v1v2).Length();
 
       var v1v0 = new Vector3((int)(_vertices[0].X - _vertices[1].X), (int)(_vertices[0].Y - _vertices[1].Y), 0);

       var v = Vector3.Cross(v1p, v1v0).Length();
 
       var v0p = new Vector3((int)(x - _vertices[0].X), (int)(y - _vertices[0].Y), 0);
       var v0v2 = new Vector3((int)(_vertices[2].X - _vertices[0].X), (int)(_vertices[2].Y - _vertices[0].Y), 0);

       var u = Vector3.Cross(v0p, v0v2).Length();
 
       // normalization
       var surface = w + u + v;
       w /= surface;
       u /= surface;
       v /= surface;

       switch (_triangleMesh.IsNormalMap )
       {
           case true:
               switch(_triangleMesh.IsColorInterpolated)
               {
                   case true:
                   {
                       var N = InterpolateVector(w, u, v);
                       if (_triangleMesh._normalBitMap is not null)
                       {
                           N = _triangleMesh._normalBitMap.GetNormalVector(N, x, y);
                       }

                       return CalculateColorInPoint(x, y, N);
                   }
                   case false:
                   {
                       return InterpolateColor(w, u, v);
                   }
               }
           case false:
               switch(_triangleMesh.IsColorInterpolated)
               {
                   case true:
                   {
                       var N = InterpolateVector(w, u, v);

                       return CalculateColorInPoint(x, y, N);
                   }
                   case false:
                   {
                       return InterpolateColor(w, u, v);
                   }
               }
       }
   }
   

  
}