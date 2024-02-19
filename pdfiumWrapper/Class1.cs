using System.Windows.Media.Imaging;

namespace pdfiumWrapper;

public class Class1
{
    static BitmapImage GetBimapImage(string filename, int page)
    {
        byte[] bytes = GetImageBytes(filename, page);
        BitmapImage bitmapImage = new BitmapImage();
        using (MemoryStream memoryStream = new MemoryStream(bitmapData))
        {
            memoryStream.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
        }
        return bitmapImage;
    }

    static byte[] GetImageBytes(string filename, int page)
    {
        OpenPdfFile(filename);
        return RenderPageToBitmap(pageIndex);
    }
}
