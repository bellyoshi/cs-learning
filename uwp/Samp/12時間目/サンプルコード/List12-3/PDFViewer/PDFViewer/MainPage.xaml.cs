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

namespace PDFViewer
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

        private async void btnOpenPdf_Click(object sender, RoutedEventArgs e)
        {
            // PDFファイルを開くためのピッカーを準備
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".pdf");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            Windows.Data.Pdf.PdfDocument pdfDocument = null;

            if (file != null)
            {
                try
                {
                    // PDFファイルを読み込む
                    pdfDocument = await Windows.Data.Pdf.PdfDocument.LoadFromFileAsync(file);
                }
                catch
                {

                }
            }

            if (pdfDocument != null)
            {
                // 1ページ目を読み込む
                using (Windows.Data.Pdf.PdfPage page = pdfDocument.GetPage(0))
                {
                    // ビットマップイメージの作成
                    var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
                    await page.RenderToStreamAsync(stream);
                    Windows.UI.Xaml.Media.Imaging.BitmapImage src = new Windows.UI.Xaml.Media.Imaging.BitmapImage();

                    // Imageオブジェクトにsrcをセット
                    imgPdf.Source = src;

                    // srcに作成したビットマップイメージを流し込む
                    await src.SetSourceAsync(stream);
                }
            }
        }
    }
}
