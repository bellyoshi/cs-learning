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
        public ReactiveProperty<double> DpiScaleX { get; } = new(1.00);

        public ReactiveProperty<double> DpiScaleY { get; } = new(1.00);

        public ReactiveProperty<int> WindowTop { get; } = new(0);
        public ReactiveProperty<int> WindowLeft { get; } = new(0);
        public ReactiveProperty<int> WindowHeight { get; set; } = new(640);
        public ReactiveProperty<int> WindowWidth { get; set; } = new(480);


        public ReactiveProperty<int> WindowMinHeight { get; set; } = new(0);
        public ReactiveProperty<int> WindowMinWidth { get; set; } = new(0);


        public ReactiveCommand FullScreenCommand { get; } = new();
        public ReactiveCommand WindowModeCommand { get; } = new();
        public ReactiveCommand CloseDisplayCommand { get; } = new();

        public ViewerViewModel()
        {
            // コマンドの初期化
            FullScreenCommand.Subscribe(_ => ExecuteFullScreen());
            WindowModeCommand.Subscribe(_ => ExecuteWindowMode());

        }

        public int BakupHeight { get; set; }
        public int BakupWidth { get; set; }

        public int BackupTop { get; set; }
        public int BackupLeft { get; set; }

        private bool _IsFullScreen;
        public bool IsFullScreen{
            get => _IsFullScreen;
            set
            {
                if (value)
                {

                    SetFullScreen();
                }
                else
                {

                    SetNormalScreen();
                }
            }
        }

        void SetFullScreen()
        {
            // Set the window to full screen
            if (!_IsFullScreen)
            {
                this.BakupHeight = WindowHeight.Value;
                this.BakupWidth = WindowWidth.Value;
                this.BackupLeft = WindowLeft.Value;
                this.BackupTop = WindowTop.Value;
                
            }
            ScreenModel screenModel = ScreenModel.GetInstance();

            WindowTop.Value = screenModel.FullScreenWindowLayout.Top;
            WindowLeft.Value = screenModel.FullScreenWindowLayout.Left;

            WindowWidth.Value = screenModel.FullScreenWindowLayout.Width;
            WindowHeight.Value = screenModel.FullScreenWindowLayout.Height;
            WindowMinWidth.Value = screenModel.FullScreenWindowLayout.Width;
            WindowMinHeight.Value = screenModel.FullScreenWindowLayout.Height;

            _IsFullScreen = true;
        }

        void SetNormalScreen()
        {
            if (_IsFullScreen)
            {
                WindowHeight.Value = this.BakupHeight;
                WindowWidth.Value = this.BakupWidth;
                WindowTop.Value = this.BackupTop;   
                WindowLeft.Value = this.BackupLeft;
            }
            WindowMinWidth.Value =0;
            WindowMinHeight.Value =0;

            // Set the window to normal screen
            _IsFullScreen = false;
        }
        private void ExecuteFullScreen()
        {
            IsFullScreen = true;

        }

        private void ExecuteWindowMode()
        {
            IsFullScreen = false;

        }


    }
}
