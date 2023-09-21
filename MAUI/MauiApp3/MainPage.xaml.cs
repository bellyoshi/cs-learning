using Microsoft.Maui.Devices;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            Message.Text = "わははのは！";
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
            Window secondWindow = new (new MyPage())
            {
                Width = displayInfo.Width,
                Height = displayInfo.Height,
                X = 0,
                Y = 0
            };
            Application.Current.OpenWindow(secondWindow);
            // Center the window
            // Get display size


        }

        private void OnDateTimeClicked(object sender, EventArgs e)
        {
            Message.Text = DateTime.Now.ToString();
        }
    }
}