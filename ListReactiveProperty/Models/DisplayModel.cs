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
    internal class DisplayModel : INotifyPropertyChanged
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

        BitmapSource? _imageSouce;
        public BitmapSource? PreviewImage
        {
            get => _imageSouce;
            set
            {
                _imageSouce = value;
                if (this.IsAutoDisplayEnabled)
                {
                    this.DisplayImage = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreviewImage)));
            }
        }

        bool _isAutoDisplayEnabled;
        public bool IsAutoDisplayEnabled
        {
            get => _isAutoDisplayEnabled;
            set
            {
                _isAutoDisplayEnabled = value;
                if (value)
                {
                    this.DisplayImage = this.PreviewImage;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAutoDisplayEnabled)));
            }
        }

        BitmapSource? _displayImage;
        public BitmapSource? DisplayImage
        {
            get => _displayImage;
            set
            {
                _displayImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayImage)));
            }
        }

        private static DisplayModel _instance = new();
        internal static DisplayModel GetInstance()
        {
            return _instance;
        }

        public void SetImageSource(BitmapSource? ImageSource)
        {
            
            this.PreviewImage = ImageSource;
        }
    }
}
