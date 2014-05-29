Image-Processing
================

C# Program for Image Processing.

Creating image transformations
------------------------------

To create a custom image transformation you must use the `IBitmapTransform` Interface. You are required to implemnent the following methods: 
* `ShowParameterDialog()` is responsible for showing the user a Form/Dialog where they can input any parameters for the image transformation.
* `Transform()` is responsible for applying the transform to an image.

If the transform requires the selection of a point or area from the source image you can use the `SelectPoint()` and `SelectArea()` methods provided by the `SelectOnImage` class

For the image transform to show up in the program list you need to add it to `getTransformDictionary()`  in the MainInterface class.
