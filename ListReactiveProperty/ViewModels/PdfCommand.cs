using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.ViewModels
{
    internal class PdfCommand(ReactiveProperty<FileViewParam> selectedFile)
    {
        public ReactiveProperty<FileViewParam> SelectedFile { get; } = selectedFile;

        private PdfFileViewParam? Pdffile => SelectedFile.Value as PdfFileViewParam;

        // 「最初のページ」への移動処理
        internal void ExecuteFirstPage() => Pdffile?.FirstPage();

        // 「次のページ」への移動処理
        internal void ExecuteNextPage() => Pdffile?.NextPage();

        // 「前のページ」への移動処理
        internal void ExecutePreviousPage() => Pdffile?.PrevPage();



        // 「最後のページ」への移動処理
        internal void ExecuteLastPage() => Pdffile?.LastPage();


        internal void ExecuteSpecifyPage()
        {
            // 「ページ指定」の処理
            //pdffile?.GoToPage(page)
        }
    }
}
