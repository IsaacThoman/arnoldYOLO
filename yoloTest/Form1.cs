using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Alturos.Yolo;

using Alturos.Yolo.Model;
using OpenCvSharp.Extensions;
using OpenCvSharp;

namespace yoloTest
{
    public partial class Form1 : Form
    {
        public static string imageLocation = "";

        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new OpenCvSharp.VideoCapture(1);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imageLocation);

            var configurationDetector = new YoloConfigurationDetector();
            var config = configurationDetector.Detect();

            using (var yoloWrapper = new YoloWrapper(config))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Png);
                    var items = yoloWrapper.Detect(ms.ToArray()).ToList();
                    //  yoloItemBindingSource.DataSource = items;

                    //   AddDetails(pictureBox1, items);


                    var image = pictureBox1.Image;
                    var brush = new SolidBrush(Color.Red);
                    var graphics = Graphics.FromImage(image);

                    foreach (var item in items)
                    {
                        var x = item.X;
                        var y = item.Y;
                        var width = item.Width;
                        var height = item.Height;
                        var font = new Font("Arial", 40, FontStyle.Bold);
                        var rectangle = new Rectangle(x, y, width, height);
                        var pen = new Pen(Color.Red, 5);
                        var point = new System.Drawing.Point(x, y);

                        if (item.Type == "person")
                        {
                            graphics.DrawRectangle(pen, rectangle);
                            string thisBoxString = item.Type + Environment.NewLine + "Confidence: " + item.Confidence;
                            graphics.DrawString(thisBoxString, font, brush, point);
                        }


                    }
                    pictureBox1.Image = image;




                }
            }



        }





        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    imageLocation = openFileDialog.FileName;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void cameraToggleBtn_Click(object sender, EventArgs e)
        {
            if (cameraToggleBtn.Text.Equals("Start"))
            {
                CaptureCamera();
                cameraToggleBtn.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                cameraToggleBtn.Text = "Start";
                isCameraRunning = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            {
                if (isCameraRunning)
                {
                    // Take snapshot of the current image generate by OpenCV in the Picture Box
                    Bitmap snapshot = new Bitmap(pictureBox1.Image);

                    // Save in some directory
                    // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                    // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                    snapshot.Save(string.Format(@"C:\Users\sdkca\Desktop\{0}.png", Guid.NewGuid()), ImageFormat.Png);
                }
                else
                {
                    Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
                }

            }
        }
    }
}
