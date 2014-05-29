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
    class TransformInsertText : IBitmapTransform
    {
        Form parameterDialog;

        Bitmap sourceImage;

        string text;
        Point insertLocation;
        Font font;
        Color color;

        public void ShowParameterDialog(Bitmap Source)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Insert Text Parameters";
            parameterDialog.Width = 400;

            // Add the text input
            Label textLabel = new Label();
            textLabel.Text = "Text to Insert:";
            textLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(textLabel);
            TextBox textControl = new TextBox();
            textControl.Name = "textControl";
            textControl.Location = new Point(textLabel.Right + 10, 10);
            parameterDialog.Controls.Add(textControl);

            // Add a button to launch the area selection control
            sourceImage = Source;
            Button areaSelectionButton = new Button();
            areaSelectionButton.Text = "Select Insertion Point";
            areaSelectionButton.Width = 200;
            areaSelectionButton.Location = new Point(10, textControl.Bottom + 10);
            areaSelectionButton.Click += new EventHandler(GetSelectedArea);
            parameterDialog.Controls.Add(areaSelectionButton);

            // Add a button to launch the color selection
            Button colorSelectionButton = new Button();
            colorSelectionButton.Text = "Select Color";
            colorSelectionButton.Name = "colorSelectionButton";
            colorSelectionButton.Width = 200;
            colorSelectionButton.Location = new Point(10, areaSelectionButton.Bottom + 10);
            colorSelectionButton.Click += new EventHandler(GetSelectedColor);
            parameterDialog.Controls.Add(colorSelectionButton);

            // Add a button to launch the color selection
            Button fontSelectionButton = new Button();
            fontSelectionButton.Text = "Select Font";
            fontSelectionButton.Name = "fontSelectionButton";
            fontSelectionButton.Width = 200;
            fontSelectionButton.Height = 50;
            fontSelectionButton.Location = new Point(10, colorSelectionButton.Bottom + 10);
            fontSelectionButton.Click += new EventHandler(GetSelectedFont);
            parameterDialog.Controls.Add(fontSelectionButton);

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Width = 200;
            applyButton.Location = new Point(10, fontSelectionButton.Bottom + 10);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Retrieve the text
            TextBox textControl = parameterDialog.Controls.Find("textControl", true).First() as TextBox;
            text = textControl.Text;

            if (text == "")
            {
                MessageBox.Show("No text given!", "Empty Parameter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            insertLocation = SelectOnImage.SelectPoint(sourceImage);
        }

        private void GetSelectedColor(object sender, EventArgs e)
        {
            // Show a color selection dialog
            ColorDialog colorSelector = new ColorDialog();
            colorSelector.AllowFullOpen = true;
            colorSelector.AnyColor = true;
            colorSelector.Color = Color.Red;
            DialogResult result = colorSelector.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Retrieve the selected value
                color = colorSelector.Color;

                // Color the button the selected color
                Button colorButton = parameterDialog.Controls.Find("colorSelectionButton", true).First() as Button;
                colorButton.BackColor = color;
            }
        }

        private void GetSelectedFont(object sender, EventArgs e)
        {
            // Show a color selection dialog
            FontDialog fontSelector = new FontDialog();
            DialogResult result = fontSelector.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Retrieve the selected value
                font = fontSelector.Font;

                // Style the button using the selected font
                Button fontButton = parameterDialog.Controls.Find("fontSelectionButton", true).First() as Button;
                fontButton.Font = font;
            }
        }

        public Bitmap Transform(Bitmap Source)
        {
            Bitmap Result = new Bitmap(Source);

            // Convert from Bitmap to Graphics
            Graphics g = Graphics.FromImage(Result);

            Brush brush = new SolidBrush(color);
            Pen pen = new Pen(brush);

            // Draw the string
            g.DrawString(text, font, brush, insertLocation.X, insertLocation.Y);

            // Convert back
            return Result;
        }
    }
}
