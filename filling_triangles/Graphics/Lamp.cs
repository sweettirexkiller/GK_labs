using System;
using System.Drawing;
using filling_triangles.Geometry;

namespace filling_triangles.Graphics;

public class Lamp
{
    private bool _isMovingRight;
    private int _radius;
    private Point _rotationCenter;
    private (double R, double G, double B) _color;
    
    public (double R, double G, double B) Color
    {
        get => _color;
        set => _color = value;
    }

    public Point3D Position { get; set; }
    public bool IsConstant { get; set; }
    public bool IsAnimated { get; set; }

    public Lamp(Point3D point, Color color, Point Center, int radius)
    {
        _isMovingRight = true; // zaczynamu od ruchu zgodnie ze wskazówkami zegara
        _radius = radius;
        _rotationCenter = Center;
        IsConstant = true;
        IsAnimated = false;
        _color = (color.R/255.0, color.G/255.0, color.B/2555.0);
        Position = new Point3D((int)point.X, (int)point.Y, (int)point.Z);
    }
    
    public void Rotate()
    {
        if(_isMovingRight)
        {
            Position.X+=15;
            // obliczanie pozycji na okregu
            Position.Y = -Math.Sqrt(Math.Max(_radius * _radius - Math.Pow(Position.X - _rotationCenter.X, 2), 0)) + _rotationCenter.Y;
        }
        else
        {
            Position.X-=15;
            // position on circle
            Position.Y = Math.Sqrt(Math.Max(_radius * _radius - Math.Pow(Position.X - _rotationCenter.X, 2), 0)) + _rotationCenter.Y;
        }
        
        // jesli jest dalej niz centrum + promien to kierunek zmieniany na lewo (godizna 15)
        if (Position.X >= _rotationCenter.X + _radius)
        {
            _isMovingRight = false;
        } // analogicznie w droga strone (godzina 9)
        else if (Position.X <= _rotationCenter.X - _radius)
        {
            _isMovingRight = true;
        }
     
    }
    
    public void ChangeHeight(int height)
    {
        Position.Z = height;
    }
    
}