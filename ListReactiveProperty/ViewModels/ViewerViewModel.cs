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

        public ReactiveProperty<int> WindowTop { get; } = new();
        public ReactiveProperty<int> WindowLeft { get; } = new();
        public ReactiveProperty<int> WindowWidth { get; } = new();
        public ReactiveProperty<int> WindowHeight { get; } = new();



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

        public ReactiveCommand FullScreenCommand { get;  } = new();
        public ReactiveCommand WindowModeCommand { get; } = new();
        public ReactiveCommand CloseDisplayCommand { get; } = new();



        public ReactiveProperty<string> Text { get; } = new();

        public ViewerViewModel()
        {
            var thatModel = ThatModel.GetInstance();
            ImageSource = thatModel.ToReactivePropertyAsSynchronized(x => x.ImageSource);

            var screenModel = ScreenModel.GetInstance();
            
            var isFullscreen = screenModel.ToReactivePropertyAsSynchronized(x => x.IsFullScreen).
                Subscribe(_=> SetScreenSize());


            VirtualWidth = WindowWidth.CombineLatest(DpiScaleX, (w, dpi) => w / dpi).ToReactiveProperty();
            VirtualHeight = WindowHeight.CombineLatest(DpiScaleY, (h, dpi) => h / dpi).ToReactiveProperty();

            VirtualWidth.Subscribe(_=>
                System.Diagnostics.Debug.WriteLine(VirtualWidth.Value));

            

            // コマンドの初期化
            FullScreenCommand.Subscribe(_ => ExecuteFullScreen());
            WindowModeCommand.Subscribe(_ => ExecuteWindowMode());
            CloseDisplayCommand.Subscribe(_ => ExecuteCloseDisplay());
        }

        private void SetScreenSize()
        {
            var screenModel = ScreenModel.GetInstance();
            var windowLayout = screenModel.WindowLayout;

            WindowTop.Value = windowLayout.Top;
            WindowLeft.Value = windowLayout.Left;
            WindowWidth.Value =  windowLayout.Width;
            WindowHeight.Value = windowLayout.Height;
        }



        private void ExecuteFullScreen()
        {
            // フルスクリーンモードへの切り替え処理
            var screenModel = ScreenModel.GetInstance();
            screenModel.IsFullScreen = true;

        }

        private void ExecuteWindowMode()
        {
            // ウィンドウモードへの切り替え処理
            var screenModel = ScreenModel.GetInstance();
            screenModel.IsFullScreen = false;

        }

        private void ExecuteCloseDisplay()
        {
            Utils.WindowDispacher.CloseWindow<ViewerWindow>();

        }
    }
}
