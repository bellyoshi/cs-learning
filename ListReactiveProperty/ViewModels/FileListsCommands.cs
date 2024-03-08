using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListReactiveProperty.FileViewParams;

namespace ListReactiveProperty.ViewModels
{
    internal class FileListsCommands
    {

        public ReactiveProperty<FileViewParam> PreviewFile { get; } = new();
        public ReactiveCollection<SearchResultViewModel> FilesList { get; } = [];

        public ObservableCollection<MenuItemViewModel> ListMenuItems { get; set; } = new();

        
        public FileListsCommands(ReactiveProperty<FileViewParam> previewFile)
        {
            PreviewFile = previewFile;
            FilesList.CollectionChanged += FilesList_CollectionChanged;
            UpdateListMenuItems();
        }
        // ファイルメニュー
        public ReactiveCommand<string> CreateAppendFile() {
            var command = new ReactiveCommand<string>();
            command.Subscribe( ExecuteAppendFile);
            return command;
        }

        public ReactiveCommand<string> CreateOpenCommand() { 
            var command = new ReactiveCommand<string>();
            command.Subscribe(ExecuteOpen);
            return command;
        } 

        //DeselectAllCommand
        public ReactiveCommand CreateDeselectAllCommand() {  
            var command = new ReactiveCommand();
            command.Subscribe(_ =>
            {
                foreach (var file in FilesList) file.IsSelected.Value = false;
            });

            return command;
        } 
        //SelectAllCommand
        public ReactiveCommand CreateSelectAllCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ =>
            { foreach (var file in FilesList) file.IsSelected.Value = true; });

            return command;
        } 
        public ReactiveCommand CreateDeleteCommand() { 
            var command = new ReactiveCommand();
            
            command.Subscribe(_ =>
            {
                var files = FilesList.Where(x => x.IsSelected.Value).ToList();
                foreach (var file in files) FilesList.Remove(file);
                PreviewFile.Value = EmptyFileViewParam.Instance;
            });

            return command;
        }
        private void ExecuteAppendFile(string name)
        {
            // 「追加」の処理
            _= AppendToFileList(name);
        }
        private void ExecuteOpen(string name)
        {
            // 「開く」の処理
            var file = AppendToFileList(name);
            if (file == null) return;
            PreviewFile.Value = file;

        }

        private FileViewParam? AppendToFileList(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            var file = FileTypes.GetFileViewParam(name);
            SearchResultViewModel serchResultViewModel = new(file);
            FilesList.Add(serchResultViewModel);
            return file;
        }

        private void UpdateListMenuItems()
        {
            ListMenuItems.Clear();
            foreach (var file in FilesList)
            {
                var menuItem = new MenuItemViewModel
                {
                    Header = file.FileViewParam.filename,
                    Command = new ReactiveCommand().WithSubscribe(() => OpenFile(file))
                };
                ListMenuItems.Add(menuItem);
            }
        }

        private void OpenFile(SearchResultViewModel file)
        {
            PreviewFile.Value = file.FileViewParam;
        }

        private void FilesList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SearchResultViewModel newItem in e.NewItems)
                {
                    // 新しい項目のIsSelected.Valueの変更を監視
                    newItem.IsSelected.Subscribe(_ => OnIsSelectedChanged(newItem));
                }
            }
            if (e.OldItems != null)
            {
                foreach (SearchResultViewModel oldItem in e.OldItems)
                {
                    // 不要になった項目の監視を解除
                    oldItem.IsSelected.Dispose();
                }
            }
            UpdateListMenuItems();
        }

        private void OnIsSelectedChanged(SearchResultViewModel item)
        {
            // IsSelected.Valueが変更されたときの処理
            // ここで必要なロジックを実装します

            var files = this.FilesList.Where(x => x.IsSelected.Value).ToList();
            if (files.Count == 1)
            {
                PreviewFile.Value = files[0].FileViewParam;
            }
            else
            {
                PreviewFile.Value = EmptyFileViewParam.Instance;
            }

        }

    }
}
