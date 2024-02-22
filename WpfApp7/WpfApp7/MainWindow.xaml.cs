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

namespace WpfApp7
{
    interface BoundSetter
    {
        void SetWindowBound(int top, int left, int height, int width);
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, BoundSetter
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewerViewModel(this);
            this.WindowStyle = WindowStyle.None;
            
            this.ResizeMode = ResizeMode.NoResize;
            WindowDragMover mover = new WindowDragMover(this, 10, new UIElement[] { this });
            WindowDragResizer resize = new WindowDragResizer(this, 10);
        }

        public void SetWindowBound(int top, int left, int height, int width)
        {
            this.Top = top;
            this.Left = left;
            this.Height = height;
            this.Width = width;
        }
    }
}