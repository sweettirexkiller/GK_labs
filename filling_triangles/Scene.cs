using System.Windows.Forms;
using filling_triangles.Graphics;

namespace filling_triangles
{
    public class Scene
    {
        private PictureBox _pictureBox;
        private DirectBitmap _directBitmap;
        
        public DirectBitmap DirectBitmap
        {
            get => _directBitmap;
            set => _directBitmap = value;
        }
        
        // contructor that takes pictureBox
        public Scene(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _directBitmap = new DirectBitmap(pictureBox.Width, pictureBox.Height);
        }
        
    }
}