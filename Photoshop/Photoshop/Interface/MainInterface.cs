using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Photoshop.BitmapTransform;

namespace Photoshop.Interface
{
    public partial class MainInterface : Form
    {
        private static Bitmap CurrentImage;

        public MainInterface()
        {
            InitializeComponent();
        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            populateTransformList();
        }

        #region File operations

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
                setCurrentImage(new Bitmap(openFileDialog.FileName));

                // Enable all greyed-out menu items
                saveToolStripMenuItem.Enabled = true;
                transformToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Create the file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"\C";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            // Show the dialog
            DialogResult result = saveFileDialog.ShowDialog();

            // If the dialog was successful save the file
            if (result == DialogResult.OK)
            {
                CurrentImage.Save(saveFileDialog.FileName);
            }
        }

        #endregion 

        #region Transform operations

        /// <summary>
        /// Populates the "Transform Image" menu
        /// </summary>
        private void populateTransformList()
        {
            // Get the list of transforms
            Dictionary<string, IBitmapTransform> TransformDictionary = getTransformDictionary();

            // Populate the menu using the list
            for (int i = 0; i < TransformDictionary.Count; i++)
            {
                // Create the menu item
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = TransformDictionary.ElementAt(i).Key;
                item.Click += new EventHandler(transformToolStripItem_Click);

                // Add it to the menu
                transformToolStripMenuItem.DropDownItems.Add(item);

                // UGLY CODE
                // If the given item was one of a selected few, add a seperator to the list after it
                if (TransformDictionary.ElementAt(i).Key == "Crop" ||
                    TransformDictionary.ElementAt(i).Key == "Color Filter" ||
                    TransformDictionary.ElementAt(i).Key == "Convert to YCbCr" ||
                    TransformDictionary.ElementAt(i).Key == "Insert Text")
                {
                    transformToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
                }
            
            }
        }

        private void transformToolStripItem_Click(object sender, EventArgs e)
        {
            // Find out which transform item was selected
            ToolStripMenuItem senderItem = sender as ToolStripMenuItem;
            IBitmapTransform Transform = getTransformDictionary().First(x => x.Key == senderItem.Text).Value;

            // Prompt the user for parameter inputs
            Transform.ShowParameterDialog(CurrentImage);

            try
            {
                // Perform the transformation
                Bitmap Output = Transform.Transform(CurrentImage);
                setCurrentImage(Output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to apply Transformation\n\n" + ex.Message, "Transformation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Returns a dictionary of all availible transforms
        /// To add your transformation to the program add it here
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, IBitmapTransform> getTransformDictionary()
        {
            Dictionary<string, IBitmapTransform> result = new Dictionary<string, IBitmapTransform>();

            result.Add("Flip", new TransformFlip());
            result.Add("Rotate", new TransformRotate());
            result.Add("Resize", new TransformResize());
            result.Add("Crop", new TransformCrop());

            result.Add("Brightness", new TransformBrightness());
            result.Add("Contrast", new TransformContrast());
            result.Add("Gamma", new TransformGamma());
            result.Add("Invert Colors", new TransformInvert());
            result.Add("Color Filter", new TransformColorFilter());

            result.Add("Convert to Greyscale", new TransformConvertGreyscale());
            result.Add("Convert to HSL", new TransformConvertHSL());
            result.Add("Convert to YCbCr", new TransformConvertYCbCr());

            result.Add("Insert Image", new TransformInsertImage());
            result.Add("Insert Shape", new TransformInsertShape());
            result.Add("Insert Text", new TransformInsertText());

            result.Add("Remove Dead Pixels", new TransformRemoveDeadPixel());

            return result;
        }

        #endregion

        #region Image preview

        private void setCurrentImage(Bitmap Image)
        {
            // Set the current image
            CurrentImage = Image;

            // Update the preview
            ImagePreview.Image = CurrentImage;
        }

        private void ImagePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentImage == null)
            {
                toolStripStatusLabel.Text = "";
                return;
            }

            // Get the mouse position
            int MousePositionX = e.X;
            int MousePositionY = e.Y;
            string mousePosString = string.Format("Mouse Position: ({0},{1})", MousePositionX, MousePositionY);

            // Is the mouse over the image?
            if(MousePositionX < CurrentImage.Width && MousePositionY < CurrentImage.Height)
            {
                // Get the color under the pointer
                Color c = CurrentImage.GetPixel(MousePositionX,MousePositionY);
                toolStripStatusLabel.Text = string.Format("Mouse Position: ({0},{1}) Color: (R:{2}, G:{3}, B:{4})", MousePositionX, MousePositionY, c.R, c.G, c.B);
            }
            else
            {
                toolStripStatusLabel.Text = string.Format("Mouse Position: ({0},{1})", MousePositionX, MousePositionY);
            }
        }

        #endregion

        #region Info

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Image Processing in C#\n\nContributors:\nMitchus\nbencoveney", "Image Processing Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        #endregion
    }
}
