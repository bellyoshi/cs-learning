using System.Windows;
namespace WpfApp12;


    public partial class ViewerWindow : Window
    {
        public ViewerWindow(MediaStateViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewerMediaElement.Source = new Uri(
                @"C:\Users\catik\OneDrive\www\video\hanatokingdom.mp4", UriKind.Relative);
        }
    }


