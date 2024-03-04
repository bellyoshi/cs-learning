using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.Configuration;
using Reactive.Bindings.Extensions;
using ListReactiveProperty.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ListReactiveProperty.ViewModels;

internal class MainViewModel
{
    public ReactiveCollection<SearchResultViewModel> FilesList { get; } = [];

    public ObservableCollection<MenuItemViewModel> ListMenuItems { get; set; }= new();
    public class MenuItemViewModel
    {
        public string Header { get; set; }
        public ICommand Command { get; set; }
        // 必要に応じて他のプロパティや子メニュー項目のコレクションも追加できます
    }

    public ReactiveProperty<FileViewParam> PreviewFile { get; } = new();

    private readonly PdfCommands pdfCommands;
    public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource?> ImageSource { get; } = new();

    public ReactiveProperty<Visibility> IsPdf { get; } = new();


    // ファイルメニュー
    public ReactiveCommand<string> AppendFile { get; } = new();
    public ReactiveCommand ListCommand { get; } = new ();
    public ReactiveCommand<string> OpenCommand { get; } = new ();

    //DeselectAllCommand
    public ReactiveCommand DeselectAllCommand { get; } = new ();
    //SelectAllCommand
    public ReactiveCommand SelectAllCommand { get; } = new ();
    public ReactiveCommand DeleteCommand { get; } = new ();

    // 表示メニュー
    public ReactiveCommand RotateOriginalCommand { get; } = new ();
    public ReactiveCommand RotateRight90Command { get; } = new ();
    public ReactiveCommand RotateLeft90Command { get; } = new ();
    public ReactiveCommand Rotate180Command { get; } = new ();

    // ページナビゲーション
    public ReactiveCommand FirstPageCommand { get; } = new ();
    public ReactiveCommand NextPageCommand { get; }
    public ReactiveCommand PreviousPageCommand { get; } 
    public ReactiveCommand LastPageCommand { get; } = new ();
    public ReactiveCommand SpecifyPageCommand { get; } = new ();

    // ズーム
    public ReactiveCommand FitWidthCommand { get; } = new ();
    public ReactiveCommand ShowAllCommand { get; } = new ();
    public ReactiveCommand ZoomInCommand { get; } = new ();
    public ReactiveCommand ZoomOutCommand { get; } = new ();

    // 再生
    public ReactiveCommand MoveToStartCommand { get; } = new ();
    public ReactiveCommand StartPlayingCommand { get; } = new ();
    public ReactiveCommand PausePlayingCommand { get; } = new ();
    public ReactiveCommand FastForwardCommand { get; } = new ();
    public ReactiveCommand RewindCommand { get; } = new ();

    // セカンドモニター操作
    public ReactiveCommand ShowOnSecondMonitorCommand { get; } = new ();
    public ReactiveCommand EndShowOnSecondMonitorCommand { get; } = new ();
    public ReactiveCommand ShowBackgroundOnSecondMonitorCommand { get; } = new ();

    // 設定メニュー
    public ReactiveCommand DisplaySettingsCommand { get; } = new ();
    public ReactiveCommand AutoShowCommand { get; } = new ();
    public ReactiveCommand SlimSizeCommand { get; } = new ();
    public ReactiveCommand StandardSizeCommand { get; } = new ();

    // ヘルプメニュー
    public ReactiveCommand AboutCommand { get; } = new ();

    public ReactiveProperty<int> PageCount { get; } = new();
    public ReactiveProperty<int> CurrentPage { get; } = new();

    public MainViewModel()
    {
        pdfCommands = new(PreviewFile, PageCount, CurrentPage);

        AppendFile.Subscribe(ExecuteAppendFile);
        
        PreviewFile.Subscribe(file =>
        {
            if (file is ImageSetter imageSetter)
            {
                imageSetter.SetDisplay(ThatModel.GetInstance());
            }
        });

    

        PreviewFile.Subscribe(file =>
        {
            bool visible = file is PdfFileViewParam or EmptyFileViewParam;
            IsPdf.Value = visible ? Visibility.Visible : Visibility.Collapsed;

        });

        ThatModel thatModel = ThatModel.GetInstance();
        ImageSource = thatModel.ToReactivePropertyAsSynchronized(x => x.ImageSource);



        // 各コマンドのアクションを設定
        OpenCommand.Subscribe(ExecuteOpen);
        DeselectAllCommand.Subscribe(_ =>
        {
            foreach(var file in FilesList) file.IsSelected.Value = false;
        });
        SelectAllCommand.Subscribe(_ =>
            { foreach(var file in FilesList) file.IsSelected.Value = true;}
        );
        DeleteCommand.Subscribe(_ =>
        {
            var files = FilesList.Where(x => x.IsSelected.Value).ToList();
            foreach(var file in files) FilesList.Remove(file);
            PreviewFile.Value = EmptyFileViewParam.Instance;
        });

        FilesList.CollectionChanged += FilesList_CollectionChanged;
        UpdateListMenuItems();

        RotateOriginalCommand.Subscribe(_ => ExecuteRotateOriginal());
        RotateRight90Command.Subscribe(_ => ExecuteRotateRight90());
        RotateLeft90Command.Subscribe(_ => ExecuteRotateLeft90());
        Rotate180Command.Subscribe(_ => ExecuteRotate180());


        FirstPageCommand = pdfCommands.CreateFirstPageCommand();
        NextPageCommand = pdfCommands.CreateNextPageCommand();

        PreviousPageCommand = pdfCommands.CreatePreviousPageCommand();

        LastPageCommand = pdfCommands.CreateLastPageCommand();
        SpecifyPageCommand = pdfCommands.CreateSpecifyPageCommand();

        FitWidthCommand.Subscribe(_ => ExecuteFitWidth());
        ShowAllCommand.Subscribe(_ => ExecuteShowAll());
        ZoomInCommand.Subscribe(_ => ExecuteZoomIn());
        ZoomOutCommand.Subscribe(_ => ExecuteZoomOut());

        MoveToStartCommand.Subscribe(_ => ExecuteMoveToStart());
        StartPlayingCommand.Subscribe(_ => ExecuteStartPlaying());
        PausePlayingCommand.Subscribe(_ => ExecutePausePlaying());
        FastForwardCommand.Subscribe(_ => ExecuteFastForward());
        RewindCommand.Subscribe(_ => ExecuteRewind());

        ShowOnSecondMonitorCommand.Subscribe(_ => ExecuteShowOnSecondMonitor());
        EndShowOnSecondMonitorCommand.Subscribe(_ => ExecuteEndShowOnSecondMonitor());
        ShowBackgroundOnSecondMonitorCommand.Subscribe(_ => ExecuteShowBackgroundOnSecondMonitor());

        DisplaySettingsCommand.Subscribe(_ => ExecuteDisplaySettings());
        AutoShowCommand.Subscribe(_ => ExecuteAutoShow());
        SlimSizeCommand.Subscribe(_ => ExecuteSlimSize());
        StandardSizeCommand.Subscribe(_ => ExecuteStandardSize());

        AboutCommand.Subscribe(_ => ExecuteAbout());

        FilesList.CollectionChanged += (sender, e) =>
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
        };
    }

    private void OnIsSelectedChanged(SearchResultViewModel item)
    {
        // IsSelected.Valueが変更されたときの処理
        // ここで必要なロジックを実装します
        
        var files = this.FilesList.Where(x => x.IsSelected.Value).ToList();
        if (files.Count == 1)
        {
            PreviewFile.Value = files[0].FileViewParam;
        }else
        {
            PreviewFile.Value = EmptyFileViewParam.Instance;
        }

    }

    private FileViewParam? AppendToFileList(string name)
    {
        if (string.IsNullOrEmpty(name)) return null;
        var file = FileTypes.GetFileViewParam(name);
        SearchResultViewModel serchResultViewModel = new (file);
        FilesList.Add(new(file));
        return file;
    }

    private void ExecuteAppendFile(string name)
    {
        // 「追加」の処理
        AppendToFileList(name);
    }
    private void ExecuteOpen(string name)
    {
        // 「開く」の処理
        var file =  AppendToFileList(name);
        if (file == null) return;
        PreviewFile.Value = file;

    }

    private void ExecuteRotateOriginal()
    {
        // 「元の表示」の回転処理
    }

    private void ExecuteRotateRight90()
    {
        // 「右へ90度回転」の処理
    }

    private void ExecuteRotateLeft90()
    {
        // 「左へ90度回転」の処理
    }

    private void ExecuteRotate180()
    {
        // 「180度回転」の処理
    }

    

    private void ExecuteFitWidth()
    {
        // 「ウィンドウ幅に合わせる」のズーム処理
    }

    private void ExecuteShowAll()
    {
        // 「全体を表示」のズーム処理
    }

    private void ExecuteZoomIn()
    {
        // 「拡大」のズーム処理
    }

    private void ExecuteZoomOut()
    {
        // 「縮小」のズーム処理
    }

    private void ExecuteMoveToStart()
    {
        // 「最初に移動」の処理
    }

    private void ExecuteStartPlaying()
    {
        // 「再生開始」の処理
    }

    private void ExecutePausePlaying()
    {
        // 「一時停止」の処理
    }

    private void ExecuteFastForward()
    {
        // 「早送り」の処理
    }

    private void ExecuteRewind()
    {
        // 「巻き戻し」の処理
    }

    private void ExecuteShowOnSecondMonitor()
    {
        OpenNewWindow();
    }

    private void ExecuteEndShowOnSecondMonitor()
    {
        Utils.WindowDispacher.CloseWindow<ViewerWindow>();
    }

    private void ExecuteShowBackgroundOnSecondMonitor()
    {
        // 「セカンドモニターでの背景表示」の処理
    }

    private void ExecuteDisplaySettings()
    {
        // 「ディスプレイと背景色の設定」の処理
        Windows.SettingWindow settingWindow = new();
        settingWindow.Show();
    }

    private void ExecuteAutoShow()
    {
        // 「操作中に自動表示」の設定
    }

    private void ExecuteSlimSize()
    {
        // 「スリムサイズ」の設定
    }

    private void ExecuteStandardSize()
    {
        // 「標準サイズ」の設定
    }

    private void ExecuteAbout()
    {
        // 「このアプリについて」の処理
    }

    private void OpenNewWindow()
    {
        var window = new ViewerWindow();
        window.Show();


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
        UpdateListMenuItems();
    }



}
