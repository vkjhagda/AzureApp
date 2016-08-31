using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageResizingWorkerRole
{
    class ImageProcessor
    {
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bitmap = new Bitmap(destWidth, destHeight);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            graphics.Dispose();

            return (Image)bitmap;
        }
    }
}
