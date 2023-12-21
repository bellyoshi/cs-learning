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

namespace pdfiumWrapper
{
    public class PDFRender
    {
        static public BitmapSource GetImage(string filename , int page)
        {
            PdfiumViewer.Core.PdfDocument doc = PdfiumViewer.Core.PdfDocument.Load(filename);
            Bitmap bitmap = new Bitmap((int)doc.PageSizes[page].Width, (int)doc.PageSizes[page].Height); 
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                var bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                doc.Render(page, g, 96, 96 , bounds, true);
            }

            return ConvertBitmapToBitmapSource(bitmap);
        }
        static  BitmapSource ConvertBitmapToBitmapSource(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);

                stream.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}
