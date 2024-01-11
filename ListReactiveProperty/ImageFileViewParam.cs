using ListReactiveProperty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty
{
    public class ImageFileViewParam: FileViewParam, ImageSetter
    {
        public ImageFileViewParam(string filename) : base(filename)
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
