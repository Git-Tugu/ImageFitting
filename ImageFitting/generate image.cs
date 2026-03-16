using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageFitting.Tests.Utilities
{
    /// <summary>
    /// Тест хийхэд зориулж төрөл бүрийн хэмжээтэй зураг үүсгэгч класс.
    /// </summary>
    public class TestImageGenerator
    {
        /// <summary>
        /// Заасан хэмжээтэй, санамсаргүй өнгөтэй Bitmap объект үүсгэнэ.
        /// </summary>
        /// <param name="width">Өргөн (pixels)</param>
        /// <param name="height">Өндөр (pixels)</param>
        /// <returns>Bitmap объект</returns>
        public Bitmap CreateTestBitmap(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Зургийг ялгахын тулд санамсаргүй өнгөөр дүүргэх (заавал биш)
                g.Clear(Color.FromArgb(255, width % 255, height % 255, (width + height) % 255));

                // Туршилтын бичвэр оруулах (зураг хоосон биш гэдгийг харуулах)
                g.DrawString($"{width}x{height}", new Font("Arial", 10), Brushes.White, new PointF(5, 5));
            }
            return bitmap;
        }

        /// <summary>
        /// Тест хийхэд зориулж зургийг файл хэлбэрээр түр хадгалах функц.
        /// </summary>
        public string SaveTempImage(int width, int height, string fileName)
        {
            string path = Path.Combine(Path.GetTempPath(), fileName);
            using (Bitmap bmp = CreateTestBitmap(width, height))
            {
                bmp.Save(path, ImageFormat.Png);
            }
            return path;
        }
    }
}