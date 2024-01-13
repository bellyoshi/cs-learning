using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.ViewModels
{
    internal class PdfCommand
    {
        public ReactiveProperty<FileViewParam> SelectedFile { get; }

        public PdfCommand(ReactiveProperty<FileViewParam> selectedFile)
        {
            SelectedFile = selectedFile;
        }

        private PdfFileViewParam? pdffile => SelectedFile.Value as PdfFileViewParam;

        // 「最初のページ」への移動処理
        internal void ExecuteFirstPage() => pdffile?.FirstPage();

        // 「次のページ」への移動処理
        internal void ExecuteNextPage() => pdffile?.NextPage();

        // 「前のページ」への移動処理
        internal void ExecutePreviousPage() => pdffile?.PrevPage();



        // 「最後のページ」への移動処理
        internal void ExecuteLastPage() => pdffile?.LastPage();


        internal void ExecuteSpecifyPage()
        {
            // 「ページ指定」の処理
            //pdffile?.GoToPage(page)
        }
    }
}
