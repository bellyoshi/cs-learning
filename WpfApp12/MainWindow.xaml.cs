using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MediaStateViewModel viewModel = new MediaStateViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.IsMediaPlaying.Value = true;
            mediaElement.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.IsMediaPlaying.Value = false;
            mediaElement.Pause();
        }

        private void OpenViewer_Click(object sender, RoutedEventArgs e)
        {
            var viewerWindow = new ViewerWindow(viewModel);
            viewerWindow.Show();
            mediaElement.Source =  new Uri(
               @"C:\Users\catik\OneDrive\www\video\hanatokingdom.mp4", UriKind.Relative);
        }
    }

    }
