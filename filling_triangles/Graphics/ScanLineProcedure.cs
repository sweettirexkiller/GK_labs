using System;
using System.Collections.Generic;
using System.Linq;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class ScanLineProcedure
{
    //edge table
    private List<AETNode>[] _et;
    // active edge table
    private List<AETNode> _aet;

    private int _currentY;
    private int _edgesCount;

    public int CurrentY => _currentY;
 
    public IEnumerable<int> Intersections => _aet.Select(node => node.X);

    public ScanLineProcedure()
    {
        _et = new List<AETNode>[2500];
        _aet = new List<AETNode>();
        _edgesCount = 0;
    }

    public void Init(List<Edge> faceEdges)
    {
        int globalYMin = 2500;
        _edgesCount = faceEdges.Count;
        
        // find global y min
        foreach (var edge in faceEdges)
        {
            if (Math.Min(edge.V1.Y, edge.V2.Y) < globalYMin)
            {
                globalYMin = (int)Math.Min(edge.V1.Y, edge.V2.Y);
            }
        }

        
        // foreach edge find yMin and if slope is not 0 then add this edge to EDGE TABLE
        foreach (Edge edge in faceEdges)
        {
            int yMin = (int)Math.Min(edge.V1.Y, edge.V2.Y);
            // if (edge.Slope == 0)
            // {
            //     _edgesCount--;
            //     continue;
            // }
            
            // if and edge is in AET it means that at this hight this edge has some points
            _et[yMin] ??= new List<AETNode>();//if null then create new list
            // add a node to Active Edge Table with y of yMax, x of yMin and slope
            _et[yMin].Add(new AETNode((int)Math.Max(edge.V1.Y, edge.V2.Y), edge.V1.Y < edge.V2.Y ? edge.V1.X : edge.V2.X, edge.Slope));
            _et[yMin].Sort();
        }
        
        // Active Edge table has all edges at currentY 
        _currentY = globalYMin;
        
    }

    // scan line procedure is finished when there is no edges in AET and ET
    public bool IsDone => !(_aet.Any() || _edgesCount != 0);
  

    // updating active edge table means going one pixel up in Y direction and finding 
    
    public void UpdateAETBeforeDrawing()
    {
        // first for current hight add all of  references AET and subtract it from number of edges passed to ScanLineProcedure
        if (_et[_currentY] is not null)
        {
            foreach(AETNode node in _et[_currentY])
            {
                // to powinno byc o(1)
                _aet.Add(node);
                _edgesCount--;
            }
        }
        // clear this hight in ET
        _et[_currentY]?.Clear();
        _aet.Sort();
       
      
        
    }

    public void UpdateAETAfterDrawing()
    {
        // if an edge at this hight has yMax equal to or lower than currentY then remove it from AET
        _aet.RemoveAll(node => node.YMax <= _currentY);
        
        // increment currentY
        _currentY+=1;
        // just go one pixel up in Y direction on the slope of each edge (it will be removed from active edge table if it is below currentY)
        _aet.ForEach(node => node.UpdateX());
    }
}