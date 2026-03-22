using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ImageFitting.Tests
{
    [TestClass]
    public class CropperTests
    {
        [TestMethod]
        public void GetCropArea_ReturnsCenteredSquare()
        {
            var cropper = new Cropper();

            var result = cropper.GetCropArea(800, 600);

            Assert.AreEqual(new Rectangle(100, 0, 600, 600), result);
        }

        [TestMethod]
        public void Crop_Returns512x512Image()
        {
            using var input = new Bitmap(800, 800);
            var cropper = new Cropper();

            var result = cropper.Crop(input);

            Assert.AreEqual(512, result.Width);
            Assert.AreEqual(512, result.Height);
        }
    }
}