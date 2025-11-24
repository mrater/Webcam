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
        long threshold = 200000;
        VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;


        Bitmap previousFrame;

        private bool isGray = false;
        private Accord.Video.FFMPEG.VideoFileWriter videoWriter;
        private bool isRecording = false;


        private MediaCapture _mediaCapture;
        private MediaPlayer _mediaPlayer;

        private Windows.UI.Xaml.Controls.SwapChainPanel _swapChainPanel;

        private long colorDelta = 0;

        public Form1()
        {
            InitializeComponent();
            loadWebCamPreview();

            previousFrame = new Bitmap(100, 100);
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

        int frame = 0;

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs) {

            Bitmap bitmap = new Bitmap(eventArgs.Frame);
            if (isGray)
            {
                Grayscale filter = new Grayscale(0.299, 0.587, 0.114);
                bitmap = filter.Apply(bitmap);
            }

            Invoke(new Action(() => {
                previewBox.Image = bitmap; // pictureBox1 – kontrolka z formularza
            }));


            if (isRecording && videoWriter != null)
            {
                videoWriter.WriteVideoFrame(bitmap);
            }


            if (frame < 20)
            {
                frame++;
                return;
            }
            frame = 0;
            Invoke(new Action(() =>
            {
                if (bitmap.Width == previousFrame.Width && bitmap.Height == previousFrame.Height)
                {
                    refreshDeltaCalculate(bitmap, previousFrame);
                }
            }));
            previousFrame = bitmap;
        }

        Bitmap asGrayscale(Bitmap bitmap)
        {
            // Source - https://stackoverflow.com/a
            // Posted by Asad, modified by community. See post 'Timeline' for change history
            // Retrieved 2025-11-10, License - CC BY-SA 4.0
            Bitmap c;
            lock (bitmap)
            {
                c = new Bitmap(bitmap);
            }
            int x, y;

            // Loop through the images pixels to reset color.
            for (x = 0; x < c.Width; x++)
            {
                for (y = 0; y < c.Height; y++)
                {
                    Color pixelColor = c.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    c.SetPixel(x, y, newColor); // Now greyscale
                }
            }
            return c;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int abs(int a)
        {
            if (a < 0) return -a;
            return a;
        }
        long getGrayscaleDifference(Bitmap b1, Bitmap b2)
        {
            Bitmap b1g = new Bitmap(b1);
            Bitmap b2g = new Bitmap(b2);
            lock (b1)
            {
                b1g = asGrayscale(b1g);
            }
            lock (b2)
            {
                b2g = asGrayscale(b2g);
            }
            long total_difference = 0;
            for (int i = 0; i < b1.Width; i += 10)
            {
                for (int j = 0; j < b1.Height; j += 10)
                {
                    total_difference += abs(b1g.GetPixel(i, j).ToArgb() - b2g.GetPixel(i, j).ToArgb());
                }
            }
            return total_difference / (b1.Width * b1.Height);
        }

        void refreshDeltaCalculate(Bitmap currentFrame, Bitmap previousFrame)
        {
            long delta = getGrayscaleDifference(currentFrame, previousFrame);

            Invoke(new Action(() =>
            {
                //colorDeltaLabel.Text = delta.ToString();
                if (delta > threshold)
                {
                    colorDeltaLabel.Text = "ACHTUNG";
                    colorDeltaLabel.ForeColor = Color.Red;
                } else
                {
                    colorDeltaLabel.Text = "Spokój";
                    colorDeltaLabel.ForeColor = Color.Blue;
                }
            }));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            long newThreshold = trackBar1.Value;
            threshold = newThreshold;
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
