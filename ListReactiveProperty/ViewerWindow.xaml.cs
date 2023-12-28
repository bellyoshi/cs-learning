using Reactive.Bindings;
using System.Windows;
using System.Windows.Media;

namespace ListReactiveProperty
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewerWindow : Window
    {
        public ViewerWindow(ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource)
        {

            InitializeComponent();
            DataContext ??= new ViewerViewModel(ImageSource);
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // このウィンドウに対応するDPI情報を取得
            var dpiInfo = VisualTreeHelper.GetDpi(this);

            // 横方向のDPI
            var dpiX = dpiInfo.DpiScaleX * 96;

            // 縦方向のDPI
            var dpiY = dpiInfo.DpiScaleY * 96;

            // DPI情報を表示（デバッグ用）
            MessageBox.Show($"DPI X: {dpiX}, DPI Y: {dpiY}");
        }
    }


}

