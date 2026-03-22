using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageFitting
{
    public class Cropper
    {
        private const int TargetSize = 512;

        public Bitmap Crop(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            // Crop the image to a square based on the smaller dimension, centered on the original image
            int cropSize = Math.Min(image.Width, image.Height);
            int x = (image.Width - cropSize) / 2;
            int y = (image.Height - cropSize) / 2;

            Rectangle cropArea = new Rectangle(x, y, cropSize, cropSize);
            Bitmap result = new Bitmap(TargetSize, TargetSize);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(image,
                    new Rectangle(0, 0, TargetSize, TargetSize),
                    cropArea,
                    GraphicsUnit.Pixel);
            }
            return result;
        }

        // ✅ PURE METHOD → EASY TO TEST
        public Rectangle GetCropArea(int width, int height)
        {
            if (width < TargetSize || height < TargetSize)
                throw new ArgumentException($"Image must be at least {TargetSize}x{TargetSize}px.");

            int cropSize = Math.Min(width, height);
            int x = (width - cropSize) / 2;
            int y = (height - cropSize) / 2;

            return new Rectangle(x, y, cropSize, cropSize);
        }
    }
}