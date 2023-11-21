using System.Collections.Generic;

namespace filling_triangles.Geometry
{
    public class Face
    {
        private List<Vertex> _vertices;
        private readonly List<Edge> _edges;
        
        public List<Vertex> Vertices
        {
            get => _vertices;
        }
        
        public List<Edge> Edges
        {
            get => _edges;
        }

        public Face(List<Vertex> vertices)
        {
            _vertices = vertices;
            _edges = new List<Edge>
            {
                new Edge(_vertices[0], _vertices[1]),
                new Edge(_vertices[1], _vertices[2]),
                new Edge(_vertices[2], _vertices[0])
            };
        }
    }
}