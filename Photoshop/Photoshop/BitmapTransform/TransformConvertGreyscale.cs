using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Photoshop.BitmapTransform
{
    class TransformConvertGreyscale : IBitmapTransform
    {
        public void ShowParameterDialog()
        {
            // No parameters required
            // Do nothing
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

            for (int y = 0; y < HeightInPixels; y++)
            {
                int CurrentLine = y * ResultData.Stride;
                for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                {
                    int OldBlue = Pixels[CurrentLine + x];
                    int OldGreen = Pixels[CurrentLine + x + 1];
                    int OldRed = Pixels[CurrentLine + x + 2];

                    int NewColour = (int)(OldBlue * 0.114 + OldGreen * 0.587 + OldRed * 0.299);

                    Pixels[CurrentLine + x] = (byte)(NewColour);
                    if (NewColour > 255) Pixels[CurrentLine + x] = 255;
                    if (NewColour < 0) Pixels[CurrentLine + x] = 1;

                    Pixels[CurrentLine + x + 1] = (byte)(NewColour);
                    if (NewColour > 255) Pixels[CurrentLine + x + 1] = 255;
                    if (NewColour < 0) Pixels[CurrentLine + x + 1] = 1;


                    Pixels[CurrentLine + x + 2] = (byte)(NewColour);
                    if (NewColour > 255) Pixels[CurrentLine + x + 2] = 255;
                    if (NewColour < 0) Pixels[CurrentLine + x + 2] = 1;
                }
            }

            // Finalise changes and return
            Marshal.Copy(Pixels, 0, PtrFirstPixel, Pixels.Length);
            Result.UnlockBits(ResultData);
            return Result;
        }
    }
}
