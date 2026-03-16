using System;
namespace ImageFitting
{
    public partial class ImageCropper : Form
    {
        public ImageCropper()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CropedImage_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();



            // Filter the file types to only show image files
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";

            // Set the initial directory (optional)
            openFileDialog.InitialDirectory = @"C:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string imagePath = openFileDialog.FileName;

                // Display the image in the PictureBox using the Image.FromFile method
                try
                {

                    Image img = Image.FromFile(imagePath);
                    Cropper cropper = new Cropper();
                    if (cropper.ValidImage(img))
                    {
                        Bitmap result = cropper.CropImageTo512(img);
                        CropedImage.Image = result;
                    } else
                    {
                        MessageBox.Show("Invalid image. Please select a valid image file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (CropedImage.Image != null)
                InsertTextBox.Visible = false;

        }

        private void InsertTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            CropedImage_MouseClick(sender, e);
        }
    }
}
