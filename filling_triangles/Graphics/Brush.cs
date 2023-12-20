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
       
        
        // create new face but in scaled coordinates
        List<Vertex> scaledVertices = new List<Vertex>();
       
        if (triangleMesh.ShouldRotateOnce)
        {
            foreach (Vertex v in face.Vertices)
            {
                // add scaled new vertex to list
                Vertex clone = v.Clone();
                clone.Project(triangleMesh.LookAt, triangleMesh.Perspective);
                clone.FitToScreenWithPerspective(triangleMesh.Width, triangleMesh.Height);
                scaledVertices.Add(clone);
            }
            
        }
        else
        {
            foreach (Vertex v in face.Vertices)
            {
                // add scaled new vertex to list
                Vertex clone = v.Clone();
                clone.FitToScreen(triangleMesh.Width, triangleMesh.Height);
                scaledVertices.Add(clone);
            }
        }
        
        
        Face faceToDraw = new Face(scaledVertices);
        _scanLineProcedure.Init(faceToDraw.Edges);
        
        var vertices = faceToDraw.Vertices;
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
                        
                    if(x < 0 || x >= canvas.Width || y < 0 || y >= canvas.Height)
                        continue;
                    
                    canvas.SetPixel(x, y,color);
                    

                }
                
            }
            
            _scanLineProcedure.UpdateAETAfterDrawing();
            
        }
    }
}