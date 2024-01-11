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
        public int Page { get; 
            set; } = 1;
        public PdfFileViewParam(string filename) : base(filename)
        {
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
    }
}
