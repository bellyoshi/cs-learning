using ListReactiveProperty.ViewModels;
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

        public ViewerWindow()
        {

            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

            FullScreenMode();

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var _viewModel = DataContext as ViewerViewModel;
            Debug.Assert(_viewModel != null);
            // このウィンドウに対応するDPI情報を取得
            var dpiInfo = VisualTreeHelper.GetDpi(this);

            _viewModel.SetDpiScale(dpiInfo.DpiScaleX, dpiInfo.DpiScaleY);



            //ウインドウがDPIの違うモニタ―を移動することは考慮していない。


        }

        private void FullScreenMode()
        {
            // タイトルバーと境界線を表示しない
            this.WindowStyle = WindowStyle.None;
        }
    }


}

