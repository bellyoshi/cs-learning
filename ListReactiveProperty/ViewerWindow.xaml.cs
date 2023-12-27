using Reactive.Bindings;
using System.Windows;

namespace ListReactiveProperty
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewerWindow : Window
    {
        public ViewerWindow(ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource)
        {
            DataContext ??= new ViewerViewModel(ImageSource);
            InitializeComponent();

            //PositionWindowOnSecondaryMonitor();
        }

        //private void PositionWindowOnSecondaryMonitor()
        //{
        //    var monitors = MonitorInfo.GetMonitors();
        //    var secondaryMonitor = monitors[0]; 
        //    if (monitors.Count > 1)
        //    {
        //        secondaryMonitor = monitors[1]; // 例として2番目のモニターを選択

        //    }
        //    this.Left = secondaryMonitor.WorkArea.Left;
        //    this.Top = secondaryMonitor.WorkArea.Top;

        //}
    }
}
