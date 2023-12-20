using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class Brush
{
    
    //props
    private ScanLineProcedure _scanLineProcedure;
    //constructor
    public Brush()
    {
        // scan line procedure accepts triangle and fill it 
        
        _scanLineProcedure = new ScanLineProcedure();
    }
    public void FillTriangle(TriangleMesh triangleMesh, Face face, DirectBitmap canvas, Lamp lamp)
    {
        // feels edges table
        _scanLineProcedure.Init(face.Edges);
        
        var vertices = face.Vertices;
        // translate each vertex to middle
        ColorCalculator colorCalculator = new ColorCalculator(lamp, vertices, triangleMesh);
        
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
                    // get color from texture
                        Color color = colorCalculator.CalculateColor(x,_scanLineProcedure.CurrentY);
                        int y = _scanLineProcedure.CurrentY;
                        // int Y = _scanLineProcedure.CurrentY;
                        // int X = x;
                        //
                            if (triangleMesh.ShouldRotateOnce)
                            {
                               
                                    // //1. translate to origin
                                    // X = X - triangleMesh.Width/2;
                                    // Y = Y - triangleMesh.Height/2;
                                    // // scale X and Y to <0,1>
                                    // // X = X / triangleMesh.Width;
                                    // // Y = Y / triangleMesh.Height;
                                    //
                                    // if (triangleMesh.AlfaForZRotation != 0.0)
                                    // {
                                    //     //2. rotate
                                    //     int newX = (int)(X*Math.Cos(triangleMesh.AlfaForZRotation) - Y*Math.Sin(triangleMesh.AlfaForZRotation));
                                    //     int newY = (int)(X*Math.Sin(triangleMesh.AlfaForZRotation) + Y*Math.Cos(triangleMesh.AlfaForZRotation));
                                    //     X = newX;
                                    //     Y = newY;
                                    // }
                                    // if (triangleMesh.BetaForXRotation != 0.0)
                                    // {
                                    //     // 2. rotate
                                    //     int newY = (int)(Y * Math.Cos(triangleMesh.BetaForXRotation) - triangleMesh.ZFunction(X, Y) * Math.Sin(triangleMesh.BetaForXRotation));
                                    //     int newZ = (int)(Y * Math.Sin(triangleMesh.BetaForXRotation) + triangleMesh.ZFunction(x, Y) * Math.Cos(triangleMesh.BetaForXRotation));
                                    //     Y = newY;
                                    //     // co zrobic z nowym Z?
                                    // }
                                    // //3. translate back
                                    // // un-scale
                                    // // X = X * triangleMesh.Width;
                                    // // Y = Y * triangleMesh.Height;
                                    //
                                    // X = X + triangleMesh.Width / 2;
                                    // Y = Y + triangleMesh.Height / 2;
                                    //
                                    // // if point is outside of canvas then skip it
                                    // if (X < 0 || X >= triangleMesh.Width || Y < 0 || Y >= triangleMesh.Height)
                                    // {
                                    //     continue;
                                    // }
                                    //
                                    // // draw only inside offset
                                    // if (X >= triangleMesh._offset && X < (triangleMesh._offset + triangleMesh._xSpan) && Y >= triangleMesh._offset && Y < triangleMesh._offset + triangleMesh._ySpan)
                                    // {
                                    //     canvas.SetPixel(X, Y,color);
                                    // }
                                    // else
                                    // {
                                    //     canvas.SetPixel(X,Y , Color.White);
                                    // }
                            }
                            else
                            {
                               
                                    canvas.SetPixel(x, y,color);
                               
                            }
                          
                            
                       
                }
                
            }
            
            _scanLineProcedure.UpdateAETAfterDrawing();
            
        }
    }
}