using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageFitting
{
    /// <summary>
    /// Crops an image to a square aspect ratio and resizes it to a target size of 512x512 pixels.
    /// </summary>
    public class Cropper
    {
        private const int TargetSize = 512;

        /// <summary>
        /// Centers and crops the input image to a square aspect ratio, then resizes it to 512x512 pixels.
        /// </summary>
        /// <param name="image">Uncroped image</param>
        /// <returns>Croped .bmp image</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Bitmap Crop(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            Rectangle cropArea = GetCropArea(image.Width, image.Height);
            Bitmap result = new Bitmap(TargetSize, TargetSize);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(image,
                    new Rectangle(0, 0, TargetSize, TargetSize), cropArea, GraphicsUnit.Pixel);
            }
            return result;
        }

        /// <summary>
        /// Calculates the crop area for the input image, centering it and ensuring a square aspect ratio. 
        /// The crop area is determined by the smaller dimension of the image (width or height) to maintain 
        /// the aspect ratio. If the image is smaller than the target size of 512x512 pixels, an exception is thrown.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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