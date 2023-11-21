using System.Collections.Generic;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class ScanLine
{
    //edge table
    private List<AETNode>[] _et;
    // active edge table
    private List<AETNode> _aet;

    private int _currentY;
    private int _edgesCount;

    public int CurrentY => _currentY;

    public ScanLine()
    {
        _et = new List<AETNode>[1000];
        _aet = new List<AETNode>();
        _edgesCount = 0;
    }

    public void Start(List<Edge> edges)
    {
        int globalYMin = 2500;
        _edgesCount = edges.Count;

    }

}