using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Photoshop.BitmapTransform
{
    public partial class SelectOnImage : Form
    {
        #region Form Launchers
        /// <summary>
        /// Displays the Selection dialog and allows the user to select an area
        /// </summary>
        /// <returns></returns>
        public static Rectangle SelectArea(Bitmap Image)
        {
            // Launch the form
            SelectOnImage selectionForm = new SelectOnImage(Image, false);
            selectionForm.ShowDialog();

            // Return the form's result
            return selectionForm.selectedArea;
        }

        /// <summary>
        /// Displays the Selection dialog and allows the user to select a point
        /// </summary>
        /// <returns></returns>
        public static Point SelectPoint(Bitmap Image)
        {
            // Launch the form
            SelectOnImage selectionForm = new SelectOnImage(Image, true);
            selectionForm.ShowDialog();

            // Return the form's result
            return selectionForm.selectedPoint;
        }

        #endregion

        private Bitmap image;
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        bool isPointSelection;

        public Rectangle selectedArea;
        public Point selectedAreaStartPoint;

        public Point selectedPoint;

        public SelectOnImage(Bitmap Image, bool isPointSelection)
        {
            // Initialise data members
            this.image = Image;
            this.isPointSelection = isPointSelection;
            selectedArea = new Rectangle(0, 0, 0, 0);
            selectedPoint = new Point(0, 0);

            // Take selection-type dependant actions
            if (isPointSelection)
            {
                this.Text = "Select a point on the Image";
            }
            else
            {
                this.Text = "Select an area of the Image";
            }

            InitializeComponent();
        }

        private void ImageDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (isPointSelection)
            {
                Rectangle verticalLine = new Rectangle(selectedPoint.X, selectedPoint.Y-5, 1, 11);
                e.Graphics.FillRectangle(selectionBrush, verticalLine);
                Rectangle horizontalLine = new Rectangle(selectedPoint.X - 5, selectedPoint.Y, 11, 1);
                e.Graphics.FillRectangle(selectionBrush, verticalLine);
            }
            else
            {
                e.Graphics.FillRectangle(selectionBrush, selectedArea);
            }
        }

        private void ImageDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            selectedAreaStartPoint = e.Location;
            Invalidate();
        }

        private void ImageDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Only continue if the user is dragging
            if (e.Button != MouseButtons.Left)
                return;

            // Find the top left point
            Point tempEndPoint = e.Location;
            selectedArea.Location = new Point(
                Math.Min(selectedAreaStartPoint.X, tempEndPoint.X),
                Math.Min(selectedAreaStartPoint.Y, tempEndPoint.Y));

            // Find the dimensions
            selectedArea.Size = new Size(
                Math.Abs(selectedAreaStartPoint.X - tempEndPoint.X),
                Math.Abs(selectedAreaStartPoint.Y - tempEndPoint.Y));

            // Redraw the picturebox
            ImageDisplay.Invalidate();
        }

        private void SelectOnImage_Load(object sender, EventArgs e)
        {
            ImageDisplay.Image = image;
        }

        private void MakeSelectionButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (!isPointSelection)
            {
                if(selectedArea.Width <= 0 || selectedArea.Height <= 0)
                {
                    MessageBox.Show("No area selected!", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.Close();
        }
    }
}
