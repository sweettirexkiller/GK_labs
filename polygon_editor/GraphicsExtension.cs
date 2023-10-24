
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using polygon_editor.Entities;

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
            pen.Width = (float)line.Thikness;
            g.SetTransform();
            g.DrawLine(pen, line.StartPoint.Position.ToPointF(), line.EndPoint.Position.ToPointF());
            g.ResetTransform();

        }
        
        public static void DrawLineBresenham(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Line line)
        {
            g.SetTransform();

            double x = line.StartPoint.Position.X;
            double y = line.StartPoint.Position.Y;
            double x2 =  line.EndPoint.Position.X;
            double y2 = line.EndPoint.Position.Y;
            

            double w = x2 - x ;
            double h = y2 - y ;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0 ;
            if (w<0) dx1 = -1 ; else if (w>0) dx1 = 1 ;
            if (h<0) dy1 = -1 ; else if (h>0) dy1 = 1 ;
            if (w<0) dx2 = -1 ; else if (w>0) dx2 = 1 ;
            double longest = Math.Abs(w) ;
            double shortest = Math.Abs(h) ;
            if (!(longest>shortest)) {
                longest = Math.Abs(h) ;
                shortest = Math.Abs(w) ;
                if (h<0) dy2 = -1 ; else if (h>0) dy2 = 1 ;
                dx2 = 0 ;            
            }
            double numerator = longest  / 2 ;
            Brush aBrush = (Brush)Brushes.Black;
            for (int i=0;i<=longest;i++) {
                
                g.FillRectangle(aBrush,(float) x,(float) y, (float)1, (float)1);
                
                numerator += shortest ;
                if (!(numerator<longest)) {
                    numerator -= longest ;
                    x += dx1 ;
                    y += dy1 ;
                } else {
                    x += dx2 ;
                    y += dy2 ;
                }
            }
            
            
            g.ResetTransform();
        }

        public static Vector3 LineLineIntersection(Entities.Line line1, Entities.Line line2, bool extended = false)
        {
            Vector3 result;
            Vector3 p1 = line1.StartPoint.Position;
            Vector3 p2 = line1.EndPoint.Position;
            Vector3 p3 = line2.StartPoint.Position;
            Vector3 p4 = line2.EndPoint.Position;
            
            
            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;
            
            double denominator = (dx12*dy34 - dy12*dx34);
            double k1 = ((p1.X-p3.X)*dy34+(p3.Y - p1.Y)*dx34)/denominator;

            if (double.IsInfinity(k1))
                return new Vector3(double.NaN, double.NaN);
            
            
            result = new Vector3(p1.X + k1*dx12, p1.Y + k1*dy12);

            if (extended)
            {
                return result;
            }
            else
            {
                if(IsPointOnLine(line1,result) && IsPointOnLine(line2, result))
                    return result;
                else
                    return new Vector3(double.NaN, double.NaN);
            }
        }

        private static bool IsPointOnLine(Line line1, Vector3 point)
        {
            return IsEqual(line1.Length, line1.StartPoint.DistanceFrom(point) + line1.EndPoint.DistanceFrom(point));
        }

        private static double Epsilon = 1e-12;
        private static bool IsEqual(double d1, double d2)
        {
            return IsEqual(d1, d2, Epsilon);
        }
        
        private static bool IsEqual(double d1, double d2, double eps)
        {
            return IsZero(d1 - d2, eps);
        }

        private static bool IsZero(double d1, double eps)
        {
            return System.Math.Abs(d1) <= eps;
        }
    }
}