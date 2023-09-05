using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyFirstApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnSayHello_Click(object sender, RoutedEventArgs e)
        {
            string msg = string.Empty;
            var now = DateTime.Now;     // 現在時刻を取得
            var date1 = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            var date2 = new DateTime(now.Year, now.Month, now.Day, 4, 0, 0);
            var date3 = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);
            var date4 = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);

            if ((now >= date1 && now < date2) || now > date4)
            {
                msg = "こんばんは";
            }
            else if(now >= date2 && now < date3)
            {
                msg = "おはよう";
            }
            else if (now >= date3 && now < date4)
            {
                msg = "こんにちは";
            }

            txbMessage.Text = msg;
        }
    }
}
