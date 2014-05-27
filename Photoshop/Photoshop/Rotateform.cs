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
    public partial class Rotateform : Form
    {
        public Rotateform()
        {
            InitializeComponent();
        }


        private void Main(int Degree, string OpenFile, string SaveFile)
        {
            if (OpenFile != null && SaveFile != null && DegreetextBox.Text != null)
            {
                Bitmap OrigImage = new Bitmap(OpenFile);
                Bitmap NewImage = OrigImage;
                if (Degree == 90)
                {
                    NewImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if (Degree == 180)
                {
                    NewImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (Degree == 270)
                {
                    NewImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    MessageBox.Show("Please enter valid degrees(90,180 or 270)");
                }
                this.NewImagepictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                NewImagepictureBox.Image = NewImage;
                NewImage.Save(SaveFile);
            }
            else
            {
                MessageBox.Show("Please make sure you have selected an Open File,a Save File and typed in a Degree then try again");
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
            int Degree = Convert.ToInt32(DegreetextBox.Text);
            string OpenFile = OpenFiletextBox.Text;
            string SaveFile = SaveFiletextBox.Text;
            Main(Degree, OpenFile, SaveFile);
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
