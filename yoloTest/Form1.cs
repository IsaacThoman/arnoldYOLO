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

using Emgu.CV;
using Emgu.CV.Structure;
using ImageCapture;
using AForge.Video;
using System.Drawing.Drawing2D;

namespace yoloTest
{
    public partial class Form1 : Form
    {
        public static string imageLocation = "";
        bool _streaming;


        public void yoloThingy()
        {
            //  pictureBox1.Image = Image.FromFile(imageLocation);

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
                        var font = new Font("Arial", 10, FontStyle.Bold);
                        var rectangle = new Rectangle(x, y, width, height);
                        var pen = new Pen(Color.Red, 5);
                        var point = new System.Drawing.Point(x, y);

                    //    if (item.Type == "person")
                   //     {
                            graphics.DrawRectangle(pen, rectangle);
                            string thisBoxString = item.Type + Environment.NewLine + "Confidence: " + item.Confidence;
                            graphics.DrawString(thisBoxString, font, brush, point);
                    //    }


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


            yoloThingy();

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

        private static Webcam camera = new Webcam(new System.Drawing.Size(1280, 720), 1);
        private static bool cameraOn = false;

        private void button3_Click(object sender, EventArgs e)
        {
     //       if (cameraOn == false)
     //       {
                camera.Start();
                Thread.Sleep(2000);
                cameraOn = true;
         //   }

            Image captured_image = camera.currentImage;
            pictureBox1.Image = captured_image;
           // camera.Stop();
            yoloThingy();
            camera.Stop();
            cameraOn = false;
           

        }
        public bool runningYOLO = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (runningYOLO == false) {
                runningYOLO = true;
                if (cameraOn == false)
                {
                    camera.Start();
                    Thread.Sleep(2000);
                    cameraOn = true;
                }

                Image captured_image = camera.currentImage;
                pictureBox1.Image = captured_image;
                // camera.Stop();
                if (checkBoxDOIR.Checked) {
                    yoloThingy();
                }
                
                runningYOLO = false;

            }
          

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            camera.Stop();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                camera.Stop();
                cameraOn = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            getPiCameras();

        }
        public static Bitmap camera1 = new Bitmap(640, 480);
        public static Bitmap camera2 = new Bitmap(640, 480);
        public static Bitmap camera3 = new Bitmap(640, 480);

        public static bool piCam1Running = false;
        public static bool piCam2Running = false;
        public static bool piCam3Running = false;


        public static void piCamera1()
        {
            if (piCam1Running == false)
            {
                piCam1Running = true;
                camera1 = piCamera.test(1);
                System.Threading.Thread.Sleep(300);
                piCam1Running = false;
            }

        }
        public static void piCamera2()
        {
            if (piCam2Running == false)
            {
                piCam2Running = true;
                camera2 = piCamera.test(2);
                System.Threading.Thread.Sleep(300);
                piCam2Running = false;
            }
        }
        public static void piCamera3()
        {
            if (piCam3Running == false)
            {
                piCam3Running = true;
                camera3 = piCamera.test(3);
                System.Threading.Thread.Sleep(300);
                piCam3Running = false;
            }
        }

        private void getPiCameras()
        {


            Bitmap testBitmap = new Bitmap(640, 480);

            ThreadStart childref = new ThreadStart(piCamera1);
            Thread childThread = new Thread(childref);

            ThreadStart childref2 = new ThreadStart(piCamera2);
            Thread childThread2 = new Thread(childref2);

            ThreadStart childref3 = new ThreadStart(piCamera3);
            Thread childThread3 = new Thread(childref3);


            if (piCam1Box.Checked)
            {
                childThread.Start();
            }
            if (piCam2Box.Checked)
            {
                childThread2.Start();
            }
            if (piCam3Box.Checked)
            {
                childThread3.Start();
            }
            
            
            

            using (Graphics gr = Graphics.FromImage(testBitmap))
            {
                //   gr.SmoothingMode = SmoothingMode.AntiAlias;



                Rectangle rect1 = new Rectangle(0, 0, 320, 240);
                Rectangle rect2 = new Rectangle(320, 0, 320, 240);
                Rectangle rect3 = new Rectangle(0, 240, 320, 240);


                if (flip12Pi.Checked)
                {

                     rect1 = new Rectangle(320, 0, 320, 240);
                     rect2 = new Rectangle(0, 0, 320, 240);
                    rect3 = new Rectangle(0, 240, 320, 240);
                }
                Rectangle old3 = rect3;
                Rectangle old1 = rect1;

                if (piFlip13.Checked)
                {
                    rect1 = old3;
                    rect3 = old1;
                }




                gr.DrawImage(camera1, rect1);
                gr.DrawImage(camera2, rect2);
                gr.DrawImage(camera3, rect3);
            }
            pictureBox1.Image = testBitmap;
            if (checkBoxDOIR.Checked)
            {
                yoloThingy();
            }


        }

        public void newImageEvent(Bitmap newImage)
        {
            pictureBox1.Image = newImage;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                timer2.Enabled = true;
            }
            else
            {
                timer2.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            getPiCameras();


        }

        private void checkBoxDOIR_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            piCamera.flipper = checkBox3.Checked;
        }
    }
}
