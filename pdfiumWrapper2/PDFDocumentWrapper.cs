
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace pdfiumWrapper2
{
    public class PDFDocumentWrapper
    {
        private readonly PdfDocument doc;
        public PDFDocumentWrapper(string filename)
        {
            doc = PdfDocument.Load(filename);
            if (doc == null)
            {
                throw new Exception("PDFDocumentWrapper: PDFDocument.Load failed.");
            }
        }
        public int PageCount => doc.PagesCount;
        public BitmapSource GetImage( int page)
        {
            var image = doc.RenderPage(page, 3840, 2160);//todo :　適切な解像度にする。

            return BitmapConverter.ToBitmapSource(image);
        }
    }
}
