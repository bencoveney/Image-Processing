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
    class TransformInsertShape : IBitmapTransform
    {
        Form parameterDialog;

        Bitmap sourceImage;

        Rectangle insertLocation;
        ShapeType shapeType;
        Color color;

        public void ShowParameterDialog(Bitmap Source)
        {
            // Create a new form
            parameterDialog = new Form();
            parameterDialog.Text = "Insert Image Parameters";
            parameterDialog.Width = 400;

            // Add the shape control to the form (with a label)
            Label shapeTypeLabel = new Label();
            shapeTypeLabel.Text = "Shape Type:";
            shapeTypeLabel.Location = new Point(10, 13);
            parameterDialog.Controls.Add(shapeTypeLabel);
            ComboBox shapeTypeControl = new ComboBox();
            shapeTypeControl.DataSource = Enum.GetValues(typeof(ShapeType));
            shapeTypeControl.Name = "shapeTypeControl";
            shapeTypeControl.Location = new Point(shapeTypeLabel.Width + 20, 10);
            parameterDialog.Controls.Add(shapeTypeControl);

            // Add a button to launch the area selection control
            sourceImage = Source;
            Button areaSelectionButton = new Button();
            areaSelectionButton.Text = "Select Insertion Area";
            areaSelectionButton.Width = 200;
            areaSelectionButton.Location = new Point(10, shapeTypeControl.Bottom + 10);
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

            // Add an apply button to the form
            Button applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Width = 200;
            applyButton.Location = new Point(10, colorSelectionButton.Bottom + 10);
            applyButton.Click += new EventHandler(CloseParameterDialog);
            parameterDialog.Controls.Add(applyButton);

            // Show the dialog
            parameterDialog.ShowDialog();
        }

        private void CloseParameterDialog(object sender, EventArgs e)
        {
            // Find the shape type control and extract the value
            ComboBox shapeTypeControl = parameterDialog.Controls.Find("shapeTypeControl", true).First() as ComboBox;
            shapeType = (ShapeType)Enum.Parse(typeof(ShapeType), shapeTypeControl.SelectedItem.ToString());

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

        public Bitmap Transform(Bitmap Source)
        {
            Bitmap Result = new Bitmap(Source);

            // Convert from Bitmap to Graphics
            Graphics g = Graphics.FromImage(Result);

            Brush brush = new SolidBrush(color);
            Pen pen = new Pen(brush);

            // Draw the shape
            switch (shapeType)
            {
                case ShapeType.OutlineEllipse:
                    g.DrawEllipse(pen, insertLocation);
                    break;

                case ShapeType.OutlineRectangle:
                    g.DrawRectangle(pen, insertLocation);
                    break;

                case ShapeType.FilledEllipse :
                    g.FillEllipse(brush, insertLocation);
                    break;

                default :
                case ShapeType.FilledRectangle :
                    g.FillRectangle(brush, insertLocation);
                    break;
            }

            // Convert back
            return Result;
        }
    }

    enum ShapeType
    {
        OutlineRectangle = 0,
        OutlineEllipse = 1,
        FilledRectangle = 2,
        FilledEllipse = 3
    }
}
