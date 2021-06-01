﻿using AForge.Video;
using Microsoft.Expression.Encoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace yoloTest
{
    class piCamera
    {
        public static Bitmap test(int cameraNumber)
        {
            string cameraURL = "http://192.168.1.29:8081/103/current";

            if(cameraNumber == 1)
            {
                cameraURL = "http://192.168.1.29:8081/103/current";
            }
            else if (cameraNumber == 2)
            {
                cameraURL = "http://192.168.1.29:8081/104/current";
            }
        else if(cameraNumber == 3)
            {
                cameraURL = "http://192.168.1.29:8081/105/current";
            }



    System.Net.WebRequest request =
System.Net.WebRequest.Create(
cameraURL);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();
            Bitmap bitmapOut = new Bitmap(responseStream);
            return bitmapOut;


        }



    }
}
