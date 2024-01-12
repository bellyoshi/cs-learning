using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO.Enumeration;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Svg;
namespace pdfiumWrapper
{
    public class PDFRender
    {


        public static BitmapSource GetSVGImage(string filename)
        {
            SvgDocument svgDocument = SvgDocument.Open(filename);
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;
            Bitmap bitmap = svgDocument.Draw();

            return ConvertBitmapToBitmapSource(bitmap);
        }

       public static  BitmapImage ConvertBitmapToBitmapSource(Bitmap bitmap)
        {
            using var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);

            stream.Position = 0;
            BitmapImage bitmapImage = new();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
