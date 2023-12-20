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
       
        List<Edge> scaledEdges = new List<Edge>();
        List<Vertex> vertices = new List<Vertex>();
        if (triangleMesh.ShouldRotateOnce)
        {
            // double X1 = (x + 1)/2 * triangleMesh.Width;
            // double Y1 = (y + 1)/2 * triangleMesh.Height;
            foreach (var edge in face.Edges)
            {
                double X1 = (edge.V1.X + 1)/2 * triangleMesh.Width;
                double Y1 = (edge.V1.Y + 1)/2 * triangleMesh.Height;
                double X2 = (edge.V2.X + 1)/2 * triangleMesh.Width;
                double Y2 = (edge.V2.Y + 1)/2 * triangleMesh.Height;
                // scaledEdges.Add(new Edge(new Vertex(X1,Y1,0), new Vertex(X2,Y2,0)));
            }
            
        }
        else
        {
            // scale each vertise to fit the screen
            foreach (var edge in face.Edges)
            {
                double X1 = edge.V1.X* triangleMesh.Width;
                double Y1 = edge.V1.Y * triangleMesh.Height;
                double X2 = edge.V2.X * triangleMesh.Width;
                double Y2 = edge.V2.Y * triangleMesh.Height;
                Point3D p1 = new Point3D(X1,Y1,edge.V1.Z*1000);
                Vertex one = new Vertex(p1, edge.V1.Id, edge.V1.NormalVector);
                Point3D p2 = new Point3D(X2,Y2,edge.V2.Z*1000);
                Vertex two = new Vertex(p2, edge.V2.Id, edge.V2.NormalVector);
                vertices.Add(one);
                vertices.Add(two);
                scaledEdges.Add(new Edge(one,two));
            }
                       
        }
        
        _scanLineProcedure.Init(scaledEdges);
        
       
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
                        
                    
                    canvas.SetPixel(x, y,color);
                    

                }
                
            }
            
            _scanLineProcedure.UpdateAETAfterDrawing();
            
        }
    }
}