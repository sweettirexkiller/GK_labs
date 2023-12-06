using System;
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
        
        // constructor
        public OctreeNode()
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
            for (int level = 7; level >= 0; level--)
            {
                if (node.children[indexes[level]] == null)
                {
                    node.children[indexes[level]] = new OctreeNode();
                }
                node = node.children[indexes[level]];
                if(level == 0)
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
            
            InsertColor(this, 90, 113, 157);
            
        }

        public void DrawOctree(PictureBox octreePictureBox)
        {
            
        }
    }
    
    
}