using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;
using Accessibility;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ListReactiveProperty.Models
{
    internal class ThatModel : INotifyPropertyChanged
        , IDisplay
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Color _backColor;
        public Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackColor)));
            }
        }

        System.Windows.Media.Imaging.BitmapSource? _imageSouce;
        public System.Windows.Media.Imaging.BitmapSource? ImageSource
        {
            get => _imageSouce;
            set
            {
                _imageSouce = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSource)));
            }
        }

        private static ThatModel _instance = new();
        internal static ThatModel GetInstance()
        {
            return _instance;
        }

        public void SetImageSource(BitmapSource? ImageSource)
        {
            this.ImageSource = ImageSource;
        }
    }
}
