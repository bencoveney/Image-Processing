using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Photoshop.BitmapTransform
{
    class TransformResize : IBitmapTransform
    {
        Form parameterDialog;

        Size newSize;

        public void ShowParameterDialog(Bitmap Source)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Resize Parameters";

            // Add the width control to the form (with a label)
            Label widthLabel = new Label();
            widthLabel.Text = "New Width:";
            widthLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(widthLabel);
            NumericUpDown widthControl = new NumericUpDown();
            widthControl.Name = "widthControl";
            widthControl.Location = new Point(widthLabel.Width + 20, 10);
            widthControl.Value = 100;
            widthControl.Minimum = 1;
            parameterDialog.Controls.Add(widthControl);
            
            // Add the height control to the form (with a label)
            Label heightLabel = new Label();
            heightLabel.Text = "New Height:";
            heightLabel.Location = new Point(10, widthControl.Height + 23);
            parameterDialog.Controls.Add(heightLabel);
            NumericUpDown heightControl = new NumericUpDown();
            heightControl.Name = "heightControl";
            heightControl.Location = new Point(heightLabel.Width + 20, widthControl.Height + 20);
            heightControl.Value = 100;
            heightControl.Minimum = 1;
            parameterDialog.Controls.Add(heightControl);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(10, widthControl.Height + heightControl.Height + 30);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the resize controls
            NumericUpDown widthControl = parameterDialog.Controls.Find("widthControl", true).First() as NumericUpDown;
            NumericUpDown heightControl = parameterDialog.Controls.Find("heightControl", true).First() as NumericUpDown;

            // Extract the value
            newSize = new Size((int)widthControl.Value, (int)heightControl.Value);

            // Close the dialog
            parameterDialog.Close();
        }

        public Bitmap Transform(Bitmap Source)
        {
            if (Source == null) throw new ArgumentNullException("Source", "No image specified");

            Bitmap Result = new Bitmap(Source,newSize);

            return Result;
        }
    }
}
