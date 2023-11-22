using System;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class AETNode: IComparable<AETNode>
{
    // z wykładów
    public readonly int YMax;
    private double _x;
    private readonly double _m;

    public AETNode(int yMax, double x, double m)
    {
        this.YMax = yMax;
        this._x = x;
        _m = m == 0 ? double.MaxValue : 1.0 / m;
    }


    public int X => (int)Math.Round(_x);

    public void UpdateX()
    {
        // move to next point on the line 
        _x = Math.Abs(_m - GeometryUtils.Infinity) < 1e-7 ? _x : _x + _m;
    }
    
    //we use this for sort of Active Edge Table. We sort by x coordinate but if x is zero then we compare Ys
    public int CompareTo(AETNode? other)
    { 
        // if x coordinate is zero then compare Ys
        return _x == 0 ? YMax.CompareTo(other?.YMax) : _x.CompareTo(other?._x);
    }
}