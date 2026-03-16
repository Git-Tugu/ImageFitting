using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageFitting
{
    /// <summary>
    /// Processing class for cropping images to a square of 512x512 pixels, centered on the original image.
    /// </summary>
    public class Cropper
    {
        private const int TargetSize = 512;

        /// <summary>
        /// Crops the input image to a square of 512x512 pixels, centered on the original image.
        /// If not valid, throws an exception indicating the minimum size requirement.
        /// </summary>
        /// <param name="image">Source Image</param>
        /// <returns>512x512 sized Bitmap</returns>
        public Bitmap CropImageToTargetSize(Image image)
        {
            if (!IsValidImage(image))
            {
                throw new ArgumentException($"Minimum size of image must be {TargetSize}x{TargetSize} !");
            }

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

        /// <summary>
        /// Checks if the input image is valid for cropping, meaning it must be at least 512 pixels in both width and height.
        /// </summary>
        private bool IsValidImage(Image image)
        {
            if (image == null) return false;
            // If either dimension is smaller than the target size, the image is not valid for cropping
            return image.Width >= TargetSize && image.Height >= TargetSize;
        }
    }
}