namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        protected ViewModel ViewModel { get; private set; } = new ViewModel();
        public Form1()
        {

            InitializeComponent();
            label1.Bind(() => ViewModel.Counter.Value);
            label2.Bind(() => ViewModel.Counter.Value);
            button1.Bind(ViewModel.UpCommand);
            button3.Bind(ViewModel.MessageCommand);
            button2.Bind(ViewModel.DownCommand);
        }
    }
}