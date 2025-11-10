using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Windows.Devices.Enumeration;
using System.Linq;
using Windows.UI.Xaml;

namespace Webcam
{
    public partial class Form1 : Form
    {
        DeviceInformationCollection devices;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        async Task updateDeviceList()
        {
            devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
        }

        private async Task refreshClick()
        {
            await updateDeviceList();
            comboBox1.DataSource = devices.ToList();
            comboBox1.DisplayMember = "Name";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            refreshClick();
        }
    }
}
