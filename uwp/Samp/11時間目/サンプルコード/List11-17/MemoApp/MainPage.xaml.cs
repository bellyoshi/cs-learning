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
using Windows.UI.Popups;
using Windows.ApplicationModel.DataTransfer;

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

        /// <summary>
        /// [開く]ボタン押下時の処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker();

            // 初期フォルダーを「ドキュメント」フォルダーにする
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            
            // サポートするファイルの種類を .txt にする
            filePicker.FileTypeFilter.Add(".txt");

            StorageFile file = await filePicker.PickSingleFileAsync();

            // [開く]ボタンが押された場合(fileがnull以外)の処理
            if (file != null)
            {
                // ファイルからテキストを読み込む
                try
                {
                    string text = await FileIO.ReadTextAsync(file);
                    txtMemo.Text = text;
                }
                catch (FileNotFoundException fnfe)
                {
                    // ファイルが見つからなかった場合
                    MessageDialog dlg = new MessageDialog(fnfe.Message, "エラー");
                    await dlg.ShowAsync();
                } 
            }
        }

        /// <summary>
        /// [コピー]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dtPkg = new DataPackage();

            // クリップボード操作をコピーにする
            dtPkg.RequestedOperation = DataPackageOperation.Copy;

            // txtMemoで選択されているテキストをクリップボードにセットする
            dtPkg.SetText(txtMemo.SelectedText);

            // クリップボードにデータをセットする
            Clipboard.SetContent(dtPkg);

            // 再度txtMemoにフォーカスを当てる
            txtMemo.Focus(FocusState.Programmatic);
         }

        /// <summary>
        /// [切り取り]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dtPkg = new DataPackage();
            int startPos = txtMemo.SelectionStart;
            int selectedLen = txtMemo.SelectionLength;

            // クリップボード操作をコピーにする
            dtPkg.RequestedOperation = DataPackageOperation.Move;

            // txtMemoで選択されているテキストをクリップボードにセットする
            dtPkg.SetText(txtMemo.SelectedText);

            // クリップボードにデータをセットする
            Clipboard.SetContent(dtPkg);

            // 選択された文字を切り取って新しい文字列を作成する
            string strNewMemo = txtMemo.Text.Substring(0, startPos) + txtMemo.Text.Substring(startPos + selectedLen);

            // 新しく作成した文字列をtxtMemoにセット
            txtMemo.Text = strNewMemo;

            // 選択開始位置にキャレットをセットする
            txtMemo.SelectionStart = startPos;
            
            // 再度txtMemoにフォーカスを当てる
            txtMemo.Focus(FocusState.Programmatic);
        }

        /// <summary>
        /// [貼り付け]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            // クリップボードからデータを取得する
            DataPackageView dtPkgView = Clipboard.GetContent();
            string strMemo = await dtPkgView.GetTextAsync();

            // 取得した文字をtxtMemoのキャレットの位置に挿入する
            txtMemo.Text= txtMemo.Text.Insert(txtMemo.SelectionStart, strMemo);

            // 再度txtMemoにフォーカスを当てる
            txtMemo.Focus(FocusState.Programmatic);
        }

        /// <summary>
        /// [新規作成]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.dlgConfirm.Content = "新規作成をすると現在の内容は消えてしまいます。\nよろしいですか？";
            var result = await this.dlgConfirm.ShowAsync();

            // 「はい」が押されたとき
            if (result == ContentDialogResult.Primary)
            {
                // 表示内容をクリアする
                txtMemo.Text = string.Empty;
            }

            // 再度txtMemoにフォーカスを当てる
            txtMemo.Focus(FocusState.Programmatic);
        }
    }
}
