namespace MVVM2;

public partial class Form1 : Form
{
    protected ViewModel ViewModel { get; private set; } = new ViewModel();

    public Form1()
    {
        InitializeComponent();
        label1.Bind(() => ViewModel.Counter);
        button1.Bind(ViewModel.UpCommand);
        button2.Bind(ViewModel.DownCommand);
    }
}