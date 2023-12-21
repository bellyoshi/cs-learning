using System.IO;
using System.Windows.Media.Imaging;

namespace ListReactiveProperty;

internal class ImageCreater
{
    public static BitmapSource GetImageFromFile(FileViewParam viewParam)
    {
        return pdfiumWrapper.PDFRender.GetImage(viewParam.filename, 0);
    }



}
