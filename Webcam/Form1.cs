using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Webcam
{
    public partial class Form1 : Form
    {
        VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;

        private MediaCapture _mediaCapture;
        private MediaPlayer _mediaPlayer;

        private Windows.UI.Xaml.Controls.SwapChainPanel _swapChainPanel;

        public Form1()
        {
            InitializeComponent();
            loadWebCamPreview();

        }
        private async void loadWebCamPreview() {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Selected index changed");
        }
        async Task updateDeviceList()
        {
            Console.WriteLine("Searching for devices...");
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Console.WriteLine("Found " + videoDevices.Count + " video devices.");
        }

        private async Task refreshClick()
        {
            await updateDeviceList();
            comboBox1.DataSource = videoDevices;
            comboBox1.DisplayMember = "Name";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            refreshClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
            videoSource.Start();
        }
        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            previewBox.Image = bitmap; // pictureBox1 – kontrolka z formularza
        }
    }
}
