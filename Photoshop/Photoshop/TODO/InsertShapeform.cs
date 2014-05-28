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
    public partial class InsertShapeform : Form
    {
        public InsertShapeform()
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

        private void OrigImagepictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs ML = (MouseEventArgs)e;
            ColorDialog Colordialog1 = new ColorDialog(); Color ShapeColor = Color.Black;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ShapeColor = Colordialog1.Color;
            }
            Graphics g = OrigImagepictureBox.CreateGraphics();
            Pen Shapepen = new Pen(ShapeColor);
            int Width = Convert.ToInt32(WidthtextBox.Text); int Height = Convert.ToInt32(HeighttextBox.Text);
            if (ShapecomboBox.Text == "Filled Ellipse")
            {
                g.FillEllipse(Shapepen.Brush, ML.X, ML.Y, Width, Height);
            }
            else if (ShapecomboBox.Text == "Filled Rectangle")
            {
                g.FillRectangle(Shapepen.Brush, ML.X, ML.Y, Width, Height);
            }
            else if (ShapecomboBox.Text == "Normal Ellipse")
            {
                g.DrawEllipse(Shapepen, ML.X, ML.Y, Width, Height);
            }
            else if (ShapecomboBox.Text == "Normal Rectangle")
            {
                g.DrawRectangle(Shapepen, ML.X, ML.Y, Width, Height);
            }
            OrigImagepictureBox.Image.Save(SaveFiletextBox.Text);
        }
    }
}
