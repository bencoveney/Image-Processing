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
    class TransformBrightness : IBitmapTransform
    {
        Form parameterDialog;
        int brightnessAmount;

        public void ShowParameterDialog(Bitmap Image)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Brightness Parameters";

            // Add the brightness control to the form (with a label)
            Label brightnessLabel = new Label();
            brightnessLabel.Text = "Brightness:";
            brightnessLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(brightnessLabel);
            NumericUpDown brightnessControl = new NumericUpDown();
            brightnessControl.Name = "brightnessControl";
            brightnessControl.Location = new Point(brightnessLabel.Width + 20, 10);
            brightnessControl.Value = 0;
            brightnessControl.Maximum = 255;
            brightnessControl.Minimum = -255;
            parameterDialog.Controls.Add(brightnessControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Width = 200;
            applyButton.Location = new Point(10, brightnessControl.Height + 20);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the brightness control
            NumericUpDown brightnessControl = parameterDialog.Controls.Find("brightnessControl", true).First() as NumericUpDown;

            // Extract the value
            brightnessAmount = (int)brightnessControl.Value;

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

            // Perform the brightness change
            for (int y = 0; y < HeightInPixels; y++)
            {
                int CurrentLine = y * ResultData.Stride;
                for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                {
                    int OldBlue = Pixels[CurrentLine + x];
                    int OldGreen = Pixels[CurrentLine + x + 1];
                    int OldRed = Pixels[CurrentLine + x + 2];

                    Pixels[CurrentLine + x] = toByte(OldBlue + brightnessAmount);
                    if (OldBlue + brightnessAmount > 255) Pixels[CurrentLine + x] = 255;
                    if (OldBlue + brightnessAmount < 0) Pixels[CurrentLine + x] = 1;

                    Pixels[CurrentLine + x + 1] = toByte(OldGreen + brightnessAmount);
                    if (OldGreen + brightnessAmount > 255) Pixels[CurrentLine + x + 1] = 255;
                    if (OldGreen + brightnessAmount < 0) Pixels[CurrentLine + x + 1] = 1;

                    Pixels[CurrentLine + x + 2] = toByte(OldRed + brightnessAmount);
                    if (OldRed + brightnessAmount > 255) Pixels[CurrentLine + x + 2] = 255;
                    if (OldRed + brightnessAmount < 0) Pixels[CurrentLine + x + 2] = 1;
                }
            }

            // Finalise changes and return
            Marshal.Copy(Pixels, 0, PtrFirstPixel, Pixels.Length);
            Result.UnlockBits(ResultData);
            return Result;
        }

        private byte toByte(int Value)
        {
            // Clamp the value between 0 and 255 (the min and max values)
            if (Value < 0) Value = 0;
            if (Value > 255) Value = 255;

            return (byte)Value;
        }
    }
}
