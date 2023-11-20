using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using filling_triangles.Entities;

namespace filling_triangles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            isFill = false;
            isMeshVisible = true;
        }
        
        private bool isFill;
        private bool isMeshVisible;
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
            
            // create a table of edges but not a list
            List<LineNode> edges = new List<LineNode>();
            

            // create a list of active edges
            for (int i = 1; i <= columnCountX; i++)
            {
                for (int j = 1; j <= columnCountY; j++)
                {
                    // g.DrawRectangle(pen, x + i * stepX, y + j * stepY, stepX, stepY);

                    Point upperLeft = new Point(x, y); // upper left
                    Point upperRight = new Point((int)(x + stepX), y); // upper right
                    Point downLeft = new Point(x, (int)(y + stepY)); // down left
                    Point downRight = new Point((int)(x + stepX), (int)(y + stepY)); // down right
                    
                    // lines of a square with one diagonal (two triangles)
                    LineNode upperLeftToUpperRight = new LineNode(new Point2D(upperLeft.X, upperLeft.Y),
                        new Point2D(upperRight.X, upperRight.Y));
                    LineNode upLeftToDownLeft = new LineNode(new Point2D(upperLeft.X, upperLeft.Y),
                        new Point2D(downLeft.X, downLeft.Y));
                    LineNode downLeftUpperRight = new LineNode(new Point2D(upperRight.X, upperRight.Y),
                        new Point2D(downLeft.X, downLeft.Y));
                    LineNode upperRightToDownRight = new LineNode(new Point2D(downRight.X, downRight.Y),
                        new Point2D(upperRight.X, upperRight.Y));
                    LineNode downRightToDownLeft = new LineNode(new Point2D(downRight.X, downRight.Y),
                        new Point2D(downLeft.X, downLeft.Y));

                    
                    // by this we avoid adding duplicate edges
                    // add edges to the edge table but avoid duplicates
                    if (y == 0)
                    {
                        // this is first column so add upperLeftDownLeft
                        edges.Add(upLeftToDownLeft);
                    }

                    if (x == 0)
                    {
                        // this is fist row do add upperLeftToUpperRight
                        edges.Add(upperLeftToUpperRight);
                    }

                    edges.Add(downLeftUpperRight);
                    edges.Add(upperRightToDownRight);
                    edges.Add(downRightToDownLeft);
                    
                    
                    if (isMeshVisible)
                    {
                        Point[] topTriangle = { upperLeft, upperRight, downLeft };
                        Point[] lowerTriangle = { downRight, upperRight, downLeft };
                        g.DrawPolygon(pen, topTriangle);
                        g.DrawPolygon(pen, lowerTriangle);
                    }
                    
                    y += (int)stepY;
                    
                }
                x += (int)stepX;
                y = 0;

            }
            
            //bucket sort by lowest coordinate of p1 or p2

            if (isFill)// fill all triangles 
            {
                this.FillAllTriangles(edges, columnCountY);
            }
            
        

        }
        
        private void FillAllTriangles(List<LineNode> edges, int columnCountY)
        {
                // create a list of buckets
            List<LineNode>[] buckets = new List<LineNode>[columnCountY + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<LineNode>();
            }
            
            // add edges to the buckets
            foreach (LineNode edge in edges)
            {
                // find lowest coordinate of p1 or p2
                int lowestY = edge.p1.Y < edge.p2.Y ? edge.p1.Y : edge.p2.Y;
                int lowestX = edge.p1.X < edge.p2.X ? edge.p1.X : edge.p2.X;
                // which one is lowest ?
                int lowest = lowestY < lowestX ? lowestY : lowestX;
                
                buckets[lowest].Add(edge);
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

        private void triangleMeshVisibilityButton_Click(object sender, EventArgs e)
        {
            isMeshVisible = !isMeshVisible;
            triangleMeshVisibilityButton.Text = isMeshVisible ? "Hide" : "Show";
            graphicsPanel.Refresh();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            // Update the text box color if the user clicks OK 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                chosenColorPanel.BackColor =  colorDialog1.Color;
        }
    }
}