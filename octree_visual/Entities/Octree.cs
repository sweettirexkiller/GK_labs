using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public static List<OctreeNode>[] nodesOnLevelList;
        public long blue;
        public long references;
        public bool isLeaf;
        public int level;
        public float middleX;
        public float middleY;
        OctreeNode parent;
        public int colorCount;

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

            // initialize list of nodes on each level only for root node
            if (parent == null)
            {
                nodesOnLevelList = new List<OctreeNode>[8];
                for (int i = 0; i < 8; i++)
                {
                    nodesOnLevelList[i] = new List<OctreeNode>();
                }
                // root node is on level 7
                nodesOnLevelList[7].Add(this);
            }
           

            if (level != null)
            {
                this.level = (int)level;
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
                    nodesOnLevelList[level - 1].Add(node.children[indexes[level]]);
                }
                
                

                node = node.children[indexes[level]];
                if (node.level == 0)
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
            HashSet<Color> uniqueColors = new HashSet<Color>();
            Bitmap bitmap = new Bitmap(image);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);
                    uniqueColors.Add(pixelColor);
                    InsertColor(this, pixelColor.R, pixelColor.G, pixelColor.B);
                }
            }

            colorCount = uniqueColors.Count;
            
        }

        public int[] CountNodesOnLevels()
        {
            int[] nodesOnLevel = new int[8];
            for (int i = 0; i < 8; i++)
            {
                nodesOnLevel[i] = 0;
            }

            // count how many nodes are on each level with BFS
            // Queue<OctreeNode> queue = new Queue<OctreeNode>();
            // queue.Enqueue(this);
            // int currentLevel = 7;
            // while (queue.Count > 0)
            // {
            //     OctreeNode node = queue.Dequeue();
            //     if (node.level != currentLevel)
            //     {
            //         currentLevel = node.level;
            //     }
            //
            //     nodesOnLevel[currentLevel]++;
            //     if (node.children != null)
            //     {
            //         for (int i = 0; i < 8; i++)
            //         {
            //             if (node.children[i] != null)
            //             {
            //                 queue.Enqueue(node.children[i]);
            //             }
            //         }
            //     }
            // }
            
            // instead of BFS just count nodes on each level with nodesOnLevelList
            
            for (int i = 0; i < 8; i++)
            {
                nodesOnLevel[i] = nodesOnLevelList[i].Count;
            }

            return nodesOnLevel;
        }

        public void DrawOctree(PictureBox octreePictureBox)
        {
            int offsetY = 5;
            int offsetX = 5;
            int width = octreePictureBox.Width;
            int height = octreePictureBox.Height;
            int heightStep = (height - 2 * offsetY) / 8;

            using (Graphics g = Graphics.FromImage(octreePictureBox.Image))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 1);
                // count how many nodes are on each level
                int[] nodesOnLevel = CountNodesOnLevels();
                // find width for each node in each level
                float[] widthOfSpaceForNode = new float[8];
                for (int i = 0; i < 8; i++)
                {
                    if (nodesOnLevel[i] > 0)
                    {
                        widthOfSpaceForNode[i] = (width - 2 * offsetX) / nodesOnLevel[i];
                    } else {
                        widthOfSpaceForNode[i] = width - 2 * offsetX;
                    }
                }

                // draw octree with BFS
                Queue<OctreeNode> queue = new Queue<OctreeNode>();
                queue.Enqueue(this);
                int currentLevel = 7;
                float x = offsetX + widthOfSpaceForNode[currentLevel] / 2;
                float y = offsetY;
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
                    if(node.isLeaf)
                    {
                        g.FillEllipse(new SolidBrush(Color.FromArgb((int)(node.red / node.references), (int)(node.green / node.references), (int)(node.blue / node.references))), x, y, 5, 5);
                    } else {
                        g.DrawEllipse(pen, x, y, 3, 3);
                    }
                    x += widthOfSpaceForNode[currentLevel];

                    if (node.parent != null)
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
        
        
        // remove recursion from this function
        public long GetChildrenReferenceSum(OctreeNode node)
        {
            if(node.isLeaf)
            {
                return node.references;
            }
            
            if (node.children == null)
            {
                return 0;
            }

            long sum = node.references;

            if (!node.isLeaf)
            {
                for(int i = 0; i < 8; i++)
                {
                    if (node.children[i] != null)
                    {
                        sum += node.children[i].references;
                    }
                }
            }

            return sum;
        }



        // reduce octree to value colors function 
        // Reduction
        // To make image color palette with for example 256 colors maximum,
        // from palette with far more colors the tree leaves must be reduced.
        //
        // The reduction of nodes:
        //
        //  As we have a sum of R, G and B values and the number of pixels with this color,
        // we can ADD ALL LEAVES PIXELS COUNT AND COLOR channels to parent node and make it a leaf node
        //  (we could not even remove it, because get leaves method will not go deeper if current node is leaf).
        //  Reduction continues while leaves count it more than needed maximum colors (in our case 256).
        //  The main disadvantage of this approach is that up to 8 leaves can be reduced from node and the palette could have only 248 colors (in worst case) instead of expected 256 colors.
        //  As soon as we've got count of leaves less or equal needed maximum colors we can build a palette.


        public void ReduceOctree(int reduceBy)
        {

            int maxColorCount = colorCount - reduceBy;
            // We count all the nodes that have a reference greater than zero (only leafes can have a reference). 
            // WHILE (number of leafes>maxColorCount)
            //  search the node, where the sum of the childs references is minimal and reduce it.
            // ENDWHILE
            
            if(children == null || colorCount <= reduceBy || colorCount == 1)
            {
                return;
            }
            int numberOfLeaves = colorCount;
            while (numberOfLeaves > maxColorCount)
            {
                // search the node, where the sum of the childs references is minimal and reduce it.
                OctreeNode nodeToReduce = null;
                long minReferences = long.MaxValue;
                // Queue<OctreeNode> queue = new Queue<OctreeNode>();
                // queue.Enqueue(this);
                // while (queue.Count > 0)
                // {
                //     OctreeNode node = queue.Dequeue();

                    // sprawdzic czy node ma więcej niż 1 dziecko i czy nie jest liściem 
                    // if(!node.isLeaf && node.children.Count(x => x != null) > 1){
                    //
                    //     long sumOfReferences = RecGetChildrenReferenceSum(node);
                    //
                    //     if (sumOfReferences < minReferences)
                    //     {
                    //         minReferences = sumOfReferences;
                    //         nodeToReduce = node;
                    //     }
                    //
                    // }
                    
                    // szukaj minimum tylko na najniższym poziomie na ktorym jeszcze sa wierzcholki w NodeOnLevelList
                    //     if (node.children != null)
                    //     {
                    //         for (int i = 0; i < 8; i++)
                    //         {
                    //             if (node.children[i] != null)
                    //             {
                    //                 queue.Enqueue(node.children[i]);
                    //             }
                    //         }
                    //     }
                // }
                
                // level 7 is root , level 0 is leafs
                for (int i = 1; i < 8; i++)
                {
                    // until there are nodes on level remove only from second lowest level
                    if(nodesOnLevelList[i].Count > 0 && nodesOnLevelList[i].Count(node => !node.isLeaf) > 0)
                    {
                        // find node with minimum references on this level
                        bool found = false;
                        foreach (var octreeNode in nodesOnLevelList[i])
                        {
                            if(octreeNode.isLeaf)
                            {
                                continue;
                            }
                            long sumOfReferences = GetChildrenReferenceSum(octreeNode);
                            if (sumOfReferences < minReferences)
                            {
                                minReferences = sumOfReferences;
                                nodeToReduce = octreeNode;
                                found = true;
                            }
                        }

                        if (found)
                        {
                            break;
                        }
                    }
                }

                
                
                // reduce nodeToReduce
                if (nodeToReduce != null)
                {

                    int numberOfLeavesRemoved = ReduceNode(nodeToReduce);
                    // remove this node from nodesOnLevelList
                   

                    // if deleted more than one children then it means that we have less leaves (colors)
                    if (numberOfLeavesRemoved > 1)
                    {
                        numberOfLeaves -= (numberOfLeavesRemoved - 1);
                    }
                    nodeToReduce.isLeaf = true;
                    
                }
            }
            
            colorCount = numberOfLeaves;
            
        }
        
        
        private int ReduceNode(OctreeNode node)
        {
            // we must return total number of leaves removed from the tree
            
            
            if(node.isLeaf)
            {
                return 0;
            }
            
            int numberOfLeavesRemoved = 0;
            
            for (int i = 0; i < 8; i++)
            {
                if (node.children[i] != null)
                {
                    // numberOfLeavesRemoved += ReduceNode(node.children[i]);
                    node.references += node.children[i].references;
                    node.red += node.children[i].red;
                    node.green += node.children[i].green;
                    node.blue += node.children[i].blue;
                    if (node.children[i].isLeaf)
                    {
                        numberOfLeavesRemoved++;
                    }
                    // remove this child from nodesOnLevelList
                    nodesOnLevelList[node.children[i].level].Remove(node.children[i]);
                    node.children[i] = null;
                    
                }
            }
            
            // returns number of leaves removed
        
            return numberOfLeavesRemoved;
        }


        public Color GetReducedColor(Color pixelColor)
        {
            // find levels of the color in the tree
            int[] indexes = new int[8];
            for (int level = 7; level >= 0; level--)
            {
                indexes[level] = GetColorIndex(pixelColor.R, pixelColor.G, pixelColor.B, level);
            }
            
            // find last node on the path of indexes
            OctreeNode node = this;
            for (int level = 7; level > 0; level--)
            {
                if (node.children[indexes[level]] == null)
                {
                    break;
                }

                node = node.children[indexes[level]];
            }
            
            // return color of the node
            if (node.references > 0)
            {
                return Color.FromArgb((int)(node.red / node.references), (int)(node.green / node.references), (int)(node.blue / node.references));
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
            
        }
    }

    

}