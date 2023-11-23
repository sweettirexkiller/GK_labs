using System;
using System.Drawing;
using System.Numerics;

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
        
        
        //  Znormalizowanie wartości piksela do określonego zakresu poprawia działanie algorytmu obliczania koncowego pixela
        public Vector3 GetVector(int x, int y)
        {
                var pixelColor = _bitmap.GetPixel(x, y);
                return Vector3.Normalize(new Vector3(
                        (float)GetVectorNormalizedComponent(pixelColor.R),
                        (float)GetVectorNormalizedComponent(pixelColor.G),
                        (float)Math.Max(GetVectorNormalizedComponent(pixelColor.B), 0)));
        }
        
        // Normalizacja do zakresu [-1, 1]
        public double GetVectorNormalizedComponent(byte value)
        {
                return (double)value / 128 - 1;
        }

        public Vector3 GetNormalVector(Vector3 N, int x, int y)
        {
                Vector3 Nt = GetVector(x, y);
                Vector3 Np = N;
                // only Z coordinate is needed
                Vector3 B = Vector3.Multiply(Np, new Vector3(0, 0, 1));
                if(Np.X == 0 && Np.Y == 0 && Math.Abs(Np.Z - 1)< Double.Epsilon)
                {
                        B = new Vector3(1, 0, 0);
                }
                
                Vector3 T = Vector3.Multiply(Np, B);
                
                
                var M = new Matrix4x4(
                        T.X, B.X, Np.X, 0,
                        T.Y, B.Y, Np.Y, 0,
                        T.Z, B.Z, Np.Z, 0,
                        0, 0, 0, 1);

                return Vector3.Normalize(new Vector3(
                        M.M11 * Nt.X + M.M12 * Nt.Y + M.M13 * Nt.Z,
                        M.M21 * Nt.X + M.M22 * Nt.Y + M.M23 * Nt.Z,
                        M.M31 * Nt.X + M.M32 * Nt.Y + M.M33 * Nt.Z));

        }

}