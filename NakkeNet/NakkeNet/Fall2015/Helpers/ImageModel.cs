using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace NakkeNet.Helpers
{
    public class ImageModel
    {
        public static void ResizeAndSave(string savePath, string fileName, Stream imageBuffer, int maxSideSize)
        {
            int newWidth;
            int newHeight;
            Image image = Image.FromStream(imageBuffer);
            int oldWidth = image.Width;
            int oldHeight = image.Height;
            int maxSide = oldWidth >= oldHeight ? oldWidth : oldHeight;

            if (maxSide > maxSideSize)
            {
                double coeficient = maxSideSize / (double)maxSide;
                newWidth = Convert.ToInt32(coeficient * oldWidth);
                newHeight = Convert.ToInt32(coeficient * oldHeight);
            }
            else
            {
                newWidth = oldWidth;
                newHeight = oldHeight;
            }
            Bitmap newImage = new Bitmap(image, newWidth, newHeight);
            newImage.Save(savePath + fileName + ".jpg", ImageFormat.Jpeg);
            image.Dispose();
            newImage.Dispose();
        }
    }
}