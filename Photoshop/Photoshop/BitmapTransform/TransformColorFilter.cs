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
    class TransformColorFilter : IBitmapTransform
    {
        Form parameterDialog;
        FilterColor filterColor;

        public void ShowParameterDialog(Bitmap Image)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Color Filter Parameters";

            // Add the brightness control to the form (with a label)
            Label filterColorLabel = new Label();
            filterColorLabel.Text = "Filter Color:";
            filterColorLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(filterColorLabel);
            ComboBox filterColorControl = new ComboBox();
            filterColorControl.DataSource = Enum.GetValues(typeof(FilterColor));
            filterColorControl.Name = "filterColorControl";
            filterColorControl.Location = new Point(filterColorLabel.Width + 20, 10);
            parameterDialog.Controls.Add(filterColorControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(10, filterColorControl.Height + 20);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the filter color control
            ComboBox filterColorControl = parameterDialog.Controls.Find("filterColorControl", true).First() as ComboBox;

            // Extract the value
            filterColor = (FilterColor)Enum.Parse(typeof(FilterColor), filterColorControl.SelectedItem.ToString());

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

            // Perform the color filtering
            switch (filterColor)
            {
                case FilterColor.Red :
                    for (int y = 0; y < HeightInPixels; y++)
                    {
                        int CurrentLine = y * ResultData.Stride;
                        for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                        {
                            int OldBlue = Pixels[CurrentLine + x];
                            int OldGreen = Pixels[CurrentLine + x + 1];

                            Pixels[CurrentLine + x] = (byte)(OldBlue - 255);
                            if (OldBlue - 255 < 0) Pixels[CurrentLine + x] = 1;

                            Pixels[CurrentLine + x + 1] = (byte)(OldGreen - 255);
                            if (OldGreen - 255 < 0) Pixels[CurrentLine + x + 1] = 1;
                        }
                    }
                    break;

                case FilterColor.Green :
                    for (int y = 0; y < HeightInPixels; y++)
                    {
                        int CurrentLine = y * ResultData.Stride;
                        for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                        {
                            int OldBlue = Pixels[CurrentLine + x];
                            int OldRed = Pixels[CurrentLine + x + 2];

                            Pixels[CurrentLine + x] = (byte)(OldBlue - 255);
                            if (OldBlue - 255 < 0) Pixels[CurrentLine + x] = 1;

                            Pixels[CurrentLine + x + 2] = (byte)(OldBlue - 255);
                            if (OldRed - 255 < 0) Pixels[CurrentLine + x + 2] = 1;
                        }
                    }
                    break;

                case FilterColor.Blue :
                    for (int y = 0; y < HeightInPixels; y++)
                    {
                        int CurrentLine = y * ResultData.Stride;
                        for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                        {
                            int OldGreen = Pixels[CurrentLine + x + 1];
                            int OldRed = Pixels[CurrentLine + x + 2];

                            Pixels[CurrentLine + x + 1] = (byte)(OldGreen - 255);
                            if (OldGreen - 255 < 0) Pixels[CurrentLine + x + 1] = 1;

                            Pixels[CurrentLine + x + 2] = (byte)(OldRed - 255);
                            if (OldRed - 255 < 0) Pixels[CurrentLine + x + 2] = 1;
                        }
                    }
                    break;

                case FilterColor.Yellow :
                    for (int y = 0; y < HeightInPixels; y++)
                    {
                        int CurrentLine = y * ResultData.Stride;
                        for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                        {
                            int OldBlue = Pixels[CurrentLine + x];

                            Pixels[CurrentLine + x] = (byte)(OldBlue - 255);
                            if (OldBlue - 255 < 0) Pixels[CurrentLine + x] = 1;
                        }
                    }
                    break;

                case FilterColor.Purple :
                    for (int y = 0; y < HeightInPixels; y++)
                    {
                        int CurrentLine = y * ResultData.Stride;
                        for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                        {
                            int OldGreen = Pixels[CurrentLine + x + 1];

                            Pixels[CurrentLine + x + 1] = (byte)(OldGreen - 255);
                            if (OldGreen - 255 < 0) Pixels[CurrentLine + x + 1] = 1;
                        }
                    }
                    break;

                case FilterColor.Cyan :
                    for (int y = 0; y < HeightInPixels; y++)
                    {
                        int CurrentLine = y * ResultData.Stride;
                        for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                        {
                            int OldRed = Pixels[CurrentLine + x + 2];

                            Pixels[CurrentLine + x + 2] = (byte)(OldRed - 255);
                            if (OldRed - 255 < 0) Pixels[CurrentLine + x + 2] = 1;
                        }
                    }
                    break;

                default :
                    break;
            }

            // Finalise changes and return
            Marshal.Copy(Pixels, 0, PtrFirstPixel, Pixels.Length);
            Result.UnlockBits(ResultData);
            return Result;
        }
    }

    enum FilterColor
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 3,
        Purple = 4,
        Cyan = 5
    }
}
