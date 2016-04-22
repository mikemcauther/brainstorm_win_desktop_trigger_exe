using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCaptureModule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public int I { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            // Minimize the Window
            this.WindowState = FormWindowState.Minimized;

            // thread Sleep
            Thread.Sleep(200);

            // Taking ScreenShot
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);


            // Save the screenshot to the specified path that the user has chosen.
            //bmpScreenshot.Save("Screenshot.png", ImageFormat.Png);

            try
            {
                richTextBox1.Text = "";

                if (bmpScreenshot != null)
                {
                    Create_Directory c = new Create_Directory();
                    string s = c.CreateDir() + "" + new RandomString().rs();
                    string t = s + " - " + I + ".png";

                    bmpScreenshot.Save(t, ImageFormat.Png);
                    I++;
                    label1.Text = "File Saved At";
                    richTextBox1.Text = t;
                }

                // Opening Images

                button2.Visible = true;

                // window previous state
                this.WindowState = FormWindowState.Normal;


            }
            catch (Exception)
            {
                label1.Text = "There was a problem saving the file." +
                    "Check the file permissions.";
            }
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Process.Start(@"" + richTextBox1.Text);
            var url = @"bswdprotocol:" + richTextBox1.Text;
            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url; 
            Process.Start(psi);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                button2.Visible = false;
        }

    }
}
