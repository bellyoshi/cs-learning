using ListReactiveProperty.FileViewParams;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.ViewModels
{
    internal class RotateCommands
    {
        public RotateCommands(ReactiveProperty<FileViewParams.FileViewParam> fileViewParam)
        {
            this.fileViewParam = fileViewParam;
            fileViewParam.Subscribe(f =>
            {
                if (f is DocuGraphFileViewParam d)
                {
                    docuGraphFileViewParam.Value = d;
                }
                SetFlag();
            });
            docuGraphFileViewParam.Subscribe(_ => SetFlag());
        }

        private void SetFlag()
        {
            if (fileViewParam.Value is EmptyFileViewParam)
                CanRotate.Value = false;
            else
                CanRotate.Value = fileViewParam.Value is DocuGraphFileViewParam;

        }

        ReactiveProperty<FileViewParams.FileViewParam> fileViewParam;

        ReactiveProperty<DocuGraphFileViewParam> docuGraphFileViewParam = new();
        public ReactiveProperty<bool> CanRotate { get; set; } = new(true);
        // 表示メニュー
        public ReactiveCommand CreateRotateOriginalCommand()
        {
            var command = CanRotate.ToReactiveCommand();
            command.Subscribe(_ => ExecuteRotateOriginal());
            return command;
        }
        public ReactiveCommand CreateRotateRight90Command()
        {             var command = CanRotate.ToReactiveCommand();
                   command.Subscribe(_ => ExecuteRotateRight90());
                   return command;
        }
    
        public ReactiveCommand CreateRotateLeft90Command()
        {
            var command = CanRotate.ToReactiveCommand();
            command.Subscribe(_ => ExecuteRotateLeft90());
            return command;

        }
        public ReactiveCommand CreateRotate180Command()
        {
            var command = CanRotate.ToReactiveCommand();
            command.Subscribe(_ => ExecuteRotate180());
            return command;

        }
        private void ExecuteRotateOriginal()
        {
            // 「元の表示」の回転処理
            
            docuGraphFileViewParam.Value.Angle = 0;
            

        }

        private void ExecuteRotateRight90()
        {
            // 「右へ90度回転」の処理
            docuGraphFileViewParam.Value.Angle = 90;
        }

        private void ExecuteRotateLeft90()
        {
            // 「左へ90度回転」の処 理
           docuGraphFileViewParam.Value.Angle = 270;
        }

        private void ExecuteRotate180()
        {
            // 「180度回転」の処理
            docuGraphFileViewParam.Value.Angle = 180;
        }
    }
}
