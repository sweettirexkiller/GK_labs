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
    public void FillTriangle(Face face, DirectBitmap directBitmap)
    {
        // feels edges table
        _scanLineProcedure.Init(face.Edges);
        
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
                    directBitmap.SetPixel(x, _scanLineProcedure.CurrentY,Color.DodgerBlue );
                }
                
            }
            
            _scanLineProcedure.UpdateAETAfterDrawing();
            
        }
    }
}