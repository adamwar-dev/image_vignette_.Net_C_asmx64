using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProjectAssembler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxUpload.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxUpload.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.BorderStyle = BorderStyle.FixedSingle;

            //Labels
            threadsNumber.Text = "Threads Number: " + Environment.ProcessorCount;
            textResult.Text = "";
            timeResult.Text = "";

            //Buttons
            uploadButton.Text = "Upload";
            runButton.Text = "Run";
            saveButton.Text = "Save";
            runButton.Enabled = false;
            saveButton.Enabled = false;

            cPlusPlus.Checked = true;
            asm.Checked = false;

            //TrackBar
            trackBar.Value = Environment.ProcessorCount;
            trackBar.Cursor = DefaultCursor;
        }

        private void pictureBoxUpload_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxResult_Click(object sender, EventArgs e)
        {

        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            string imageLocation;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBoxUpload.ImageLocation = imageLocation;
                }
                if (pictureBoxUpload != null || pictureBoxUpload.Image != null)
                {
                    runButton.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured during upload image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            //utworzenie stopera
            Stopwatch stoper = new Stopwatch();
            try
            {
                //utworzenie obiektu odpowiadającego za operacje związanie z pixelami wykonywane w C#
                HighLevelPart highLevelOperations = new HighLevelPart(pictureBoxUpload.Image);
                var allPixels = highLevelOperations.GetAllPixels();
                var allPixelsVignette = highLevelOperations.GetAllPixelsVignette();
                var finalData = highLevelOperations.GetAllPixels();
                unsafe
                {
                    fixed (int* pixelPointer = allPixels)
                    {
                        fixed (int* vignettePointer = allPixelsVignette)
                        {
                            fixed (int* finalDataPointer = finalData)
                                { 
                                //utworzenie obiektu odpowiadającego za wątki
                                MyThreads threads = new MyThreads(trackBar.Value);
                                int period = allPixelsVignette.Length / trackBar.Value;
                                List<int> a = new List<int>();
                                for (int i = 0; i < trackBar.Value; i++)
                                {
                                    a.Add(i);
                                }

                                foreach (int b in a)
                                {
                                    threads.addThread(pixelPointer + (period * 5 * b), vignettePointer + (period * b), period, b, cPlusPlus.Checked, finalDataPointer + (period * 5 * b));
                                }
                                 
                                stoper.Start();
                                threads.StartThreads();
                                stoper.Stop();
                                //ustawianie zwinietowanego zdjęcia
                                Image finalImage = highLevelOperations.getImage(threads.getFinalData(), allPixels.Length, period * 5);
                                pictureBoxResult.Image = finalImage;
                                
                            }
                        }
                    }
                }

                if (pictureBoxResult != null && pictureBoxResult.Image != null)
                {
                    saveButton.Enabled = true;
                    textResult.Text = "Done";
                    timeResult.Text = stoper.Elapsed.ToString(@"ss\.ffff") + " sec";
                }
                runButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during filtring image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                runButton.Enabled = true;
            }
        }

        private void textResult_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveImage = new SaveFileDialog();
                saveImage.Filter = "jpg files(.*jpg) | *.jpg | PNG files(.*png) | *.png | All Files(*.*) | *.*";
                if (saveImage.ShowDialog() == DialogResult.OK)
                    pictureBoxResult.Image.Save(saveImage.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured during saving image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timeResult_Click(object sender, EventArgs e)
        {

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            threadsNumber.Text = "Threads Number: " + trackBar.Value.ToString();
        }

        private void threadsNumber_Click(object sender, EventArgs e)
        {

        }

        private void cSharp_CheckedChanged(object sender, EventArgs e)
        {
            if (cPlusPlus.Checked)
            {
                asm.Checked = false;
            } 
            else
            {
                asm.Checked = true;
            }
        }

        private void asm_CheckedChanged(object sender, EventArgs e)
        {
            if (asm.Checked)
            {
                cPlusPlus.Checked = false;
            }
            else
            {
                cPlusPlus.Checked = true;
            }
        }
    }
}
