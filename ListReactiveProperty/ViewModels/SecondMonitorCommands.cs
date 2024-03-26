using ListReactiveProperty.Models;
using ListReactiveProperty.Utils;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.Windows.Media.Imaging;


namespace ListReactiveProperty.ViewModels
{
    internal class SecondMonitorCommands
    {
        private static ReactiveProperty<bool> CanEnd { get; } = new ReactiveProperty<bool>(false);
        private static ReactiveProperty<bool> CanShow { get; } = new ReactiveProperty<bool>(true);

        private ReactiveProperty<BitmapSource?> PreviewImage { get; }

        private ReactiveProperty<BitmapSource?> DisplayImage { get; }

        static private ReactiveProperty<bool> IsAutoDisplayEnabled { get; set; } = new(false);

        public SecondMonitorCommands(ReactiveProperty<BitmapSource?> previewImage
            ,ReactiveProperty<BitmapSource?> displayImage)
        {
            PreviewImage = previewImage;
            DisplayImage = displayImage;
            DisplayModel display = DisplayModel.GetInstance();
            IsAutoDisplayEnabled = display.ToReactivePropertyAsSynchronized(x => x.IsAutoDisplayEnabled);

            PreviewImage.Subscribe(file =>
            {
                if (IsAutoDisplayEnabled.Value) ExecuteShowOnSecondMonitor();
            });



            IsAutoDisplayEnabled.Subscribe(enabled => {
                if (enabled) ExecuteShowOnSecondMonitor();
                SetFlag();
            });
        }

        private static bool isOpenSecondMonitor = false;
        public static void SetIsOpenSecondMonitor(bool isOpenSecondMonitor)
        {
            SecondMonitorCommands.isOpenSecondMonitor = isOpenSecondMonitor;
            SetFlag();
        }
        private static void SetFlag()
        {
            CanEnd.Value = isOpenSecondMonitor;
            CanShow.Value = !isOpenSecondMonitor || !IsAutoDisplayEnabled.Value;
        }
        // セカンドモニター操作
        public ReactiveCommand CreateShowOnSecondMonitorCommand()
        {
            var command = CanShow.ToReactiveCommand();
            command.Subscribe(_ => ExecuteShowOnSecondMonitor());
            return command;
        }
        public ReactiveCommand CreateEndShowOnSecondMonitorCommand()
        {
            var command = CanEnd.ToReactiveCommand();
            command.Subscribe(_ => ExecuteEndShowOnSecondMonitor());
            return command;

        }
        public ReactiveCommand CreateShowBackgroundOnSecondMonitorCommand()
        {
            ReactiveCommand command = new();
            command.Subscribe(_ => ExecuteShowBackgroundOnSecondMonitor());
            return command;
        }

        private void ExecuteShowOnSecondMonitor()
        {
            OpenNewWindow();
        }

        private void ExecuteEndShowOnSecondMonitor()
        {

        }

        private void ExecuteShowBackgroundOnSecondMonitor()
        {
            // 「セカンドモニターでの背景表示」の処理
        }
        private void OpenNewWindow()
        {
            DisplayImage.Value = PreviewImage.Value;

        }
    }
}
