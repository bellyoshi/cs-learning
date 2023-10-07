namespace UiEntry;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }


    private void OnClickCommit(object sender, EventArgs e)
    {
        string name = NameText.Text;
        string address = AddressText.Text;
        MessageLabel.Text = $"{name} in {address} ";

    }
}