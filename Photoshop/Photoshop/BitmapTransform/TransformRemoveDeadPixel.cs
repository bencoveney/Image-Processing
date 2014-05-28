using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Photoshop.BitmapTransform
{
    class TransformRemoveDeadPixel : IBitmapTransform
    {
        static int k = 5; 
        static int[,] C = new int[k, 4];

        public void ShowParameterDialog()
        {
            // No parameters required
            // Do nothing
        }

        public Bitmap Transform(Bitmap Source)
        {
            Bitmap Image = new Bitmap(Source);
            int Rows = Image.Height; int Cols = Image.Width; int[, ,] ImageDist = null;
            int[, ,] ReconPixel = null; int R; int G; int B; int A;
            int[, ,] OrigImage = ImRead(Image, Rows, Cols); k = 4;
            Bitmap ReconImage = Image;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (OrigImage[i, j, 0] == 0 && OrigImage[i, j, 1] == 0 && OrigImage[i, j, 2] == 0)
                    {
                        ImageDist = ImDist(OrigImage, i, j, Rows, Cols, Image);
                        ReconPixel = ImColour(ImageDist, i, j);
                        A = Image.GetPixel(j, i).A;
                        R = ReconPixel[0, 0, 0];
                        G = ReconPixel[0, 0, 1];
                        B = ReconPixel[0, 0, 2];
                        Color NewColour = Color.FromArgb(A, R, G, B);
                        ReconImage.SetPixel(j, i, NewColour);
                    }
                }
            }

            return ReconImage;
        }

        static int[, ,] ImDist(int[, ,] OrigImage, int i, int j, int Rows, int Cols, Bitmap Image)
        {
            int w = i; int y = i; int x = j; int z = j; int l = 0; int[, ,] ImageDist = null;

            while (l <= k)
            {
                l = 0;
                if (w > 0)
                {
                    w = w - 1;
                }
                if (x > 0)
                {
                    x = x - 1;
                }
                if (y < Rows)
                {
                    y = y + 1;
                }
                if (z < Cols)
                {
                    z = z + 1;
                }
                ImageDist = new int[y - w - 1, z - x - 1, 3];
                for (int a = w, b = 0; a < y - 1; a++, b++)
                {
                    for (int c = x, d = 0; c < z - 1; c++, d++)
                    {
                        ImageDist[b, d, 0] = OrigImage[a, c, 0];
                        ImageDist[b, d, 1] = OrigImage[a, c, 1];
                        ImageDist[b, d, 2] = OrigImage[a, c, 2];
                    }
                }
                foreach (int element in ImageDist)
                {
                    if (element > 0)
                    {
                        l += 1;
                    }
                }
            }
            return ImageDist;
        }


        static int[, ,] ImColour(int[, ,] ImageDist, int i, int j)
        {
            int p = 0; int IDRows = ImageDist.GetLength(0); int IDCols = ImageDist.GetLength(1);
            int D; int[, ,] ReconPixel = null;
            for (int m = 0; m < IDRows; m++)
            {
                for (int n = 0; n < IDCols; n++)
                {
                    if (ImageDist[m, n, 0] > 0 || ImageDist[m, n, 1] > 0 || ImageDist[m, n, 2] > 0)
                    {
                        if (p < k)
                        {
                            D = Distance(i, j, m, n);
                            C[p, 0] = ImageDist[m, n, 0];
                            C[p, 1] = ImageDist[m, n, 1];
                            C[p, 2] = ImageDist[m, n, 2];
                            C[p, 3] = D;
                            ReconPixel = Colour(C);
                            p += 1;
                        }
                    }
                }
            }
            return ReconPixel;
        }


        static int Distance(int i, int j, int m, int n)
        {
            int D = Math.Abs(i - m) + Math.Abs(j - n);
            return D;
        }


        static int[, ,] Colour(int[,] C)
        {
            int[, ,] ReconPixel = new int[1, 1, 3];
            for (int a = 0; a < 3; a++)
            {
                int CSum = 0;
                for (int b = 0; b < k; b++)
                {
                    CSum += C[b, a];
                    if (b == k - 1)
                    {
                        ReconPixel[0, 0, a] = CSum / k;
                    }
                }
            }
            return ReconPixel;
        }


        static int[, ,] ImRead(Bitmap Image, int Rows, int Cols)
        {
            int[, ,] OrigImage = new int[Rows, Cols, 3];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    OrigImage[i, j, 0] = Image.GetPixel(j, i).R;
                    OrigImage[i, j, 1] = Image.GetPixel(j, i).G;
                    OrigImage[i, j, 2] = Image.GetPixel(j, i).B;
                }
            }
            return OrigImage;
        }
    }
}
