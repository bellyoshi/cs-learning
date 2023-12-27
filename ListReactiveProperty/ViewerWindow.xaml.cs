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
            //initializeComponentの前にDataContextを設定しなければWindowのサイズが変わらない
            DataContext ??= new ViewerViewModel(ImageSource);
            InitializeComponent();


        }


    }
}
