namespace ImageFitting
{
    partial class ImageCropper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CropedImage = new PictureBox();
            InsertTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)CropedImage).BeginInit();
            SuspendLayout();
            // 
            // CropedImage
            // 
            CropedImage.BackColor = SystemColors.ActiveCaption;
            CropedImage.Location = new Point(153, 67);
            CropedImage.Name = "CropedImage";
            CropedImage.Size = new Size(512, 512);
            CropedImage.TabIndex = 0;
            CropedImage.TabStop = false;
            CropedImage.Click += pictureBox1_Click;
            CropedImage.MouseClick += CropedImage_MouseClick;
            // 
            // InsertTextBox
            // 
            InsertTextBox.BackColor = SystemColors.ActiveCaption;
            InsertTextBox.BorderStyle = BorderStyle.None;
            InsertTextBox.CausesValidation = false;
            InsertTextBox.ForeColor = SystemColors.WindowFrame;
            InsertTextBox.ImeMode = ImeMode.Off;
            InsertTextBox.Location = new Point(360, 299);
            InsertTextBox.Name = "InsertTextBox";
            InsertTextBox.Size = new Size(100, 16);
            InsertTextBox.TabIndex = 1;
            InsertTextBox.Text = "Insert image";
            InsertTextBox.TextAlign = HorizontalAlignment.Center;
            InsertTextBox.MouseClick += InsertTextBox_MouseClick;
            InsertTextBox.Select(0, 0);
            // 
            // ImageCropper
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(924, 616);
            Controls.Add(InsertTextBox);
            Controls.Add(CropedImage);
            Name = "ImageCropper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Cropper";
            ((System.ComponentModel.ISupportInitialize)CropedImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox CropedImage;
        private TextBox InsertTextBox;
    }
}
