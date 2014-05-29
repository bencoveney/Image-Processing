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
        /// 
        /// The image is supplied in case any transforms require the source image for parameterisation
        /// (ie for selecting where to insert an image).
        /// </summary>
        void ShowParameterDialog(Bitmap Image);

        /// <summary>
        /// Creates a new image by applying the Transform to the Source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        Bitmap Transform(Bitmap Source);
    }
}
