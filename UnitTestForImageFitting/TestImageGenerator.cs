using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace ImageFitting.Tests.Utilities
{
    /// <summary>
    /// Тест хийхэд зориулж төрөл бүрийн хэмжээтэй зураг үүсгэгч класс.
    /// </summary>
    public static class TestImageGenerator
    {
        /// <summary>
        /// Creates a Bitmap object with the specified width and height, 
        /// fills it with a solid color based on the dimensions, and draws 
        /// the dimensions as text on the image for easy identification during testing.
        /// </summary>
        /// <param name="width">Wigth</param>
        /// <param name="height">Heigth</param>
        /// <returns>bitmap object</returns>
        public static Bitmap CreateTestBitmap(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.FromArgb(255, width % 255, height % 255, (width + height) % 255));
                g.DrawString($"{width}x{height}", new System.Drawing.Font("Arial", 10), Brushes.White, new PointF(5, 5));
            }
            return bitmap;
        }

        /// <summary>
        /// For testing purposes, creates a temporary PNG image file with the specified dimensions and returns its file path.
        /// </summary>
        public static string SaveTempImage(int width, int height, string fileName)
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