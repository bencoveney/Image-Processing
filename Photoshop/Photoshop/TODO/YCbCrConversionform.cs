using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Photoshop
{
    public partial class YCbCrConversionform : Form
    {
        public YCbCrConversionform()
        {
            InitializeComponent();
        }

        private void Main(string OpenFile, string SaveFile)
        {
            if (OpenFile != null && SaveFile != null)
            {
                Bitmap OrigImage = new Bitmap(OpenFile);
                BitmapData OrigData = OrigImage.LockBits(new Rectangle(0, 0, OrigImage.Width, OrigImage.Height), ImageLockMode.ReadWrite, OrigImage.PixelFormat);
                int BytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(OrigImage.PixelFormat) / 8;
                int ByteCount = OrigData.Stride * OrigImage.Height;
                byte[] Pixels = new byte[ByteCount];
                IntPtr PtrFirstPixel = OrigData.Scan0;
                Marshal.Copy(PtrFirstPixel, Pixels, 0, Pixels.Length);
                int HeightInPixels = OrigData.Height;
                int WidthInBytes = OrigData.Width * BytesPerPixel;

                for (int y = 0; y < HeightInPixels; y++)
                {
                    int CurrentLine = y * OrigData.Stride;
                    for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                    {
                        int OldBlue = Pixels[CurrentLine + x];
                        int OldGreen = Pixels[CurrentLine + x + 1];
                        int OldRed = Pixels[CurrentLine + x + 2];

                        int NewBlue = (int)(OldBlue * -0.071 + OldGreen * -0.368 + OldRed * 0.439 + 128);
                        int NewGreen = (int)(OldBlue * 0.439 + OldGreen * -0.291 + OldRed * -0.148 + 128);
                        int NewRed = (int)(OldBlue * 0.098 + OldGreen * 0.504 + OldRed * 0.257 + 16);

                        Pixels[CurrentLine + x] = (byte)(NewBlue);
                        if (NewBlue > 255) Pixels[CurrentLine + x] = 255;
                        if (NewBlue < 0) Pixels[CurrentLine + x] = 1;

                        Pixels[CurrentLine + x + 1] = (byte)(NewGreen);
                        if (NewGreen > 255) Pixels[CurrentLine + x + 1] = 255;
                        if (NewGreen < 0) Pixels[CurrentLine + x + 1] = 1;


                        Pixels[CurrentLine + x + 2] = (byte)(NewRed);
                        if (NewRed > 255) Pixels[CurrentLine + x + 2] = 255;
                        if (NewRed < 0) Pixels[CurrentLine + x + 2] = 1;
                    }
                }
                Marshal.Copy(Pixels, 0, PtrFirstPixel, Pixels.Length);
                OrigImage.UnlockBits(OrigData);
                this.NewImagepictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                NewImagepictureBox.Image = OrigImage;
                OrigImage.Save(SaveFile);
            }
            else
            {
                MessageBox.Show("Please make sure you have selected an Open File and a Save File then try again");
            }
        }


        private void Startbutton_Click(object sender, EventArgs e)
        {
            string OpenFile = OpenFiletextBox.Text;
            string SaveFile = SaveFiletextBox.Text;
            Main(OpenFile, SaveFile);
        }


        private void OpenFilebutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"\C";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFiletextBox.Text = Convert.ToString(openFileDialog1.FileName);
            }
            Bitmap OrigImage = new Bitmap(OpenFiletextBox.Text);
            this.OrigImagepictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            OrigImagepictureBox.Image = OrigImage;
        }


        private void SaveFilebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"\C";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFiletextBox.Text = Convert.ToString(saveFileDialog1.FileName);
            }
        }


        private void Backbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuform MainMenu = new MainMenuform();
            MainMenu.ShowDialog();
        }


        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
