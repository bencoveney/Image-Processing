using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Photoshop.BitmapTransform
{
    interface IBitmapTransform
    {
        /// <summary>
        /// Launches a dialog box which allows the user to set the transformation's parameters
        /// </summary>
        public void ShowParameterDialog();

        /// <summary>
        /// Creates a new image by applying the Transform to the Source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Bitmap Transform(Bitmap Source);
    }
}
