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
using Accord.Video.VFW;
using AForge.Imaging.Filters;

namespace Webcam
{
    public partial class Form1 : Form
    {
        VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;

        private bool isGray = false;
        private Accord.Video.FFMPEG.VideoFileWriter videoWriter;
        private bool isRecording = false;

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

        private void button2_Click(object sender, EventArgs e) {
            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
            videoSource.Start();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            if (isGray)
            {
                Grayscale filter = new Grayscale(0.299, 0.587, 0.114);
                bitmap = filter.Apply(bitmap);
            }
            if (isRecording && videoWriter != null)
            {
                videoWriter.WriteVideoFrame(bitmap);
            }

            previewBox.Image = bitmap;
        }


        private void buttonPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (previewBox.Image != null)
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Pliki JPEG (*.jpg)|*.jpg|Pliki PNG (*.png)|*.png";
                        saveDialog.Title = "Zapisz zdjęcie z kamerki";
                        saveDialog.FileName = "zdjecie_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            previewBox.Image.Save(saveDialog.FileName);
                            MessageBox.Show("Zdjęcie zapisane pomyślnie!", "Sukces",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Brak obrazu z kamerki!", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy zapisie zdjęcia: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonGray_Click(object sender, EventArgs e)
        {
            isGray = !isGray; // przełączanie trybu
            if (isGray)
            {
                buttonGray.Text = "Kolorowy";
            }
            else
            {
                buttonGray.Text = "Czarno-biały";
            }
        }


        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                if (previewBox.Image == null)
                {
                    MessageBox.Show("Najpierw uruchom kamerę!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Pliki AVI (*.avi)|*.avi";
                    saveDialog.Title = "Zapisz nagranie wideo";
                    saveDialog.FileName = "nagranie_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        videoWriter = new Accord.Video.FFMPEG.VideoFileWriter();
                        Bitmap firstFrame = new Bitmap(previewBox.Image);
                        videoWriter.Open(saveDialog.FileName, firstFrame.Width, firstFrame.Height, 25, Accord.Video.FFMPEG.VideoCodec.MPEG4);
                        firstFrame.Dispose();

                        isRecording = true;
                        buttonRecord.Text = "Stop";
                    }
                }
            }
            else
            {
                // Zatrzymanie nagrywania
                isRecording = false;
                videoWriter.Close();
                videoWriter.Dispose();
                videoWriter = null;
                buttonRecord.Text = "Record";

                MessageBox.Show("Nagranie zakończone!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
