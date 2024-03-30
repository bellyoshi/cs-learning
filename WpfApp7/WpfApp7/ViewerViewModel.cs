using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp7
{
    internal class ViewerViewModel
    {


        public ReactiveCommand FullScreenCommand { get; } = new();
        public ReactiveCommand WindowModeCommand { get; } = new();
        public ReactiveCommand CloseDisplayCommand { get; } = new();




        public ViewerViewModel(WindowFullScreenManager setter)
        {
            // コマンドの初期化
            FullScreenCommand.Subscribe(_ => setter.IsFullScreen = true);
            WindowModeCommand.Subscribe(_ => setter.IsFullScreen = false);

        }





    }
}
