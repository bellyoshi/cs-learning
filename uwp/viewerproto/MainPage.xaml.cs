using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace viewerproto
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ApplicationView _subWindowApplicationView;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            if (_subWindowApplicationView == null)
            {
                // まだ子 Window が無かったら作る
                await CoreApplication.CreateNewView().Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    _subWindowApplicationView = ApplicationView.GetForCurrentView();
                    Window.Current.Content = new ViewerPage();
                    Window.Current.Activate();
                });
            }

            // サブディスプレイに全画面表示させる
            await ProjectionManager.StartProjectingAsync(_subWindowApplicationView.Id, ApplicationView.GetForCurrentView().Id);
        }
    }
    
}
