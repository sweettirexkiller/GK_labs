using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace octree_visual.Entities
{
    
    //https://www.cubic.org/docs/octree.htm
    
    // Octree is a tree where each node has up to 8 children. Leaf node has no active children.
    // Each leaf node have a number of pixels with this color (pixel_count) and color value.
    
    public class OctreeNode
    {
        OctreeNode[] children;

        public long red;
        public long green;
        public long blue;
        public long references;
        public bool isLeaf;
        public int level;
        public int middleX;
        public int middleY;
        OctreeNode parent;
        
        // constructor
        public OctreeNode(int? level, OctreeNode parent = null)
        {
            isLeaf = false;
            red = 0;
            blue = 0;
            green = 0;
            references = 0;
            children = new OctreeNode[8];
            
            for (int i = 0; i < 8; i++)
            {
                children[i] = null;
            }
            
            if(level != null)
            {
                this.level = (int) level;
            }
            
            this.parent = parent;
        }
        
        
        // insert color into octree
        //We start at the root-node of the tree and examine our RGB-Trippes.
        //From each element we take the most significant bit combine them into a index-byte
        //like this: 00000RGB where R,G, and B are the bits we have extracted.
        //The higest value this byte could have is 7 (binary 00000111) and the
        //lowest is zero (binary 00000000).
        //This byte is an index of the child-nodes we have. 

        public void InsertColor(OctreeNode root, int red, int green, int blue)
        {
            OctreeNode node = root;
            int[] indexes = new int[8];
            for (int level = 7; level >= 0; level--)
            {
                indexes[level] = GetColorIndex(red, green, blue, level);
            }
       
            // indexes are 0 to 7 and they represent the number children of the node on that level
            // if the child node is null, create a new node and insert it into the tree
            // level 7 is root and roots children 
            for (int level = 7; level > 0; level--)
            {
                if (node.children[indexes[level]] == null)
                {
                    node.children[indexes[level]] = new OctreeNode(node.level - 1, node); 
                }
                node = node.children[indexes[level]];
                if(node.level == 0)
                {
                    node.isLeaf = true;
                    node.red += red;
                    node.green += green;
                    node.blue += blue;
                    node.references++;
                }
            }

        }
        
        
        //InitializeOctree
        int GetColorIndex(int red, int green, int blue, int level)
        {
            // convert each color to binary and get the most significant bit at level
            int r = (red >> level) & 0x01; // 0x01 is 00000001 in binary
            int g = (green >> level) & 0x01;
            int b = (blue >> level) & 0x01;
            // combine the bits into a 0 to 7 decimal value
            return (r << 2) | (g << 1) | b;
        }

        public void BuildOctree(Image image)
        {
            // find all unique colors in image
            // for each color insert color into octree
            
            // find all unique colors in image
            
            InsertColor(this, 90, 113, 157);
            InsertColor(this, 255, 100, 0);
            InsertColor(this, 0, 255, 0);
            InsertColor(this, 0, 100, 255);
            
        }

        public int[] CountNodesOnLevels()
        {
            int[] nodesOnLevel = new int[8];
            for (int i = 0; i < 8; i++)
            {
                nodesOnLevel[i] = 0;
            }

            // count how many nodes are on each level with BFS
            Queue<OctreeNode> queue = new Queue<OctreeNode>();
            queue.Enqueue(this);
            int currentLevel = 7;
            while (queue.Count > 0)
            {
                OctreeNode node = queue.Dequeue();
                if (node.level != currentLevel)
                {
                    currentLevel = node.level;
                }
                nodesOnLevel[currentLevel]++;
                if (node.children != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (node.children[i] != null)
                        {
                            queue.Enqueue(node.children[i]);
                        }
                    }
                }
            }
            
            return nodesOnLevel;
        }

        public void DrawOctree(PictureBox octreePictureBox)
        {
            int offsetY = 5;
            int offsetX = 5;
            int width = octreePictureBox.Width;
            int height = octreePictureBox.Height;
            int heightStep = (height - 2*offsetY) / 8;
            
            using (Graphics g = Graphics.FromImage(octreePictureBox.Image))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 1);
                // count how many nodes are on each level
                int[] nodesOnLevel = CountNodesOnLevels();
                // find width for each node in each level
                int[] widthOfSpaceForNode = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    widthOfSpaceForNode[i] = (width - 2*offsetX) / nodesOnLevel[i];
                }
                
                // draw horizontal lines as borders for each level
                // int currentY = offsetY + heightStep;
                // for (int i = 0; i < 8; i++)
                // {
                //     g.DrawLine(pen, offsetX, currentY, width - offsetX, currentY);
                //     currentY += heightStep;
                // }
                
                // draw octree with BFS
                Queue<OctreeNode> queue = new Queue<OctreeNode>();
                queue.Enqueue(this);
                int currentLevel = 7;
                int x = offsetX + widthOfSpaceForNode[currentLevel] / 2;
                int y = offsetY;
                while (queue.Count > 0)
                {
                    OctreeNode node = queue.Dequeue();
                    if (node.level != currentLevel)
                    {
                        currentLevel = node.level;
                        x = offsetX + widthOfSpaceForNode[currentLevel] / 2;
                        y = offsetY + (7 - currentLevel) * heightStep;
                    }
                    // in the middle of the space for the node
                    node.middleX = x;
                    node.middleY = y;
                    g.DrawEllipse(pen, x, y, 3, 3);
                    x += widthOfSpaceForNode[currentLevel];
                    
                    if(node.parent != null)
                    {
                        g.DrawLine(pen, node.middleX, node.middleY, node.parent.middleX, node.parent.middleY);
                    }
                    
                    if (node.children != null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (node.children[i] != null)
                            {
                                queue.Enqueue(node.children[i]);
                            }
                        }
                    }
                }
            
            }
            
            // when done with all drawing you can enforce the display update by calling:
            octreePictureBox.Refresh();

        }
        
        
    }
    
    
}