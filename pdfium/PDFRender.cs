using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pdfium;

internal class PDFRender
{
    readonly IntPtr m_pdfDoc;
    internal PDFRender(IntPtr pdfDocumentPtr)
    {
        this.m_pdfDoc = pdfDocumentPtr;
    }
    public Image RenderPage(int pageIndex, int renderWidth, int renderHeight)
    {
        IntPtr pagePtr = Win32Api.FPDF_LoadPage(m_pdfDoc, pageIndex);
        System.Drawing.Image image = new Bitmap(renderWidth, renderHeight);
        Graphics g = Graphics.FromImage(image);
        // 背景を白色で塗りつぶす
        g.FillRectangle(Brushes.White, g.VisibleClipBounds);

        IntPtr hDC = g.GetHdc();
        Win32Api.FPDF_RenderPage(hDC, pagePtr, 0, 0, renderWidth, renderHeight, 0, 0);
        g.ReleaseHdc();
        g.Dispose();
        return image;
    }

}
