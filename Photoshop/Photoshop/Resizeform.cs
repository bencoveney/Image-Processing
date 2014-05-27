using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Photoshop
{
    public partial class Resizeform : Form
    {
        public Resizeform()
        {
            InitializeComponent();
        }
        private void Main(int Height, int Width, string OpenFile, string SaveFile)
        {
            if (OpenFile != null && SaveFile != null && HeighttextBox.Text != null && WidthtextBox.Text != null)
            {
                Bitmap OrigImage = new Bitmap(OpenFile);
                Bitmap NewImage = new Bitmap(Width, Height);
                byte NBlue; byte NRed; byte NGreen; byte NColour1; byte NColour2;
                Color Colour1; Color Colour2; Color Colour3; Color Colour4;
                int Floori; int Floorj;
                double Widthfactor = (double)OrigImage.Width / Width; double Heightfactor = (double)OrigImage.Height / Height;
                for (int i = 0; i < OrigImage.Width; i++)
                {
                    for (int j = 0; j < OrigImage.Height; j++)
                    {
                        Floori = (int)Math.Floor(i * Widthfactor); Floorj = (int)Math.Floor(j * Heightfactor);
                        Colour1 = OrigImage.GetPixel(Floori, Floorj);
                        Colour2 = OrigImage.GetPixel(Floori + 1, Floorj);
                        Colour3 = OrigImage.GetPixel(Floori, Floorj + 1);
                        Colour4 = OrigImage.GetPixel(Floori + 1, Floorj + 1);
                        // Red
                        NColour1 = (byte)(1.0 - i * Widthfactor - Floori * Colour1.R + i * Widthfactor - Floori * Colour2.R);
                        NColour2 = (byte)(1.0 - i * Widthfactor - Floori * Colour3.R + i * Widthfactor - Floori * Colour4.R);
                        NRed = (byte)(1.0 - j * Heightfactor - Floorj * (double)(NColour1) + j * Heightfactor - Floorj * (double)(NColour2));
                        // Blue
                        NColour1 = (byte)(1.0 - i * Widthfactor - Floori * Colour1.B + i * Widthfactor - Floori * Colour2.B);
                        NColour2 = (byte)(1.0 - i * Widthfactor - Floori * Colour3.B + i * Widthfactor - Floori * Colour4.B);
                        NBlue = (byte)(1.0 - j * Heightfactor - Floorj * (double)(NColour1) + j * Heightfactor - Floorj * (double)(NColour2));
                        // Green
                        NColour1 = (byte)(1.0 - i * Widthfactor - Floori * Colour1.G + i * Widthfactor - Floori * Colour2.G);
                        NColour2 = (byte)(1.0 - i * Widthfactor - Floori * Colour3.G + i * Widthfactor - Floori * Colour4.G);
                        NGreen = (byte)(1.0 - j * Heightfactor - Floorj * (double)(NColour1) + j * Heightfactor - Floorj * (double)(NColour2));
                        //New Image
                        NewImage.SetPixel(i, j, Color.FromArgb(255, NRed, NBlue, NGreen));
                    }
                }
                this.NewImagepictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                NewImagepictureBox.Image = NewImage;
                NewImage.Save(SaveFile);
            }
            else
            {
                MessageBox.Show("Please make sure you have selected an Open File,a Save File and typed in the height and width then try again");
            }
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


        private void Startbutton_Click(object sender, EventArgs e)
        {
            int Width = Convert.ToInt32(WidthtextBox.Text);
            int Height = Convert.ToInt32(HeighttextBox.Text);
            string OpenFile = OpenFiletextBox.Text;
            string SaveFile = SaveFiletextBox.Text;
            Main(Height, Width, OpenFile, SaveFile);
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
