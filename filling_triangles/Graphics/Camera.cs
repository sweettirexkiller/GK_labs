using System.Numerics;

namespace filling_triangles.Graphics;

public class Camera
{
    Vector3 _position;
    Vector3 _target;
    Vector3 _upVector;
    
    // setters and getters
    public Vector3 Position
    {
        get => _position;
        set => _position = value;
    }
    
    public Vector3 Target
    {
        get => _target;
        set => _target = value;
    }
    
    public Vector3 UpVector
    {
        get => _upVector;
        set => _upVector = value;
    }
    public Camera(Vector3 position, Vector3 target, Vector3 upVector)
    {
        _position = position;
        _target = target;
        _upVector = upVector;
    }
}