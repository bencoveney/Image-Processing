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
    class TransformCrop : IBitmapTransform
    {
        Form parameterDialog;
        Bitmap sourceImage;
        Rectangle cropLocation;

        public void ShowParameterDialog(Bitmap Source)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Crop Parameters";
            parameterDialog.Width = 400;

            // Add a button to launch the selection control
            sourceImage = Source;
            Button selectionButton = new Button();
            selectionButton.Text = "Select Crop Area";
            selectionButton.Width = 200;
            selectionButton.Location = new Point(10, 10);
            selectionButton.Click += new EventHandler(GetSelectedArea);
            parameterDialog.Controls.Add(selectionButton);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Width = 200;
            applyButton.Location = new Point(10, selectionButton.Bottom + 10);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Close the dialog
            parameterDialog.Close();
        }

        /// <summary>
        /// Launches the area selection to allow the user to select and area to insert to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSelectedArea(object sender, EventArgs e)
        {
            cropLocation = SelectOnImage.SelectArea(sourceImage);
        }

        public Bitmap Transform(Bitmap Source)
        {
            // Create a new bitmap from the selected area of the source image
            Bitmap Result = Source.Clone(cropLocation, Source.PixelFormat);

            // Convert back
            return Result;
        }
    }
}
