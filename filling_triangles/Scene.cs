using System.Windows.Forms;
using filling_triangles.Graphics;

namespace filling_triangles
{
    public class Scene
    {
        private PictureBox _pictureBox;
        private DirectBitmap _directBitmap;
        private TriangleMesh _triangleMesh;
        private GraphicTools.Painter _painter;
        
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
        
    }
}