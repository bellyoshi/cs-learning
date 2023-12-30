using ListReactiveProperty.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace ListReactiveProperty.ViewModels
{
    internal class ViewerViewModel
    {
        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource?> ImageSource { get; }

        public ReactiveProperty<double> WindowTop { get; } = new();
        public ReactiveProperty<double> WindowLeft { get; } = new();
        public ReactiveProperty<double> WindowWidth { get; } = new();
        public ReactiveProperty<double> WindowHeight { get; } = new();



        public ReactiveProperty<double> DpiScaleX { get; } = new(1.00);

        public ReactiveProperty<double> DpiScaleY { get; } = new(1.00);

        public void SetDpiScale(double x, double y)
        {
            DpiScaleX.Value = x;
            DpiScaleY.Value = y;
        }

        //virtual width and height WindowWidth * DpiScaleX
        public ReactiveProperty<double> VirtualWidth { get; } = new();
        public ReactiveProperty<double> VirtualHeight { get; } = new();




        public ReactiveProperty<string> Text { get; } = new();

        public ViewerViewModel()
        {
            var thatModel = ThatModel.GetInstance();
            ImageSource = thatModel.ToReactivePropertyAsSynchronized(x => x.ImageSource);
            ImageSource = ImageSource;



            VirtualWidth = WindowWidth.CombineLatest(DpiScaleX, (w, dpi) => w / dpi).ToReactiveProperty();
            VirtualHeight = WindowHeight.CombineLatest(DpiScaleY, (h, dpi) => h / dpi).ToReactiveProperty();

            SetScreenSize();
        }

        private void SetScreenSize()
        {
            Screen viewscreen = GetViewScreen();
            var monitorArea = viewscreen.WorkingArea;

            WindowTop.Value = monitorArea.Top;
            WindowLeft.Value = monitorArea.Left;
            WindowWidth.Value = monitorArea.Width * DpiScaleX.Value;
            WindowHeight.Value = monitorArea.Height * DpiScaleY.Value;
        }

        private static Screen GetViewScreen()
        {
            var screens = Screen.AllScreens;
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
