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

using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

//追加
using Windows.Storage.AccessCache;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace PDFViewer
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public const string APP_NAME = "PDF Viewer";

        // PdfDocument管理用フィールド
        private Windows.Data.Pdf.PdfDocument _pdfDocument = null;
        // 表示中のページ番号管理用フィールド
        private uint _pageIndex = 0;
        // ページ数管理用フィールド
        private uint _pageCount = 0;

        public MainPage()
        {
            this.InitializeComponent();

            ShowRecentlyFiles();
        }

        /// <summary>
        /// [PDFファイルを開く]ボタンクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOpenPdf_Click(object sender, RoutedEventArgs e)
        {
            // PDFファイルを開くためのピッカーを準備
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".pdf");
            StorageFile file = await picker.PickSingleFileAsync();
            
            if (file != null)
            {
                try
                {
                    // 現在表示しているPDFを破棄する
                    imgPdf.Source = null;

                     // 表示するページ番号の設定
                    _pageIndex = 0;

                    // PDFファイルを読み込む
                    _pdfDocument = await PdfDocument.LoadFromFileAsync(file);

                    // 最近使用したファイル一覧を管理するプロパティの準備
                    var mru = StorageApplicationPermissions.MostRecentlyUsedList;

                    // 最近使用したファイル一覧へファイルの登録
                    mru.Add(file, file.Name);

                    // 最近使用したファイル一覧の表示
                    ShowRecentlyFiles();

                    // ページカウントを取得
                    _pageCount = _pdfDocument.PageCount;

                    // ページ数が1ページ以下の場合
                    if (_pageCount <= 1)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }

                    ShowPdf();
                }
                catch (Exception ex)
                {
                    Windows.UI.Popups.MessageDialog dlgMsg = new MessageDialog(ex.Message, "エラー");
                    // エラーが発生した場合は PDF表示領域を非表示にする
                    grdPdf.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// PDFファイルを表示する
        /// </summary>
        private async void ShowPdf()
        {
            if (_pdfDocument != null)
            {
                // PDF表示領域を表示する
                grdPdf.Visibility = Visibility.Visible;

                // 読み込み中を示す ProgressRing を表示する
                progressRing.Visibility = Visibility.Visible;

                // PDFページを読み込む
                using (PdfPage page = _pdfDocument.GetPage(_pageIndex))
                {
                    // 描画データ書き込み用のストリームを作成
                    var stream = new InMemoryRandomAccessStream();

                    await page.RenderToStreamAsync(stream);
                    BitmapImage src = new BitmapImage();

                    // PDFをImageコントロール内に収まるようにする
                    imgPdf.Stretch = Stretch.Fill;

                    // Imageオブジェクトにsrcをセット
                    imgPdf.Source = src;

                    // srcに作成したビットマップイメージを流し込む
                    await src.SetSourceAsync(stream);
                }

                // 読み込み中を示す ProgressRing を非表示にする
                progressRing.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// [<前へ]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            // 先頭のページ以降の場合
            if (_pageIndex > 0 )
            {
                _pageIndex--;
                btnNext.IsEnabled = true;
            } 

            // 現在のページが先頭ページの場合
            if (_pageIndex == 0)
            {
                btnPrev.IsEnabled = false;
            }

            ShowPdf();
        }

        /// <summary>
        /// [次へ>]ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // 最終ページ未満の場合
            if (_pageIndex < (_pageCount - 1))
            {
                _pageIndex++;
            }

            // 最終ページの場合
            if (_pageIndex == (_pageCount - 1))
            {
                btnNext.IsEnabled = false;
            }

            // 現在のページが2ページ以降の場合
            if (_pageIndex > 0)
            {
                btnPrev.IsEnabled = true;
            }

            ShowPdf();
        }

        /// <summary>
        /// 最近使ったファイルをListBoxに表示する
        /// </summary>
        private void ShowRecentlyFiles()
        {
            // 最近使ったファイルの一覧からファイル名とトークンを取得する
            AccessListEntryView mruView = StorageApplicationPermissions.MostRecentlyUsedList.Entries;
            var list = mruView.Select(entry => new { FileName = entry.Metadata, Token = entry.Token });

            // 取得したファイル名とトークンをListBoxにセットするする
            lstFile.ItemsSource = list;
            lstFile.DisplayMemberPath = "FileName";
            lstFile.SelectedValuePath = "Token";
        }

        /// <summary>
        ///  最近使ったファイル一覧でファイルが選択された場合の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lstFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var token = ((sender as ListBox).SelectedValue).ToString();
 
            StorageFile file
              = await StorageApplicationPermissions.MostRecentlyUsedList.GetFileAsync(token);

            // PDFファイルを読み込む
            _pdfDocument = await PdfDocument.LoadFromFileAsync(file);

            _pageCount = _pdfDocument.PageCount;
            _pageIndex = 0;

            ShowPdf();
        }
    }

}
