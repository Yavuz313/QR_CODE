using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;  // for File
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;  // for BarcodeReader
using ZXing.QrCode;  // for QRCodeReader

namespace QR_Code
{
    public partial class Form1 : Form
    {
        FilterInfoCollection wepcam;
        VideoCaptureDevice cam;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize camera devices
            wepcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Populate the comboBox with available camera devices
            foreach (FilterInfo dev in wepcam)
            {
                comboBox1.Items.Add(dev.Name);
            }

            // Set the default selection to the first camera device
            comboBox1.SelectedIndex = 0;
        }

        private void cam_NewCam(object sender, NewFrameEventArgs eventArgs)
        {
            // Display the captured frame from the camera in the pictureBox
            pictureBox1.Image = ((Bitmap)eventArgs.Frame.Clone());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Start the selected camera device
            cam = new VideoCaptureDevice(wepcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewCam);
            cam.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Enable and start the timer for barcode decoding
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Decode barcode from the camera image
            BarcodeReader barcode = new BarcodeReader();
            if (pictureBox1.Image != null)
            {
                Result res = barcode.Decode((Bitmap)pictureBox1.Image);
                try
                {
                    // Get the decoded barcode result and display it in textBox1
                    string decoded = res.ToString().Trim();
                    if (decoded != "")
                    {
                        textBox1.Text = decoded;

                        // Stop the timer after successfully decoding the barcode
                        timer1.Stop();
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs during decoding
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the camera when the form is closing
            if (cam != null && cam.IsRunning == true)
            {
                cam.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Open Form2 and hide the current form
            Form2 add = new Form2();
            add.Show();
            this.Hide();
        }
    }
}
