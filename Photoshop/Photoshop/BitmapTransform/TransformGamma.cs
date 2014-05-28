using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Photoshop.BitmapTransform
{
    class TransformGamma : IBitmapTransform
    {
        Form parameterDialog;
        double gammaAmount;

        public void ShowParameterDialog()
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Gamma Parameters";

            // Add the gamma control to the form (with a label)
            Label gammaLabel = new Label();
            gammaLabel.Text = "Gamma:";
            gammaLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(gammaLabel);
            NumericUpDown gammaControl = new NumericUpDown();
            gammaControl.Name = "gammaControl";
            gammaControl.Location = new Point(gammaLabel.Width + 20, 10);
            gammaControl.Value = 2;
            gammaControl.Maximum = 50;
            gammaControl.Minimum = 2;
            parameterDialog.Controls.Add(gammaControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(10, gammaControl.Height + 20);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the gamma control
            NumericUpDown gammaControl = parameterDialog.Controls.Find("gammaControl", true).First() as NumericUpDown;

            // Extract the value
            gammaAmount = (double)gammaControl.Value;

            // Close the dialog
            parameterDialog.Close();
        }

        public Bitmap Transform(Bitmap Source)
        {
            if (Source == null) throw new ArgumentNullException("Source", "No image specified");

            // Extract the bitmap data
            Bitmap Result = new Bitmap(Source);
            BitmapData ResultData = Result.LockBits(new Rectangle(0, 0, Result.Width, Result.Height), ImageLockMode.ReadWrite, Result.PixelFormat);

            // Create a byte array to hold the pixel data
            int BytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(Result.PixelFormat) / 8;
            int ByteCount = ResultData.Stride * Result.Height;
            byte[] Pixels = new byte[ByteCount];

            // Copy the bitmap data to the byte array
            IntPtr PtrFirstPixel = ResultData.Scan0;
            Marshal.Copy(PtrFirstPixel, Pixels, 0, Pixels.Length);

            // Calculate step-through information
            int HeightInPixels = ResultData.Height;
            int WidthInBytes = ResultData.Width * BytesPerPixel;

            byte[] Gamma = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                Gamma[i] = (byte)Math.Min(255, ((255.0 * Math.Pow(i / 255.0, 1.0 / (gammaAmount / 10))) + 0.5));
            }
            for (int y = 0; y < HeightInPixels; y++)
            {
                int CurrentLine = y * ResultData.Stride;
                for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                {
                    int OldBlue = Pixels[CurrentLine + x];
                    int OldGreen = Pixels[CurrentLine + x + 1];
                    int OldRed = Pixels[CurrentLine + x + 2];

                    int NewBlue = Gamma[OldBlue];
                    int NewGreen = Gamma[OldGreen];
                    int NewRed = Gamma[OldRed];

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

            // Finalise changes and return
            Marshal.Copy(Pixels, 0, PtrFirstPixel, Pixels.Length);
            Result.UnlockBits(ResultData);
            return Result;
        }
    }
}
