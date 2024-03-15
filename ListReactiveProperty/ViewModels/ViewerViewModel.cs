using ListReactiveProperty.Models;
using ListReactiveProperty.Utils;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace ListReactiveProperty.ViewModels
{
    internal class ViewerViewModel
    {
        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource?> ImageSource { get; }







        public ReactiveCommand FullScreenCommand { get;  } = new();
        public ReactiveCommand WindowModeCommand { get; } = new();
        public ReactiveCommand CloseDisplayCommand { get; } = new();



        public ReactiveProperty<string> Text { get; } = new();

        public ViewerViewModel(WindowFullScreenManager setter)
        {
            // コマンドの初期化
            FullScreenCommand.Subscribe(_ => setter.IsFullScreen = true);
            WindowModeCommand.Subscribe(_ => setter.IsFullScreen = false);

        
            var thatModel = DisplayModel.GetInstance();
            ImageSource = thatModel.ToReactivePropertyAsSynchronized(x => x.DisplayImage);

            var screenModel = ScreenModel.GetInstance();
            
            //var isFullscreen = screenModel.ToReactivePropertyAsSynchronized(x => x.IsFullScreen).
            //    Subscribe(_=> SetScreenSize());



            CloseDisplayCommand.Subscribe(_ => ExecuteCloseDisplay());
        }







        private void ExecuteCloseDisplay()
        {
            Utils.WindowDispacher.CloseWindow<ViewerWindow>();

        }
    }
}
