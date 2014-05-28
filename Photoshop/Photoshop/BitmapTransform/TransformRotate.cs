using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Photoshop.BitmapTransform
{
    class TransformRotate : IBitmapTransform
    {
        Form parameterDialog;
        int rotationAmount;

        public void ShowParameterDialog()
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Rotation Parameters";

            // Add the rotation control to the form (with a label)
            Label rotationLabel = new Label();
            rotationLabel.Text = "Rotation:";
            rotationLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(rotationLabel);
            NumericUpDown rotationControl = new NumericUpDown();
            rotationControl.Name = "rotationControl";
            rotationControl.Location = new Point(rotationLabel.Width + 20, 10);
            rotationControl.Value = 0;
            rotationControl.Maximum = 360;
            rotationControl.Minimum = -360;
            rotationControl.Increment = 90;
            parameterDialog.Controls.Add(rotationControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(10, rotationControl.Height + 20);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the rotation control
            NumericUpDown rotationControl = parameterDialog.Controls.Find("rotationControl", true).First() as NumericUpDown;

            // Extract the value
            rotationAmount = (int)rotationControl.Value;

            // Close the dialog
            parameterDialog.Close();
        }

        public Bitmap Transform(Bitmap Source)
        {
            if (Source == null) throw new ArgumentNullException("Source", "No image specified");

            Bitmap Result = new Bitmap(Source);

            switch(rotationAmount)
            {
                case 90 :
                case -270 :
                    Result.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case 180 :
                case -180 :
                    Result.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case 270 :
                case -90 :
                    Result.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case 0 :
                case 360 :
                case -360:
                default :
                    break;
            }

            return Result;
        }
    }
}
