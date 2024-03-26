using ListReactiveProperty.Models;
using ListReactiveProperty.Utils;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ListReactiveProperty.ViewModels
{
    internal class ViewerViewModel
    {
        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource?> ImageSource { get; }







        public ReactiveCommand FullScreenCommand { get;  } = new();
        public ReactiveCommand WindowModeCommand { get; } = new();
        public ReactiveCommand CloseDisplayCommand { get; } = new();

        public ReactiveProperty<Brush> Background { get; } = new();



        public ReactiveProperty<string> Text { get; } = new();

        public void SetWindowFullScreenManager(WindowFullScreenManager value) { 
                // コマンドの初期化
            FullScreenCommand.Subscribe(_ => value.IsFullScreen = true);
            WindowModeCommand.Subscribe(_ => value.IsFullScreen = false);
            
        }

        public ViewerViewModel()
        {


        
            var displayModel = DisplayModel.GetInstance();
            ImageSource = displayModel.ToReactivePropertyAsSynchronized(x => x.DisplayImage);
            Background = displayModel.ToReactivePropertyAsSynchronized(x => x.BackColor);

            var screenModel = ScreenModel.GetInstance();
            
            //var isFullscreen = screenModel.ToReactivePropertyAsSynchronized(x => x.IsFullScreen).
            //    Subscribe(_=> SetScreenSize());



            CloseDisplayCommand.Subscribe(_ => ExecuteCloseDisplay());
        }







        private void ExecuteCloseDisplay()
        {
            //todo:close behavior Utils.WindowDispacher.CloseWindow<ViewerWindow>();

        }
    }
}
