using System;
using System.Drawing;
using System.Windows.Forms;
using filling_triangles.Graphics;
using Brush = filling_triangles.Graphics.Brush;

namespace filling_triangles
{
    public class Painter
    {
        private PictureBox _pictureBox;
        private DirectBitmap _canvas;
        private TriangleMesh _triangleMesh;
        private Brush _brush;
        private Lamp _lamp;
        
        public DirectBitmap Canvas
        {
            get => _canvas;
            set => _canvas = value;
        }
        
        // constructor that takes pictureBox
        public Painter(PictureBox pictureBox, TriangleMesh triangleMesh, Lamp lamp)
        {
            _pictureBox = pictureBox;
            _canvas= new DirectBitmap(pictureBox.Width, pictureBox.Height);
            _triangleMesh = triangleMesh;
            _brush = new Brush();
            _lamp = lamp;
        }


        public void StartDrawing(object? obj, EventArgs arg)
        {
            // draw all triangles
            // fill all faces in triangleMesh
            _canvas = new DirectBitmap(_pictureBox.Width, _pictureBox.Height);
           
           _triangleMesh.Paint(_brush,_canvas, _lamp);
           
           if(_lamp.IsAnimated)
               _lamp.Rotate();
           

            //get image from bitmap generated from triangle mesh 
            //draw one line
            _pictureBox.Image = _canvas.Bitmap;
            //clear the picture box
            _pictureBox.Invalidate(new Rectangle(0,0,_canvas.Width, _canvas.Height));
            // update picture box
            _pictureBox.Update();
        }

    }
}