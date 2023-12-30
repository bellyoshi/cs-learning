using Reactive.Bindings;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace ListReactiveProperty
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewerWindow : Window
    {
        private readonly ViewerViewModel _viewModel;

        public ViewerWindow(ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource)
        {

            InitializeComponent();
            _viewModel = new ViewerViewModel(ImageSource);
            DataContext ??= _viewModel;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // このウィンドウに対応するDPI情報を取得
            var dpiInfo = VisualTreeHelper.GetDpi(this);

            _viewModel.DpiScaleX.Value = dpiInfo.DpiScaleX;
            _viewModel.DpiScaleX.Value = dpiInfo.DpiScaleY;


            //ウインドウがDPIの違うモニタ―を移動することは考慮していない。


        }
    }


}

