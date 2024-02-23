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
using pdfiumWrapper2;
namespace pdfiumWrapper
{
    public class SVGRender
    {


        public static BitmapSource GetSVGImage(string filename)
        {
            SvgDocument svgDocument = SvgDocument.Open(filename);
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;
            Bitmap bitmap = svgDocument.Draw();

            return BitmapConverter.ToBitmapSource(bitmap);
        }


    }
}
