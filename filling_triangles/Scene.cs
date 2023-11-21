using System;
using System.Drawing;
using System.Windows.Forms;
using filling_triangles.Graphics;

namespace filling_triangles
{
    public class Scene
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
        
        // contructor that takes pictureBox
        public Scene(PictureBox pictureBox, TriangleMesh triangleMesh)
        {
            _pictureBox = pictureBox;
            _directBitmap = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            _triangleMesh = triangleMesh;
        }


        public void Render(object? obj, EventArgs arg)
        {
            // draw all triangles
            // fill all faces in triangleMesh
            
            
            //get image from bitmap generated from triangle mesh 
            using var graphics = System.Drawing.Graphics.FromImage(this._directBitmap.Bitmap);
            //draw one line
            graphics.DrawLine(Pens.Black,0,0,100,100);
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