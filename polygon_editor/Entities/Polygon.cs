using System.Collections.Generic;

namespace polygon_editor.Entities
{
    public class Polygon
    {
        private List<Point> points;
        
        //constructor
        public Polygon()
        {
            points = new List<Point>();
        }
        
        
        public void AddPoint(Point point)
        {
            points.Add(point);
            
            // automatically add a line between the last two points
            
        }
        
        
    
    }
}