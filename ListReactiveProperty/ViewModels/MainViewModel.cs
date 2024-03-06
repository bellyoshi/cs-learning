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
using System.Windows.Media.Imaging;
using ListReactiveProperty.Windows;
using ListReactiveProperty.Utils;

namespace ListReactiveProperty.ViewModels;

internal class MainViewModel
{
    public ReactiveCollection<SearchResultViewModel> FilesList { get; }

    public ObservableCollection<MenuItemViewModel> ListMenuItems { get; }


    public ReactiveProperty<FileViewParam> PreviewFile { get; } = new();

    public ReactiveProperty<FileViewParam> DisplayFile { get; } = new();

    private readonly PdfCommands pdfCommands;

    private readonly FileListsCommands fileListsCommands;
    public ReactiveProperty<BitmapSource?> ImageSource { get; } = new();
    public ReactiveProperty<BitmapSource?> DisplayImage { get; } = new();

    public ReactiveProperty<Visibility> IsPdf { get; } = new();


    // ファイルメニュー
    public ReactiveCommand<string> AppendFile { get; }
    public ReactiveCommand<string> OpenCommand { get; } 

    //DeselectAllCommand
    public ReactiveCommand DeselectAllCommand { get; } 
    //SelectAllCommand
    public ReactiveCommand SelectAllCommand { get; } 
    public ReactiveCommand DeleteCommand { get; } 

    // 表示メニュー
    public ReactiveCommand RotateOriginalCommand { get; } = new ();
    public ReactiveCommand RotateRight90Command { get; } = new ();
    public ReactiveCommand RotateLeft90Command { get; } = new ();
    public ReactiveCommand Rotate180Command { get; } = new ();

    // ページナビゲーション
    public ReactiveCommand FirstPageCommand { get; } 
    public ReactiveCommand NextPageCommand { get; }
    public ReactiveCommand PreviousPageCommand { get; } 
    public ReactiveCommand LastPageCommand { get; } 
    public ReactiveCommand SpecifyPageCommand { get; } 

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

        fileListsCommands = new(PreviewFile);
        FilesList = fileListsCommands.FilesList;
        ListMenuItems = fileListsCommands.ListMenuItems;

        AppendFile = fileListsCommands.CreateAppendFile();
        OpenCommand = fileListsCommands.CreateOpenCommand();
        DeselectAllCommand = fileListsCommands.CreateDeselectAllCommand();
        SelectAllCommand = fileListsCommands.CreateSelectAllCommand();
        DeleteCommand = fileListsCommands.CreateDeleteCommand();

        


    

        PreviewFile.Subscribe(file =>
        {
            if (file is ImageSetter imageSetter)
            {
                imageSetter.SetDisplay(DisplayModel.GetInstance());
            }
            bool visible = file is PdfFileViewParam or EmptyFileViewParam;
            IsPdf.Value = visible ? Visibility.Visible : Visibility.Collapsed;

        });

        DisplayModel thatModel = DisplayModel.GetInstance();
        ImageSource = thatModel.ToReactivePropertyAsSynchronized(x => x.ImageSource);
        DisplayImage = thatModel.ToReactivePropertyAsSynchronized(x => x.DisplayImage);



        // 各コマンドのアクションを設定

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
        WindowDispacher.CloseWindow<ViewerWindow>();
    }

    private void ExecuteShowBackgroundOnSecondMonitor()
    {
        // 「セカンドモニターでの背景表示」の処理
    }

    private void ExecuteDisplaySettings()
    {
        // 「ディスプレイと背景色の設定」の処理
        WindowDispacher.ShowWindow<SettingWindow>();
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
        WindowDispacher.ShowWindow<ViewerWindow>();
        DisplayImage.Value = ImageSource.Value;

    }

  



}
