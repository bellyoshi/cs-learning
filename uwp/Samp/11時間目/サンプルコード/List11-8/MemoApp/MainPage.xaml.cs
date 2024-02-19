using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MemoApp
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

        /// <summary>
        /// [保存]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileSavePicker();

            // 初期フォルダーを「ドキュメント」フォルダーにする
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

            // 既定の拡張子を .txt にする
            filePicker.DefaultFileExtension = ".txt";

            // サポートするファイルの種類を .txt にする
            filePicker.FileTypeChoices.Add("テキスト", new List<string>() { ".txt" });

            // ファイル名の候補を「新規メモ」にする
            filePicker.SuggestedFileName = "新規メモ";

            StorageFile file = await filePicker.PickSaveFileAsync();

            // [保存]ボタンが押された場合(fileがnull以外)の処理
            if (file != null)
            {
                // txtMemo.Textの内容をファイルに保存する
                await FileIO.WriteTextAsync(file, txtMemo.Text);
            }
        }
    }
}
