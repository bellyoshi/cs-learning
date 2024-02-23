using ListReactiveProperty.Windows;
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
        public PdfCommand(ReactiveProperty<FileViewParam> selectedFile,
            ReactiveProperty<int> PageCount,
            ReactiveProperty<int> CurrentPage)
        {
            SelectedFile = selectedFile;

            this.PageCount = PageCount;
            this.CurrentPage = CurrentPage;
            SelectedFile.Subscribe(_ => SetFlag());
        }
        private ReactiveProperty<FileViewParam> SelectedFile { get; } 
        private ReactiveProperty<int> PageCount { get; }
        private ReactiveProperty<int> CurrentPage { get; }



        public ReactiveProperty<bool> CanNext { get; } = new ReactiveProperty<bool>(false);

        public ReactiveProperty<bool> CanPrev { get; } = new ReactiveProperty<bool>(false);
        private PdfFileViewParam? Pdffile => SelectedFile.Value as PdfFileViewParam;

        private void SetFlag()
        {
            CanNext.Value = Pdffile?.CanNextPage??false;
            CanPrev.Value = Pdffile?.CanPrevPage??false;
            PageCount.Value = Pdffile?.PageCount??0;
            CurrentPage.Value = Pdffile?.CurrentPage+1??0;
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

        // 「ページ指定」の処理
        internal void ExecuteSpecifyPage()
        {
            var page = PageNumberWindow.GetPageNumber(CurrentPage.Value, PageCount.Value);
            Pdffile?.GoToPage(page - 1);
            SetFlag();
        }


    }
}
