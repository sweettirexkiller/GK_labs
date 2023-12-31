using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms.Design;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;


public class Surface
{
    private double _kd;
    private double _ks;
    private double _m;

    public double Kd { get => _kd; set => _kd = value; }
    public double Ks { get => _ks; set => _ks = value; }
    public double M { get => _m; set => _m = value; }

    public Surface(double kd, double ks, double m)
    {
        _ks = kd;
        _kd = ks;
        _m = m;
    }
}
public class TriangleMesh
{
    public List<Face> Faces { get; set;}
    public List<Vertex> Vertices { get; set; }

    private int _columnsCountX;
    private int _rowsCountY;
    private int _width;
    private int _height;
    public int _xSpan;
    public int _ySpan;
    public readonly int _offset = 10;
    public Color ObjectColor;
    public bool IsColorFilled = true;
    public bool IsTextureFilled = false;
    
    public DirectBitmap _textureBitmap;
    public NormalBitMap _normalBitMap;

    public bool IsNormalMap = false;
    public bool IsConstantNormalVector = false;
    
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

    public bool IsMeshVisible { get; set; }
    public Color LightColor { get; set; }
    public bool IsColorInterpolated { get; set; }
    public bool IsLightConstant { get; set; }
    public bool IsLightAnimated { get; set; }
    
    public Surface Surface { get; set; }
    public Image Image { get; set; }
    public bool IsFunctionalZ { get; set; }
    public bool ShouldRotateOnce { get; set; }
    public double AlfaForZRotation { get; set; }
    public double BetaForXRotation { get; set; }

    public TriangleMesh(int columnsCountX, int rowsCountY, int width, int height, Color objectColor)
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();
        _columnsCountX = columnsCountX;
        _rowsCountY = rowsCountY;
        _width = width;
        _height = height;
        ObjectColor = objectColor;
        IsMeshVisible = true;
        Surface = new Surface(0.5, 0.5, 50);
        _textureBitmap = new DirectBitmap(width,height);
        IsLightAnimated = true;
        IsLightConstant = true;
        IsColorInterpolated = false;
        ShouldRotateOnce = false;
        
        
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                _textureBitmap.SetPixel(i,j, ObjectColor);
            }
        }
        
        GenerateTriangles();
    }

    public double ZFunction(double x, double y)
    {
        if (IsFunctionalZ)
        {
            return  (Math.Sin(Math.PI/2.0 *x/_width) + Math.Cos(Math.PI/2.0*y/_height));
        }
        else
        {
            return 0;
        }
        
    }

    public void GenerateTriangles()
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();
        // find triangles mesh vertices, faces;
        double x = _offset;
        double y = _offset;
        double stepX = (_width - 2*_offset) / ColumnsCountX; // lenght of base of a triange
        double stepY = (_height - 2*_offset) / RowsCountY; // height of a triangle
        _xSpan = (int)stepX*ColumnsCountX;
        _ySpan = (int)stepY*RowsCountY;
        
      
        // create a list of active edges
        for (int i = 1; i <= _columnsCountX; i++)
        {
            for (int j = 1; j <= _rowsCountY; j++)
            {
                // points
                Point3D upperLeft, upperRight, downLeft, downRight;
                
                // scale x and y to <0,1>
                double scaledX = x / (_width);
                double scaledY = y / (_height);
                double scaledStepX = stepX / (_width);
                double scaledStepY = stepY / (_height);
                
                if (IsFunctionalZ)
                {
                    upperLeft = new Point3D(x, y, this.ZFunction(x,y)); // upper left
                    upperRight = new Point3D(x + stepX, y,  this.ZFunction(scaledX+scaledStepX,scaledY)); // upper right
                    downLeft = new Point3D(x, y + stepY,  this.ZFunction(scaledX,scaledY+scaledStepY)); // down left
                    downRight = new Point3D(x + stepX, y + stepY, this.ZFunction(scaledX+scaledStepX, scaledY + scaledStepY)); // down right
                }
                else
                {
                    // use beziere !!
                    upperLeft = new Point3D(x, y, 0); // upper left
                    upperRight = new Point3D(x + stepX, y, 0); // upper right
                    downLeft = new Point3D(x, y + stepY, 0); // down left
                    downRight = new Point3D(x + stepX, y + stepY, 0); // down right
                }


                // UPPER TRIANGLE
                // calculate upper triangle normal vector
                Vector3 upperTriangleNormal = CalculateTriangleNormal(upperLeft, upperRight, downLeft);
                // create vertices for upper triangle
                Vertex upperLeftVertex = new Vertex(upperLeft, i*10+j+1,upperTriangleNormal);
                Vertex upperRightVertex = new Vertex(upperRight, i*10+j+2,upperTriangleNormal);
                Vertex downLeftVertex = new Vertex(downLeft, i*10+j+3,upperTriangleNormal);


                // LOWER TRIANGLE
                // calculate lower triangle normal vector
                Vector3 lowerTriangleNormal = CalculateTriangleNormal(downLeft, upperRight, downRight );
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
            y = _offset;

        }
        
        
        ShouldRotateOnce = false;
        
       
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
    public void DrawAllEdges(DirectBitmap canvas)
    {
       //draw all edges in all faces
       using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(canvas.Bitmap))
         foreach (var face in Faces)
         {
              foreach (var edge in face.Edges)
              {
                  if (ShouldRotateOnce)
                  {
                      double X1 = edge.V1.X;
                      double Y1 = edge.V1.Y;
                      double X2 = edge.V2.X;
                      double Y2 = edge.V2.Y;
                     
                        

                        //1. translate to origin
                        X1 = X1 - Width / 2;
                        Y1 = Y1 - Height / 2;
                        X2 = X2 - Width / 2;
                        Y2 = Y2 - Height / 2;
                        
                        //scale to <0,1>
                        // X1 = X1 / Width;
                        // Y1 = Y1 / Height;
                        // X2 = X2 / Width;
                        // Y2 = Y2 / Height;
                        
                                    
                      if (AlfaForZRotation != 0.0)
                      {
                          //2. rotate
                          int newX1 = (int)(X1*Math.Cos(AlfaForZRotation) - Y1*Math.Sin(AlfaForZRotation));
                        int newY1 = (int)(X1*Math.Sin(AlfaForZRotation) + Y1*Math.Cos(AlfaForZRotation));
                        int newX2 = (int)(X2*Math.Cos(AlfaForZRotation) - Y2*Math.Sin(AlfaForZRotation));
                        int newY2 = (int)(X2*Math.Sin(AlfaForZRotation) + Y2*Math.Cos(AlfaForZRotation));
                        X1 = newX1;
                        Y1 = newY1;
                        X2 = newX2;
                        Y2 = newY2;
                      }
                      if (BetaForXRotation != 0.0)
                      {
                          // 2. rotate
                            int newY1 = (int)(Y1 * Math.Cos(BetaForXRotation) - ZFunction(X1, Y1) * Math.Sin(BetaForXRotation));
                            // X1 = (int)(Y1 * Math.Sin(BetaForXRotation) + ZFunction(X1, Y1) * Math.Cos(BetaForXRotation));
                            int newY2 = (int)(Y2 * Math.Cos(BetaForXRotation) - ZFunction(X2, Y2) * Math.Sin(BetaForXRotation));
                            // X2 = (int)(Y2 * Math.Sin(BetaForXRotation) + ZFunction(X2, Y2) * Math.Cos(BetaForXRotation));
                            Y2 = newY2;
                            Y1 = newY1;

                      }
                      //3. translate back
                        // un-scale
                        // X1 = X1 * Width;
                        // Y1 = Y1 * Height;
                        // X2 = X2 * Width;
                        // Y2 = Y2 * Height;
                      
                        X1 = X1 + Width / 2;
                        Y1 = Y1 + Height / 2;
                        X2 = X2 + Width / 2;
                        Y2 = Y2 + Height / 2;
                        
                        
                        // if line leaves the canvas, dont draw it
                        if (X1 < 0 || X1 > Width || X2 < 0 || X2 > Width || Y1 < 0 || Y1 > Height || Y2 < 0 || Y2 > Height)
                        {
                            continue;
                        }
                      g.DrawLine(new Pen(Color.Black),(int) X1, (int) Y1,(int)  X2,(int)  Y2);
                  }
                  else
                  {
                      
                      g.DrawLine(new Pen(Color.Black), (int)edge.V1.X, (int)edge.V1.Y, (int)edge.V2.X, (int)edge.V2.Y);
                  }
              }
         }
    }

    public void Paint(Brush brush, DirectBitmap canvas, Lamp lamp)
    {
        foreach (var face in Faces)
        {
            brush.FillTriangle(this, face, canvas, lamp);
        }
        
        if(IsMeshVisible)
            DrawAllEdges(canvas);
    }

    public void SetTexture(Bitmap newTexture)
    {
        _textureBitmap = new DirectBitmap(newTexture);
    }
    
    public void SetTexture(Color color)
    {
        var oldTexture = _textureBitmap;
        _textureBitmap = new DirectBitmap(oldTexture.Width, oldTexture.Height);
        for (var i = 0; i < _textureBitmap.Width; i++)
        {
            for (var j = 0; j < _textureBitmap.Height; j++)
            {
                _textureBitmap.SetPixel(i, j, color);
            }
        }
        // _textureImage = Image.FromHbitmap(_textureBitmap.GetHbitmap());
    }
    
    
    public void SetNormalMap(Image newNormalMapImage)
    {
        var oldNormalMap = _normalBitMap;
        if(oldNormalMap is not null)
        {
            _normalBitMap = new NormalBitMap(newNormalMapImage, new Size(oldNormalMap.Width, oldNormalMap.Height));
        }
        else
        {
            _normalBitMap = new NormalBitMap(newNormalMapImage, new Size(Width, Height));
        }
    }
}