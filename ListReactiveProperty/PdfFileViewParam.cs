using ListReactiveProperty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ListReactiveProperty
{
    public class PdfFileViewParam : FileViewParam, ImageSetter
    {
        public pdfiumWrapper2.PDFDocumentWrapper PDFDocumentWrapper { get; }
        public int Page { get; 
            set; } = 1;
        public int PageCount { get; set; } = 1;
        public PdfFileViewParam(string filename) : base(filename)
        {
            PDFDocumentWrapper = new pdfiumWrapper2.PDFDocumentWrapper(filename);
            PageCount = PDFDocumentWrapper.PageCount;
        }
        private IDisplay? _display;
        public void SetDisplay(IDisplay display)
        {
            this._display = display;
            ExecuteDisplay();
        }

        public void ExecuteDisplay()
        {
            if (this._display == null) return;
            var image = ImageCreater.GetImageFromFile(this);
            _display.SetImageSource(image);
        }
        public bool CanNextPage => Page < PageCount;
        public void NextPage()
        {
            if (!CanNextPage) return;
            Page++;
            ExecuteDisplay();
        }
        public bool CanPrevPage => Page > 1;
        
        public void PrevPage()
        {
            if (!CanPrevPage) return;
            Page--;
            ExecuteDisplay();
        }
    }
}
