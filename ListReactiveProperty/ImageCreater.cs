using Svg;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;


namespace ListReactiveProperty;

internal class ImageCreater
{
    public static BitmapSource GetImageFromFile(FileViewParam viewParam)
    {
        if (FileTypes.IsImageExt(viewParam.filename))
        {
            return new BitmapImage(new Uri(viewParam.filename));
        }else if (FileTypes.IsSVGExt(viewParam.filename))
        {
            return pdfiumWrapper.PDFRender.GetSVGImage(viewParam.filename);
        }
        else if (FileTypes.IsMovieExt(viewParam.filename))
        {
            return null;
        }
        else if (FileTypes.IsPDFExt(viewParam.filename))
        {
            return pdfiumWrapper.PDFRender.GetImage(viewParam.filename, 0);
        }
        else
        {
            return null;
        }

    }



}
