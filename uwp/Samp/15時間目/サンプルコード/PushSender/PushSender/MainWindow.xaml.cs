using System.Windows;

// 追加
using Microsoft.Azure.NotificationHubs;

namespace PushSender
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnMsg_Click(object sender, RoutedEventArgs e)
        {
            // プッシュ通知メッセージの作成
            string toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                txtMsg.Text + " " + System.DateTime.Now.ToString() +
                "</text></binding></visual></toast>";

            var hub = NotificationHubClient.CreateClientFromConnectionString(
                "メモしておいたCONNECTION STRING"",
                "PushNotyfyService");

            // トースト通知の送信
            await hub.SendWindowsNativeNotificationAsync(toast);
        }
    }
}
