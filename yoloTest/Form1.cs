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
                        var font = new Font("Arial", 40, FontStyle.Bold);
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
                Thread.Sleep(1000);
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
                    Thread.Sleep(1000);
                    cameraOn = true;
                }

                Image captured_image = camera.currentImage;
                pictureBox1.Image = captured_image;
                // camera.Stop();
                yoloThingy();
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
    }
}
