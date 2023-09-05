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

namespace List10_5
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

        // C# 選択時
        private void rdoCs_Checked(object sender, RoutedEventArgs e)
        {
            ShowLanguage(rdoCs.Content.ToString());
        }

        // Visual Basic 選択時
        private void rdoVb_Checked(object sender, RoutedEventArgs e)
        {
            ShowLanguage(rdoVb.Content.ToString());
        }

        // C++ 選択時
        private void rdoCpp_Checked(object sender, RoutedEventArgs e)
        {
            ShowLanguage(rdoCpp.Content.ToString());
        }

        /// <summary>
        /// 選択された言語を表示する
        /// </summary>
        /// <param name="strLang">表示する言語</param>
        private void ShowLanguage(string strLang)
        {
            txbSelectedLang.Text = $"選択した言語は {strLang} ですね";
        }
    }
}
