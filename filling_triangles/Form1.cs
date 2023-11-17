using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filling_triangles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            // draw triangles and lines
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 1);
            // draw triangles mesh 
            int x = 0;
            int y = 0;
            // find graphis width and height
            float width = g.VisibleClipBounds.Width;
            float height = g.VisibleClipBounds.Height;
            int columnCountX = (int)this.columnCountX.Value;
            int columnCountY = (int)this.columnCountY.Value;
            float stepX = width / columnCountX;
            float stepY = height / columnCountY;
            for (int i = 1; i <= columnCountX; i++)
            {
                for (int j = 1; j <= columnCountY; j++)
                {
                    // g.DrawRectangle(pen, x + i * stepX, y + j * stepY, stepX, stepY);
                    
                    Point p1 = new Point(0, 0); // upper left
                    Point p2 = new Point((int) (x + i * stepX), 0); // upper right
                    Point p3 = new Point(0, (int)(y + j * stepY)); // down left
                    Point[] points1 = { p1, p2, p3 };
                    g.DrawPolygon(pen, points1);
                    
                    Point p4 = new Point((int) (x + i * stepX), (int)(y + j * stepY));// down right
                    Point p5 = new Point((int) (x + i * stepX), 0); // upper right
                    Point p6 = new Point(0, (int)(y + j * stepY)); // down left
                    Point[] points2 = { p4, p5, p6 };
                    g.DrawPolygon(pen, points2);
                }
                
            }

        }

        private void columnCountX_ValueChanged(object sender, EventArgs e)
        {
            graphicsPanel.Refresh();
        }

        private void columnCountY_ValueChanged(object sender, EventArgs e)
        {
            graphicsPanel.Refresh();
        }
    }
}