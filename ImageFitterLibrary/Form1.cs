using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageFitting
{
    public partial class ImageCropper : Form
    {
        private readonly Cropper _cropper = new Cropper();

        public ImageCropper()
        {
            InitializeComponent();
        }

        private void CropedImage_MouseClick(object sender, MouseEventArgs e)
        {
            LoadAndCropImage();
        }

        private void InsertTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            LoadAndCropImage();
        }

        private void LoadAndCropImage()
        {
            string path = SelectImagePath();
            if (path == null) return;

            try
            {
                using (Image img = Image.FromFile(path))
                {
                    // Dispose old image to avoid memory leaks
                    CropedImage.Image?.Dispose();

                    Bitmap result = _cropper.Crop(img);
                    CropedImage.Image = result;
                }

                InsertTextBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

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