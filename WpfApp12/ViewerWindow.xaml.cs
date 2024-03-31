using System.Windows;
namespace WpfApp12;


    public partial class ViewerWindow : Window
    {
    private bool hasMediaLength = false;
        public ViewerWindow(MediaStateViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewerMediaElement.Source = new Uri(
                @"C:\Users\catik\OneDrive\www\video\hanatokingdom.mp4", UriKind.Relative);

        // ViewModelのMediaPositionの変更を購読し、MediaElementの位置を更新します。
        viewModel.MediaPosition.Subscribe(position =>
        {
            if(viewerMediaElement.NaturalDuration.HasTimeSpan && !hasMediaLength)
            {
                viewModel.MediaLength.Value = viewerMediaElement.NaturalDuration.TimeSpan;
                hasMediaLength = true;
            }

            // UIスレッドでMediaElementのPositionを更新する必要があります。
            Dispatcher.Invoke(() =>
            {
                viewerMediaElement.Position = position; ;
            });
        });
    }
    }


