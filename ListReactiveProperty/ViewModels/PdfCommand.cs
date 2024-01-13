using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.ViewModels
{
    internal class PdfCommand 
    {
        public PdfCommand(ReactiveProperty<FileViewParam> selectedFile)
        {
            SelectedFile = selectedFile;
            SelectedFile.Subscribe(_ => SetFlag());
        }
        private ReactiveProperty<FileViewParam> SelectedFile { get; } 



        public ReactiveProperty<bool> CanNext { get; } = new ReactiveProperty<bool>(false);

        public ReactiveProperty<bool> CanPrev { get; } = new ReactiveProperty<bool>(false);
        private PdfFileViewParam? Pdffile => SelectedFile.Value as PdfFileViewParam;

        private void SetFlag()
        {
            CanNext.Value = Pdffile?.CanNextPage??false;
            CanPrev.Value = Pdffile?.CanPrevPage??false;
        }
        // 「最初のページ」への移動処理
        internal void ExecuteFirstPage()
        {
            Pdffile?.FirstPage();
            SetFlag();
        }

        // 「次のページ」への移動処理
        internal void ExecuteNextPage()
        {
            Pdffile?.NextPage();
            SetFlag();
        }

        // 「前のページ」への移動処理
        internal void ExecutePreviousPage()
        {
            Pdffile?.PrevPage();
            SetFlag();
        }



        // 「最後のページ」への移動処理
        internal void ExecuteLastPage()
        {
            Pdffile?.LastPage();
            SetFlag();
        }


            internal void ExecuteSpecifyPage()
        {
            // 「ページ指定」の処理
            //pdffile?.GoToPage(page)
        }
    }
}
