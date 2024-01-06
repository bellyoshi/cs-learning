using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.Models
{
    public interface IDisplay
    {
        void SetImageSource(System.Windows.Media.Imaging.BitmapSource? ImageSource); 
    }
}
