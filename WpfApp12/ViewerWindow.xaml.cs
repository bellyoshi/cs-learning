using System.Windows;
namespace WpfApp12;


    public partial class ViewerWindow : Window
    {
        public ViewerWindow(MediaStateViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewModel.IsMediaPlaying.Subscribe(isPlaying =>
            {
                if (isPlaying) viewerMediaElement.Play();
                else viewerMediaElement.Pause();
            });

            // MainWindowからメディアソースのパスを直接取得するか、
            // ViewModelを介してソースを設定するロジックを追加
            viewerMediaElement.Source = new Uri(
                @"C:\Users\catik\OneDrive\www\video\hanatokingdom.mp4", UriKind.Relative);
        }
    }


