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
    public partial class Cropform : Form
    {
        public Cropform()
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

        private void OrigImagepictureBox_Click(object sender, EventArgs e)
        {
            Bitmap OrigImage = new Bitmap(OpenFiletextBox.Text);
            MouseEventArgs ML = (MouseEventArgs)e;
            int XStart = ML.X; int YStart = ML.Y;
            int Width = Convert.ToInt32(WidthtextBox.Text); int Height = Convert.ToInt32(HeighttextBox.Text);
            Rectangle CropArea = new Rectangle(XStart, YStart, Width, Height);
            Bitmap NewImage = OrigImage.Clone(CropArea, OrigImage.PixelFormat);
            this.NewImagepictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            NewImagepictureBox.Image = NewImage;
            NewImage.Save(SaveFiletextBox.Text);
        }
    }
}
