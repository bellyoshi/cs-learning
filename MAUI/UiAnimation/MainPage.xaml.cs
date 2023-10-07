namespace UiAnimation
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await ImageNet.RotateTo(360, 2000);
            ImageNet.Rotation = 0;
        }
    }
}