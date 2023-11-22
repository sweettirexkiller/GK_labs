using System;
using System.Drawing;
using System.Windows.Forms;
using filling_triangles.Graphics;

namespace filling_triangles
{
    public class Drawing
    {
        private PictureBox _pictureBox;
        private DirectBitmap _directBitmap;
        private TriangleMesh _triangleMesh;
        private Painter _painter;
        
        public DirectBitmap Bitmap
        {
            get => _directBitmap;
            set => _directBitmap = value;
        }
        
        // constructor that takes pictureBox
        public Drawing(PictureBox pictureBox, TriangleMesh triangleMesh)
        {
            _pictureBox = pictureBox;
            _directBitmap = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            _triangleMesh = triangleMesh;
            _painter = new Painter();
        }


        public void StartDrawing(object? obj, EventArgs arg)
        {
            // draw all triangles
            // fill all faces in triangleMesh
            _directBitmap = new DirectBitmap(_pictureBox.Width, _pictureBox.Height);
           
           _triangleMesh.PaintTriangles(_painter,_directBitmap);
           
           if(_triangleMesh.IsMeshVisible)
               _triangleMesh.DrawAllEdges(_directBitmap);

            //get image from bitmap generated from triangle mesh 
            //draw one line
            _pictureBox.Image = _directBitmap.Bitmap;
            //clear the picture box
            _pictureBox.Invalidate(new Rectangle(0,0,_directBitmap.Width, _directBitmap.Height));
            // update picture box
            _pictureBox.Update();
        }
        
        public void AdjustSizes()
        {
            UpdateBitmap();
            // _triangleMesh.FitToCanvas(_di)
        }
        
        public void UpdateBitmap()
        {
            
        }

        
        
    }
}