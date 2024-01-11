using Svg;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Input;


namespace ListReactiveProperty;

internal class ImageCreater
{
    public static BitmapSource GetImageFromFile(PdfFileViewParam pdfFileViewParam)
    {
        return pdfiumWrapper.PDFRender.GetImage(pdfFileViewParam.filename, 
            pdfFileViewParam.Page);
    }
    public static BitmapSource GetImageFromFile(SvgFileViewParam svgFileViewParam)
    {
        return pdfiumWrapper.PDFRender.GetSVGImage(svgFileViewParam.filename);
    }
    public static BitmapSource GetImageFromFile(ImageFileViewParam viewParam)
    {
        return new BitmapImage(new Uri(viewParam.filename));
    }



}
