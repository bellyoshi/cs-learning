﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace viewerproto
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ViewerPage : Page
    {
        public ViewerPage()
        {
            this.InitializeComponent();
            Handle = this;
        }
        private PdfDocument doc;
        private PdfPage page;
        private uint pageIndex;

        public static ViewerPage Handle { get; private set; }

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await GetFile();
            if (file == null) return;

            doc = await PdfDocument.LoadFromFileAsync(file);
            pageIndex = 0;

            await DispPage();
        }

        private async Task DispPage()
        {
            page = doc.GetPage(pageIndex);
            // ビットマップイメージの作成
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await page.RenderToStreamAsync(stream);
            BitmapImage src = new BitmapImage();

            // Imageオブジェクトにsrcをセット
            imgPdf.Source = src;

            // srcに作成したビットマップイメージを流し込む
            await src.SetSourceAsync(stream);
        }

        private static async Task<StorageFile> GetFile()
        {
            var openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            openPicker.FileTypeFilter.Add(".pdf");
            IAsyncOperation<StorageFile> asyncOp = openPicker.PickSingleFileAsync();
            StorageFile file = await asyncOp;
            return file;
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (doc.PageCount <= pageIndex + 1)
                return;

            pageIndex++;
            await DispPage();

        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex <= 0) return;
            pageIndex--;
            await DispPage();
        }
    }
}
