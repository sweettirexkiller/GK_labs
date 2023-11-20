namespace filling_triangles.Entities
{
    public class Point2D
    {
        // a class with x and y coordinate
        private int x;  
        private int y;

        // x and y getter and setter
        public int X
        {
            get => x;
            set => x = value;
        }
        
        //y setter and getter
        public int Y
        {
            get => y;
            set => y = value;
        }
        
        //constructor
        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        //substitution operation
        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.x - p2.x, p1.y - p2.y);
        }
        
        //addition operation
        public static Point2D operator +(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.x + p2.x, p1.y + p2.y);
        }
        
        
    }
}