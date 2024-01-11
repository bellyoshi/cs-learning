using Svg;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;


namespace ListReactiveProperty;

internal class ImageCreater
{
    public static BitmapSource GetImageFromFile(PdfFileViewParam pdfFileViewParam)
    {
        return pdfiumWrapper.PDFRender.GetImage(pdfFileViewParam.filename, 
            pdfFileViewParam.Page);
    }
    public static BitmapSource GetImageFromFile(FileViewParam viewParam)
    {
        if (FileTypes.IsImageExt(viewParam.filename))
        {
            return new BitmapImage(new Uri(viewParam.filename));
        }else if (FileTypes.IsSVGExt(viewParam.filename))
        {
            return pdfiumWrapper.PDFRender.GetSVGImage(viewParam.filename);
        }
        else
        {
            throw new Exception("Not supported file type");
        }

    }



}
