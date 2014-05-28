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
        Bitmap insertImage;
        int insertX, insertY, insertWidth, insertHeight;

        public void ShowParameterDialog()
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Insert Image Parameters";
            parameterDialog.Width = 400;

            // Add the image control to the form (with a label)
            Label imageLabel = new Label();
            imageLabel.Text = "Image:";
            imageLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(imageLabel);
            TextBox imageLocation = new TextBox();
            imageLocation.Name = "imageLocation";
            imageLocation.Location = new Point(imageLabel.Width + 20, 10);
            parameterDialog.Controls.Add(imageLocation);
            Button imageBrowse = new Button();
            imageBrowse.Text = "Browse";
            imageBrowse.Location = new Point(imageLabel.Width + imageLocation.Width + 30, 10);
            imageBrowse.Click += new EventHandler(BrowseImage);
            parameterDialog.Controls.Add(imageBrowse);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(10, imageLocation.Height + 20);
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

            // TODO properly calculate dimensions for insert
            insertX = 0;
            insertY = 0;
            insertWidth = insertImage.Width;
            insertHeight = insertImage.Height;

            // Close the dialog
            parameterDialog.Close();
        }

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

        public Bitmap Transform(Bitmap Source)
        {
            Bitmap Result = new Bitmap(Source);

            // Convert from Bitmap to Graphics
            Graphics g = Graphics.FromImage(Result);

            // Draw the insert
            Rectangle rectangle = new Rectangle(insertX, insertY, insertWidth, insertHeight);
            g.DrawImage(insertImage, rectangle);

            // Convert back
            return Result;
        }
    }
}
