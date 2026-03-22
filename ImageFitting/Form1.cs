using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageFitting
{
    /// <summary>
    /// It's a Windows Forms application that allows users to select an image file,
    /// crop it using a Cropper class, and display the cropped image in a PictureBox control.
    /// The form also includes an InsertTextBox that becomes invisible after cropping an image. 
    /// </summary>
    public partial class ImageCropper : Form
    {
        private readonly Cropper _cropper = new Cropper();

        public ImageCropper()
        {
            InitializeComponent();
        }

        [ExcludeFromCodeCoverage]
        private void CropedImage_MouseClick(object sender, MouseEventArgs e)
        {
            LoadAndCropImage();
        }

        [ExcludeFromCodeCoverage]
        private void InsertTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            LoadAndCropImage();
        }

        /// <summary>
        /// Takes a file path as input, attempts to open the image file, and uses the Cropper class to crop the image.
        /// </summary>
        /// <param name="path">Path of source image</param>
        internal void ProcessFile(string path)
        {
            if (string.IsNullOrEmpty(path)) return;
            try
            {
                using (Stream str = File.OpenRead(path))
                using (Image original = Image.FromStream(str))
                {
                    CropedImage.Image?.Dispose();
                    CropedImage.Image = _cropper.Crop(original);
                    InsertTextBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Just a helper method that opens a file dialog to select an 
        /// image file, and then calls the ProcessFile method to crop and display the image.
        /// </summary>
        private void LoadAndCropImage()
        {
            string path = SelectImagePath();
            ProcessFile(path);
        }

        /// <summary>
        /// Shows an OpenFileDialog to the user, allowing them to select an image file.
        /// The dialog filters for common image file types and starts in the C:\ directory.
        /// If the user selects a file and clicks OK, the method returns the file path; otherwise, it returns null.
        /// </summary>
        /// <returns>Pile path</returns>
        private string SelectImagePath()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.InitialDirectory = @"C:\";

                return dialog.ShowDialog() == DialogResult.OK
                    ? dialog.FileName
                    : null;
            }
        }
    }
}