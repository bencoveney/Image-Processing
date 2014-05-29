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
    class TransformInsertImage : IBitmapTransform
    {
        Form parameterDialog;
        Bitmap sourceImage;
        Bitmap insertImage;
        Rectangle insertLocation;

        public void ShowParameterDialog(Bitmap Source)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Insert Image Parameters";
            parameterDialog.Width = 400;

            // Add the image control to the form (with a label)
            Label imageLabel = new Label();
            imageLabel.Text = "Image to Insert:";
            imageLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(imageLabel);
            TextBox imageLocation = new TextBox();
            imageLocation.Name = "imageLocation";
            imageLocation.Location = new Point(imageLabel.Right + 10, 10);
            parameterDialog.Controls.Add(imageLocation);
            Button imageBrowse = new Button();
            imageBrowse.Text = "Browse";
            imageBrowse.Location = new Point(imageLocation.Right + 10, 8);
            imageBrowse.Click += new EventHandler(BrowseImage);
            parameterDialog.Controls.Add(imageBrowse);

            // Add a button to launch the selection control
            sourceImage = Source;
            Button selectionButton = new Button();
            selectionButton.Text = "Select Insertion Area";
            selectionButton.Width = 200;
            selectionButton.Location = new Point(10, imageBrowse.Bottom + 10);
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
            // Find the image location control
            TextBox imageLocationControl = parameterDialog.Controls.Find("imageLocation", true).First() as TextBox;

            // Extract the value
            insertImage = new Bitmap(imageLocationControl.Text);

            // Close the dialog
            parameterDialog.Close();
        }

        /// <summary>
        /// Launches the file browser to allow the user to select an image to insert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseImage(object sender, EventArgs e)
        {
            // Create the file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"\C";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            // Show the dialog
            DialogResult result = openFileDialog.ShowDialog();

            // If the dialog was successful open the file
            if (result == DialogResult.OK)
            {
                TextBox imageLocationControl = parameterDialog.Controls.Find("imageLocation", true).First() as TextBox;
                imageLocationControl.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Launches the area selection to allow the user to select and area to insert to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSelectedArea(object sender, EventArgs e)
        {
            insertLocation = SelectOnImage.SelectArea(sourceImage);
        }

        public Bitmap Transform(Bitmap Source)
        {
            Bitmap Result = new Bitmap(Source);

            // Convert from Bitmap to Graphics
            Graphics g = Graphics.FromImage(Result);

            // Draw the insert
            g.DrawImage(insertImage, insertLocation);

            // Convert back
            return Result;
        }
    }
}
