using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageFitting
{
    internal class Cropper
    {
        public Bitmap CropImageTo512(Image image)
        {
            const int size = 512;

            int cropSize = Math.Min(image.Width, image.Height);

            Rectangle cropArea = new Rectangle(
                (image.Width - cropSize) / 2,
                (image.Height - cropSize) / 2,
                cropSize,
                cropSize
            );

            Bitmap result = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(image,
                    new Rectangle(0, 0, size, size),
                    cropArea,
                    GraphicsUnit.Pixel);
            }

            return result;
        }

        public Boolean ValidImage(Image image)
        {
            return image != null && image.Width > 512 && image.Height > 512;
        }
    }
}
