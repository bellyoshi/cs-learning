using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty
{
    internal class ViewerViewModel
    {
        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource { get; }

        public ReactiveProperty<int> WindowTop { get; } = new();
        public ReactiveProperty<int> WindowLeft { get; } = new();
        public ReactiveProperty<int> WindowWidth { get; } = new();
        public ReactiveProperty<int> WindowHeight { get; } = new();

        public ViewerViewModel(ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource)
        {
            this.ImageSource = ImageSource;
            var monitors = MonitorInfo.GetMonitors();
            var monitor = monitors[0];
            WindowTop.Value = monitor.MonitorArea.Top;
            WindowLeft.Value = monitor.MonitorArea.Left;
            WindowWidth.Value = monitor.MonitorArea.Right - monitor.MonitorArea.Left;
            WindowHeight.Value = monitor.MonitorArea.Bottom - monitor.MonitorArea.Top;
        }

    }
}
