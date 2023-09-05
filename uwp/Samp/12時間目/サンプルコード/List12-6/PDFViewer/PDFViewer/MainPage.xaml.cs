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

//追加
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace PDFViewer
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // PdfDocument管理用フィールド
        private Windows.Data.Pdf.PdfDocument _pdfDocument = null;
        // 表示中のページ番号管理用フィールド
        private uint _pageIndex = 0;

        public MainPage()
        {
            this.InitializeComponent();
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
    }
}
