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
    public partial class MainMenuform : Form
    {
        public MainMenuform()
        {
            InitializeComponent();
        }


        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void DeadPixelbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeadPixelform DeadPixel = new DeadPixelform();
            DeadPixel.ShowDialog();
        }


        private void Resolutionbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Resolutionform Resolution = new Resolutionform();
            Resolution.ShowDialog();
        }


        private void Roatebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rotateform Rotate = new Rotateform();
            Rotate.ShowDialog();
        }


        private void Cropbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cropform Crop = new Cropform();
            Crop.ShowDialog();
        }


        private void Grayscalebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grayscaleform Grayscale = new Grayscaleform();
            Grayscale.ShowDialog();
        }


        private void Flipbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flipform Flip = new Flipform();
            Flip.ShowDialog();
        }


        private void Resizebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Resizeform Resize = new Resizeform();
            Resize.ShowDialog();
        }


        private void Invertbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Invertform Invert = new Invertform();
            Invert.ShowDialog();
        }


        private void ColorFilterbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ColorFilterform ColorFilter = new ColorFilterform();
            ColorFilter.ShowDialog();
        }


        private void Gammabutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gammaform Gamma = new Gammaform();
            Gamma.ShowDialog();
        }


        private void Brightnessbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Brightnessform Brightness = new Brightnessform();
            Brightness.ShowDialog();
        }


        private void Contrastbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contrastform Contrast = new Contrastform();
            Contrast.ShowDialog();
        }

        private void ImageAnalysebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImageAnalyseform ImageAnalyse = new ImageAnalyseform();
            ImageAnalyse.ShowDialog();
        }

        private void InsertTextbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertTextform InsertText = new InsertTextform();
            InsertText.ShowDialog();
        }

        private void InsertShapebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertShapeform InsertShape = new InsertShapeform();
            InsertShape.ShowDialog();
        }

        private void InsertImagebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertImageform InsertImage = new InsertImageform();
            InsertImage.ShowDialog();
        }

        private void HSVbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            HSLConversionform HSVConversion = new HSLConversionform();
            HSVConversion.ShowDialog();
        }

        private void YCbCrConversionbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            YCbCrConversionform YCbCrConversion = new YCbCrConversionform();
            YCbCrConversion.ShowDialog();
        }
    }
}
