using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace IPCameraViewerEmguCV
{
    public partial class Form1 : Form
    {
        private Capture capture = null;
        //private bool isStart;
        public Form1()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            capture = new Capture("rtsp://192.168.1.64:554/Streaming/Channels/101");
            capture.ImageGrabbed += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            capture.Retrieve(frame, 0);
            CvInvoke.Resize(frame, frame, new Size(imageBox1.Width, imageBox1.Height), 0, 0, Inter.Linear);
            imageBox1.Image = frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            capture.Start();
        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }
    }
}
