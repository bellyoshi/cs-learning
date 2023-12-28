using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ListReactiveProperty
{
    internal class ViewerViewModel
    {
        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource { get; }

        public ReactiveProperty<double> WindowTop { get; } = new();
        public ReactiveProperty<double> WindowLeft { get; } = new();
        public ReactiveProperty<double> WindowWidth { get; } = new();
        public ReactiveProperty<double> WindowHeight { get; } = new();



        public ReactiveProperty<String > Text { get; } = new();

        public ViewerViewModel(ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource)
        {
            this.ImageSource = ImageSource;

            Screen viewscreen = GetViewScreen();
            var monitorArea = viewscreen.WorkingArea;

            WindowTop.Value = monitorArea.Top;
            WindowLeft.Value = monitorArea.Left;
            WindowWidth.Value = monitorArea.Width;
            WindowHeight.Value = monitorArea.Height;
            //var screenWidth = SystemParameters.WorkArea.Width;
            //var screenHeight = SystemParameters.WorkArea.Height;
            //WindowWidth.Value = screenWidth;
            //WindowHeight.Value = screenHeight;
        }

        private static Screen GetViewScreen()
        {
            var screens = System.Windows.Forms.Screen.AllScreens;
            var viewscreen = screens[0];
            foreach (var screen in screens)
            {
                if (screen.Primary) continue;
                viewscreen = screen;
                break;
            }

            return viewscreen;
        }
    }
}
