using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.Configuration;

namespace ListReactiveProperty
{
    internal class ViewModel
    {
        public ObservableCollection<FileViewParam> FilesList { get; } = [];
        public ReactiveCommand<string> AppendFile { get; } = new();
        public ReadOnlyReactiveProperty<string?> FileName { get; }

        public ReactiveProperty<string> SelectedImagePath { get; } = new();

        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource> ImageSource { get; } = new();

        public ReactiveCommand OpenWindowCommand { get; } = new();

        public ViewModel()
        {
            this.FileName = AppendFile.ToReadOnlyReactiveProperty();
            AppendFile.Subscribe(name =>
            {
                if (string.IsNullOrEmpty(name)) return;
                FilesList.Add(new(name));
            });

            SelectedImagePath.Subscribe(path =>
            {
                if (string.IsNullOrEmpty(path)) return;
                ImageSource.Value = ImageCreater.GetImageFromFile(new(path));
            });

            OpenWindowCommand.Subscribe(_ => OpenNewWindow());
        }

        private void OpenNewWindow()
        {
            var window = new ViewerWindow();
            var model = new ViewerViewModel(ImageSource);
            window.DataContext = model;
            window.Show();
        }


    }
}
