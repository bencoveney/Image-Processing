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
    public partial class Flipform : Form
    {
        public Flipform()
        {
            InitializeComponent();
        }

        private void Main(RotateFlipType FlipType, string OpenFile, string SaveFile)
        {
            if (OpenFile != null && SaveFile != null)
            {
                Bitmap OrigImage = new Bitmap(OpenFile);
                Bitmap NewImage = OrigImage;
                NewImage.RotateFlip(FlipType);
                this.NewImagepictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                NewImagepictureBox.Image = NewImage;
                NewImage.Save(SaveFile);
            }
            else
            {
                MessageBox.Show("Please make sure you have selected an Open File and a Save File then try again");
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


        private void Horizontalbutton_Click(object sender, EventArgs e)
        {
            RotateFlipType FlipType = RotateFlipType.RotateNoneFlipX;
            string OpenFile = OpenFiletextBox.Text;
            string SaveFile = SaveFiletextBox.Text;
            Main(FlipType, OpenFile, SaveFile);
        }


        private void Verticalbutton_Click(object sender, EventArgs e)
        {
            RotateFlipType FlipType = RotateFlipType.RotateNoneFlipY;
            string OpenFile = OpenFiletextBox.Text;
            string SaveFile = SaveFiletextBox.Text;
            Main(FlipType, OpenFile, SaveFile);
        }


        private void HVbutton_Click(object sender, EventArgs e)
        {
            RotateFlipType FlipType = RotateFlipType.RotateNoneFlipXY;

            string OpenFile = OpenFiletextBox.Text;
            string SaveFile = SaveFiletextBox.Text;
            Main(FlipType, OpenFile, SaveFile);
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
