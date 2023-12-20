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
            colors[i] = CalculateColorOnVertex(vertices[i]);
        }

        return colors;
    }
    
    private Color CalculateColorOnVertex(Vertex vertex)
    {
        Vector3 N = vertex.NormalVector;

       Vector3 lampToVertex =  new Vector3((float)(_lamp.Position.X - vertex.X),
            (float)(_lamp.Position.Y - vertex.Y),
            (float)(_lamp.Position.Z - vertex.Z));
       
        Vector3 L = Vector3.Normalize(lampToVertex);
        
        double cosNL = Math.Max(Vector3.Dot(N,L), 0);

        // R=2<N,L>N-L
        var R = Vector3.Subtract(2 * (float)cosNL * N, L);
        double cosVR = Math.Max(R.Z, 0);

        var pixelColor = _triangleMesh._textureBitmap.GetPixel((int)vertex.X, (int)vertex.Y);
    
        var objRedColor =  pixelColor.R / 255.0;
        var objGreenColor = pixelColor.G / 255.0;
        var objBlueColor = pixelColor.B / 255.0;

        
        //  kd*IL*IO*cos(kąt(N,L)) + ks*IL*IO*cosm(kąt(V,R))
        
        //obliczenia wykonujemy dla wartości kolorów z przedziału 0..1, dopiero ostateczny wynik konwerujemy do przedziału 0..255 (obcinając do 255)

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
    
    // kolor w punkcie z uwglednieniem wartosci normalnej
    public Color CalculateColorInPointWithVectorInterpolation(int x, int y, Vector3 N)
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
        // po prostu zwraca wektor dla punktu p uzyskany ze współrzędnych barycentrycznych
        return Vector3.Normalize(Vector3.Add(Vector3.Add(_vertices[0].NormalVector * w, _vertices[1].NormalVector * u),
            _vertices[2].NormalVector * v));
    }
    
    private Color InterpolateColor(float w, float u, float v)
    {
        // wektor normalny ma wspolrzedne barycentryczne
        // p = wV0 + uV1 + vV2 
        // maks lub suma
        var R = Math.Min(_vertexColors[0].R * w + _vertexColors[1].R * u + _vertexColors[2].R * v, 255);
        // maks lub suma
        var G = Math.Min(_vertexColors[0].G * w + _vertexColors[1].G * u + _vertexColors[2].G * v, 255);
        // maks lub suma
        var B = Math.Min(_vertexColors[0].B * w + _vertexColors[1].B * u + _vertexColors[2].B * v, 255);

        return Color.FromArgb((int)R, (int)G, (int)B);
    }
    
    private Vector3 CalculateBarycentricCoordinates(Vector3 A, Vector3 B, Vector3 C, Vector3 P)
    {
        // Obliczanie wektorów krawędzi
        Vector3 edgeAB = B - A;
        Vector3 edgeAC = C - A;

        // Obliczanie wektora normalnego do płaszczyzny trójkąta
        Vector3 normal = Vector3.Cross(edgeAB, edgeAC);

        // Obliczanie współrzędnych barycentrycznych
        float alpha = Vector3.Dot(Vector3.Cross(B - P, C - P), normal) / normal.LengthSquared();
        float beta = Vector3.Dot(Vector3.Cross(C - P, A - P), normal) / normal.LengthSquared();
        float gamma = 1 - alpha - beta;

        return new Vector3(alpha, beta, gamma);
    }
    
   public Color CalculateColor(int x, int y)
   {
       
       Vector3 barycentric = CalculateBarycentricCoordinates(_vertices[0], _vertices[1], _vertices[2], new Vector3(x, y, (float)_triangleMesh.ZFunction(x,y)));

       float w = barycentric.X;
       float u = barycentric.Y;
       float v = barycentric.Z;

       switch (_triangleMesh.IsNormalMap )
       {
           case true:
               switch(_triangleMesh.IsColorInterpolated)
               {
                   case true:
                   {
                       // po prostu wartosc wektora dla punktu p uzyskana ze współrzędnych barycentrycznych
                       var N = InterpolateVector(w, u, v);
                       // uwzglddniona mapa noramalnych
                       if (_triangleMesh._normalBitMap is not null)
                       {
                           N = _triangleMesh._normalBitMap.GetNormalVector(N, x, y);
                       }

                       return CalculateColorInPointWithVectorInterpolation(x, y, N);
                   }
                   case false:
                   {
                       // maks lub suma kolorow
                       return InterpolateColor(w, u, v);
                   }
               }
           case false:
               switch(_triangleMesh.IsColorInterpolated)
               {
                   case true:
                   {
                       var N = InterpolateVector(w, u, v);

                       return CalculateColorInPointWithVectorInterpolation(x, y, N);
                   }
                   case false:
                   {
                       return InterpolateColor(w, u, v);
                   }
               }
       }
   }
   

  
}