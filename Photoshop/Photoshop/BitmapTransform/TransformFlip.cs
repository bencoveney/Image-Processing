using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Photoshop.BitmapTransform
{
    class TransformFlip : IBitmapTransform
    {
        Form parameterDialog;

        bool horizontalFlip;
        bool verticalFlip;

        public void ShowParameterDialog(Bitmap Source)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Flip Parameters";

            // Add the hflip control to the form
            CheckBox horizontalFlipControl = new CheckBox();
            horizontalFlipControl.Text = "Flip Horizontal";
            horizontalFlipControl.Name = "horizontalFlipControl";
            horizontalFlipControl.Location = new Point(10, 10);
            parameterDialog.Controls.Add(horizontalFlipControl);

            // Add the vflip control to the form
            CheckBox verticalFlipControl = new CheckBox();
            verticalFlipControl.Text = "Flip Vertical";
            verticalFlipControl.Name = "verticalFlipControl";
            verticalFlipControl.Location = new Point(10, horizontalFlipControl.Height + 20);
            parameterDialog.Controls.Add(verticalFlipControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Width = 200;
            applyButton.Location = new Point(10, horizontalFlipControl.Height + verticalFlipControl.Height + 30);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the flip controls
            CheckBox horizontalFlipControl = parameterDialog.Controls.Find("horizontalFlipControl", true).First() as CheckBox;
            CheckBox verticalFlipControl = parameterDialog.Controls.Find("verticalFlipControl", true).First() as CheckBox;

            // Extract the value
            horizontalFlip = horizontalFlipControl.Checked;
            verticalFlip = verticalFlipControl.Checked;

            // Close the dialog
            parameterDialog.Close();
        }

        public Bitmap Transform(Bitmap Source)
        {
            if (Source == null) throw new ArgumentNullException("Source", "No image specified");

            Bitmap Result = new Bitmap(Source);

            // Decide which type of flip to perform
            RotateFlipType transform;
            if (horizontalFlip)
            {
                if (verticalFlip)
                {
                    transform = RotateFlipType.RotateNoneFlipXY;
                }
                else
                {
                    transform = RotateFlipType.RotateNoneFlipX;
                }
            }
            else
            {
                if (verticalFlip)
                {
                    transform = RotateFlipType.RotateNoneFlipY;
                }
                else
                {
                    transform = RotateFlipType.RotateNoneFlipNone;
                }
            }

            // Perform the flip
            Result.RotateFlip(transform);

            return Result;
        }
    }
}
