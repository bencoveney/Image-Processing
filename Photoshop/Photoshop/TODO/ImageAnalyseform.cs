using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photoshop
{
    public partial class ImageAnalyseform : Form
    {
        public ImageAnalyseform()
        {
            InitializeComponent();
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

        private void OrigImagepictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs ML = (MouseEventArgs)e;
            Bitmap OrigImage = new Bitmap(OrigImagepictureBox.Image,OrigImagepictureBox.ClientSize.Width, OrigImagepictureBox.ClientSize.Height);
            RedPixelValuetextBox.Text = Convert.ToString(OrigImage.GetPixel(ML.X, ML.Y).R);
            GreenPixelLocationtextBox.Text = Convert.ToString(OrigImage.GetPixel(ML.X, ML.Y).G);
            BluePixelValuetextBox.Text = Convert.ToString(OrigImage.GetPixel(ML.X, ML.Y).B);
            XPixelLocationtextBox.Text = Convert.ToString(ML.X);
            YPixelLocationtextBox.Text = Convert.ToString(ML.Y);
            OrigImage.SetPixel(ML.X, ML.Y, Color.Red);
        }
    }
}
