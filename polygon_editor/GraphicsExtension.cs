
using System.Runtime.Serialization;

namespace polygon_editor
{
    public static class GraphicsExtension
    {
        private static float Height;
        public static void SetParameters(this System.Drawing.Graphics graphics, float height)
        {
           Height = height;
        }

        public static void SetTransform(this System.Drawing.Graphics graphics)
        {
            graphics.PageUnit = System.Drawing.GraphicsUnit.Millimeter;
            graphics.TranslateTransform(0,Height);
            graphics.ScaleTransform(1.0f,-1.0f );
        }

        public static void DrawPoint(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Point point)
        {
            g.SetTransform();
            System.Drawing.PointF p = point.Position.ToPointF();
            g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
            g.ResetTransform();
        }

        public static void DrawLine(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Line line)
        {
            g.SetTransform();
            g.DrawLine(pen, line.StartPoint.ToPointF(), line.EndPoint.ToPointF());
            g.ResetTransform();

        }
    }
}