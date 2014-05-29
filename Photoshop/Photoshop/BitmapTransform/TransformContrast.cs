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
    class TransformContrast : IBitmapTransform
    {
        Form parameterDialog;
        double contrastAmount;

        public void ShowParameterDialog(Bitmap Image)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Constrast Parameters";

            // Add the contrast control to the form (with a label)
            Label contrastLabel = new Label();
            contrastLabel.Text = "Constrast:";
            contrastLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(contrastLabel);
            NumericUpDown contrastControl = new NumericUpDown();
            contrastControl.Name = "contrastControl";
            contrastControl.Location = new Point(contrastLabel.Width + 20, 10);
            contrastControl.Value = 0;
            contrastControl.Maximum = 100;
            contrastControl.Minimum = -100;
            parameterDialog.Controls.Add(contrastControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(10, contrastControl.Height + 20);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the contrast control
            NumericUpDown contrastControl = parameterDialog.Controls.Find("contrastControl", true).First() as NumericUpDown;

            // Extract the value
            contrastAmount = (double)contrastControl.Value;

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

            // Scale the contrast value
            double NewContrast = (100.0 + contrastAmount) / 100.0;
            NewContrast *= NewContrast;

            // Perform the contrast change
            for (int y = 0; y < HeightInPixels; y++)
            {
                int CurrentLine = y * ResultData.Stride;
                for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                {
                    int OldBlue = Pixels[CurrentLine + x];
                    int OldGreen = Pixels[CurrentLine + x + 1];
                    int OldRed = Pixels[CurrentLine + x + 2];

                    double NewRed = OldRed / 255.0;
                    NewRed -= 0.5;
                    NewRed *= NewContrast;
                    NewRed += 0.5;
                    NewRed *= 255;

                    double NewGreen = OldGreen / 255.0;
                    NewGreen -= 0.5;
                    NewGreen *= NewContrast;
                    NewGreen += 0.5;
                    NewGreen *= 255;

                    double NewBlue = OldBlue / 255.0;
                    NewBlue -= 0.5;
                    NewBlue *= NewContrast;
                    NewBlue += 0.5;
                    NewBlue *= 255;

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
