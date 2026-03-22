using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ImageFitting;
using ImageFitting.Tests.Utilities;

namespace ImageFitting.Tests
{
    [TestClass]
    public class CropperTests
    {
        private Cropper _cropper;

        [TestInitialize]
        public void Setup()
        {
            _cropper = new Cropper();
        }

        [TestMethod]
        public void Crop_WhenImageIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            bool caught = false;

            // Act
            try
            {
                _cropper.Crop(null);
            }
            catch (ArgumentNullException ex)
            {
                caught = true;
                // Assert: Verify the parameter name for extra precision
                Assert.AreEqual("image", ex.ParamName);
            }

            // Assert: Ensure the exception was actually thrown
            Assert.IsTrue(caught, "Expected ArgumentNullException was not thrown.");
        }

        [TestMethod]
        public void GetCropArea_WhenWidthTooSmall_ThrowsArgumentException()
        {
            // Arrange
            bool caught = false;

            // Act
            try
            {
                _cropper.GetCropArea(100, 600); // 100 < 512
            }
            catch (ArgumentException ex)
            {
                caught = true;
                StringAssert.Contains(ex.Message, "at least 512x512px");
            }

            // Assert
            Assert.IsTrue(caught, "Expected ArgumentException for small width was not thrown.");
        }

        [TestMethod]
        public void GetCropArea_WhenHeightTooSmall_ThrowsArgumentException()
        {
            // Arrange
            bool caught = false;

            // Act
            try
            {
                _cropper.GetCropArea(600, 100); // 100 < 512
            }
            catch (ArgumentException)
            {
                caught = true;
            }

            // Assert
            Assert.IsTrue(caught, "Expected ArgumentException for small height was not thrown.");
        }

        [TestMethod]
        [DataRow(1000, 600, 200, 0, 600)] // Landscape
        [DataRow(600, 1000, 0, 200, 600)] // Portrait
        public void GetCropArea_ValidDimensions_ReturnsCorrectRectangle(int w, int h, int x, int y, int size)
        {
            // Act
            Rectangle result = _cropper.GetCropArea(w, h);

            // Assert
            Assert.AreEqual(x, result.X);
            Assert.AreEqual(y, result.Y);
            Assert.AreEqual(size, result.Width);
            Assert.AreEqual(size, result.Height);
        }

        [TestMethod]
        public void Crop_ValidImage_Returns512x512Bitmap()
        {
            // Arrange
            using (Bitmap input = TestImageGenerator.CreateTestBitmap(800, 800))
            {
                // Act
                using (Bitmap result = _cropper.Crop(input))
                {
                    // Assert
                    Assert.AreEqual(512, result.Width);
                    Assert.AreEqual(512, result.Height);
                }
            }
        }
    }
}