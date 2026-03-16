using ImageFitting.Tests.Utilities;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TestImageGenerator generator = new TestImageGenerator();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CreateTestBitmap(128, 128);

        }
    }
}
