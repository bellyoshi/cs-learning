using pdfiumWrapper;
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
        private readonly PdfiumViewer.Core.PdfDocument doc;
        public PDFDocumentWrapper(string filename)
        {
            doc = PdfiumViewer.Core.PdfDocument.Load(filename);
            if (doc == null)
            {
                throw new Exception("PDFDocumentWrapper: PDFDocument.Load failed.");
            }
        }
        public int PageCount => doc.PageCount;
        public BitmapSource GetImage( int page)
        {

            Bitmap bitmap = new((int)doc.PageSizes[page].Width, (int)doc.PageSizes[page].Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                var bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                //todo dpi 96 いつも同じではない
                doc.Render(page, g, 96, 96, bounds, true);
            }

            return SVGRender.ConvertBitmapToBitmapSource(bitmap);
        }
    }
}
