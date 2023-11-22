using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class Painter
{
    
    //props
    private ScanLineProcedure _scanLineProcedure;
    //constructor
    public Painter()
    {
        // scan line procedure accepts triangle and fill it 
        
        _scanLineProcedure = new ScanLineProcedure();
    }
    public void FillTriangle(TriangleMesh triangleMesh, Face face, DirectBitmap directBitmap)
    {
        // feels edges table
        _scanLineProcedure.Init(face.Edges);
        
        var vertices = face.Vertices;
        ColorCalculator colorCalculator = new ColorCalculator(directBitmap.Bitmap, vertices);
        
        while(!_scanLineProcedure.IsDone)
        {
            _scanLineProcedure.UpdateAETBeforeDrawing();
            
            // intersections are just x coordinates of nodes in active edge table
            IEnumerable<int> intersections = _scanLineProcedure.Intersections;

            // if there is more than one intersection
            if (intersections.Count() > 1)
            {
                // this works because there are only triangles in our app
                for(int x = intersections.First(); x <= intersections.Last(); x++)
                {
                    if(triangleMesh.IsColorFilled)
                    {
                        directBitmap.SetPixel(x, _scanLineProcedure.CurrentY,  triangleMesh.ObjectColor);
                    }
                    else if(triangleMesh.IsTextureFilled)
                    {
                        // get color from texture
                        int y = _scanLineProcedure.CurrentY;
                        // if it is drawing inside of offset 
                        if (x >= triangleMesh._offset && x < (triangleMesh._offset + triangleMesh._xSpan) && y >= triangleMesh._offset && y < triangleMesh._offset + triangleMesh._ySpan)
                        {
                            directBitmap.SetPixel(x, y, triangleMesh._textureBitmap.GetPixel(x - triangleMesh._offset, y - triangleMesh._offset));
                        }
                        else
                        {
                            directBitmap.SetPixel(x, y, Color.White);
                        }

                    }
                }
                
            }
            
            _scanLineProcedure.UpdateAETAfterDrawing();
            
        }
    }
}