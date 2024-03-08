using ListReactiveProperty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ListReactiveProperty.FileViewParams
{
    abstract public class DocuGraphFileViewParam(string filename) : FileViewParam(filename), ImageSetter
    {

        private IDisplay? _display;
        public void SetDisplay(IDisplay display)
        {
            _display = display;
            ExecuteDisplay();
        }

        public void ExecuteDisplay()
        {
            if (_display == null) return;
            var image = GetImageFromFile();
            _display.SetImageSource(image);
        }

        public abstract BitmapSource GetImageFromFile();
        
    }
}
