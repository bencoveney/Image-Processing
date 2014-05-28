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
        private Bitmap CurrentImage;

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
                analyseImageToolStripMenuItem.Enabled = true;
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
            // Create a list to house the menu items
            Dictionary<string, IBitmapTransform> TransformDictionary = getTransformDictionary();
            ToolStripMenuItem[] items = new ToolStripMenuItem[TransformDictionary.Count];

            // Populate the list with named items
            for (int i = 0; i < TransformDictionary.Count; i++)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Text = TransformDictionary.ElementAt(i).Key;
                items[i].Click += new EventHandler(transformToolStripItem_Click);
            }

            // Add the list of new items to the menu
            transformToolStripMenuItem.DropDownItems.AddRange(items);
        }

        private void transformToolStripItem_Click(object sender, EventArgs e)
        {
            // Find out which transform item was selected
            ToolStripMenuItem senderItem = sender as ToolStripMenuItem;
            IBitmapTransform Transform = getTransformDictionary().First(x => x.Key == senderItem.Text).Value;

            // Prompt the user for parameter inputs
            Transform.ShowParameterDialog();

            // Perform the transformation
            Bitmap Output = Transform.Transform(CurrentImage);

            setCurrentImage(Output);
        }

        /// <summary>
        /// Returns a dictionary of all availible transforms
        /// To add your transformation to the program add it here
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, IBitmapTransform> getTransformDictionary()
        {
            Dictionary<string, IBitmapTransform> result = new Dictionary<string, IBitmapTransform>();

            result.Add("Brightness", new TransformBrightness());
            result.Add("Contrast", new TransformContrast());
            result.Add("Invert", new TransformInvert());
            result.Add("Rotate", new TransformRotate());

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

        #endregion

    }
}
