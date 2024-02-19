using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.Models
{
    internal class ScreenModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //singleton
        private static ScreenModel _instance = new();
        internal static ScreenModel GetInstance()
        {
            return _instance;
        }

        private Rectangle _windowModeWindowLayout = new(50, 50, 640, 480);
        public Rectangle WindowModeWindowLayout
        {
            get => _windowModeWindowLayout;
            set
            {
                _windowModeWindowLayout = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WindowModeWindowLayout)));
            }
        }

        public Rectangle FullScreenWindowLayout => System.Windows.Forms.Screen.AllScreens[ScreenIndex].Bounds;
            
        public Rectangle WindowLayout => IsFullScreen ? FullScreenWindowLayout : WindowModeWindowLayout;



        private bool _isFullScreen = true;
        public bool IsFullScreen
        {
            get => _isFullScreen;
            set
            {
                _isFullScreen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFullScreen)));
            }
        }

        private int screenIndex = 0;
        public int ScreenIndex
        {
            get => screenIndex;
            set
            {
                screenIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScreenIndex)));
            }
        }
        
    }


}
