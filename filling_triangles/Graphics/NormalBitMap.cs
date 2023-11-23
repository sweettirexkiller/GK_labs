using System.Drawing;

namespace filling_triangles.Graphics;

public class NormalBitMap
{
        private Bitmap _bitmap;
        public NormalBitMap(Image newNormalMapImage, Size size)
        {
                _bitmap = new Bitmap(newNormalMapImage, size.Width, size.Height);
        }

        public int Width { get; set; }
        public int Height { get; set; }
}