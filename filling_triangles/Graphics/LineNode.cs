namespace filling_triangles.Entities
{
    public class LineNode
    {
        // create a line class with two points
        public Point2D p1 { get; set; }
        public Point2D p2 { get; set; }
        // public LineNode next { get; set; }
        public float dxbydy { get; set; }
        public int ymax { get; set; }
        public int xmin { get; set; }
        

        //constructor
        public LineNode(Point2D start, Point2D end)
        {
            this.p1 = start;
            this.p2 = end;
            ymax = p2.Y > p1.Y ? p2.Y : p1.Y;
            xmin = p2.X < p1.X ? p2.X : p1.X;
            // next = null;
            dxbydy = (float) (p2.X - p1.X) / (p2.Y - p1.Y);
        }
        
        
    }
}