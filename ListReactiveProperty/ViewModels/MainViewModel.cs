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

namespace ListReactiveProperty.ViewModels;

internal class MainViewModel
{
    public ObservableCollection<FileViewParam> FilesList { get; } = [];
    public ReactiveCommand<string> AppendFile { get; } = new();
    public ReadOnlyReactiveProperty<string?> FileName { get; }

    public ReactiveProperty<string> SelectedImagePath { get; } = new();

    public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource?> ImageSource { get; } = new();








    // ファイルメニュー
    public ReactiveCommand ListCommand { get; } = new ReactiveCommand();
    public ReactiveCommand OpenCommand { get; } = new ReactiveCommand();

    // 表示メニュー
    public ReactiveCommand RotateOriginalCommand { get; } = new ReactiveCommand();
    public ReactiveCommand RotateRight90Command { get; } = new ReactiveCommand();
    public ReactiveCommand RotateLeft90Command { get; } = new ReactiveCommand();
    public ReactiveCommand Rotate180Command { get; } = new ReactiveCommand();

    // ページナビゲーション
    public ReactiveCommand FirstPageCommand { get; } = new ReactiveCommand();
    public ReactiveCommand NextPageCommand { get; } = new ReactiveCommand();
    public ReactiveCommand PreviousPageCommand { get; } = new ReactiveCommand();
    public ReactiveCommand LastPageCommand { get; } = new ReactiveCommand();
    public ReactiveCommand SpecifyPageCommand { get; } = new ReactiveCommand();

    // ズーム
    public ReactiveCommand FitWidthCommand { get; } = new ReactiveCommand();
    public ReactiveCommand ShowAllCommand { get; } = new ReactiveCommand();
    public ReactiveCommand ZoomInCommand { get; } = new ReactiveCommand();
    public ReactiveCommand ZoomOutCommand { get; } = new ReactiveCommand();

    // 再生
    public ReactiveCommand MoveToStartCommand { get; } = new ReactiveCommand();
    public ReactiveCommand StartPlayingCommand { get; } = new ReactiveCommand();
    public ReactiveCommand PausePlayingCommand { get; } = new ReactiveCommand();
    public ReactiveCommand FastForwardCommand { get; } = new ReactiveCommand();
    public ReactiveCommand RewindCommand { get; } = new ReactiveCommand();

    // セカンドモニター操作
    public ReactiveCommand ShowOnSecondMonitorCommand { get; } = new ReactiveCommand();
    public ReactiveCommand EndShowOnSecondMonitorCommand { get; } = new ReactiveCommand();
    public ReactiveCommand ShowBackgroundOnSecondMonitorCommand { get; } = new ReactiveCommand();

    // 設定メニュー
    public ReactiveCommand DisplaySettingsCommand { get; } = new ReactiveCommand();
    public ReactiveCommand AutoShowCommand { get; } = new ReactiveCommand();
    public ReactiveCommand SlimSizeCommand { get; } = new ReactiveCommand();
    public ReactiveCommand StandardSizeCommand { get; } = new ReactiveCommand();

    // ヘルプメニュー
    public ReactiveCommand AboutCommand { get; } = new ReactiveCommand();

    public MainViewModel()
    {
        FileName = AppendFile.ToReadOnlyReactiveProperty();
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

        ThatModel thatModel = ThatModel.GetInstance();
        ImageSource = thatModel.ToReactivePropertyAsSynchronized(x => x.ImageSource);



        // 各コマンドのアクションを設定
        OpenCommand.Subscribe(_ => ExecuteOpen());
        RotateOriginalCommand.Subscribe(_ => ExecuteRotateOriginal());
        RotateRight90Command.Subscribe(_ => ExecuteRotateRight90());
        RotateLeft90Command.Subscribe(_ => ExecuteRotateLeft90());
        Rotate180Command.Subscribe(_ => ExecuteRotate180());

        FirstPageCommand.Subscribe(_ => ExecuteFirstPage());
        NextPageCommand.Subscribe(_ => ExecuteNextPage());
        PreviousPageCommand.Subscribe(_ => ExecutePreviousPage());
        LastPageCommand.Subscribe(_ => ExecuteLastPage());
        SpecifyPageCommand.Subscribe(_ => ExecuteSpecifyPage());

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
    private void ExecuteOpen()
    {
        // 「開く」の処理
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

    private void ExecuteFirstPage()
    {
        // 「最初のページ」への移動処理
    }

    private void ExecuteNextPage()
    {
        // 「次のページ」への移動処理
    }

    private void ExecutePreviousPage()
    {
        // 「前のページ」への移動処理
    }

    private void ExecuteLastPage()
    {
        // 「最後のページ」への移動処理
    }

    private void ExecuteSpecifyPage()
    {
        // 「ページ指定」の処理
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
        // 「セカンドモニターでの表示終了」の処理
    }

    private void ExecuteShowBackgroundOnSecondMonitor()
    {
        // 「セカンドモニターでの背景表示」の処理
    }

    private void ExecuteDisplaySettings()
    {
        // 「ディスプレイと背景色の設定」の処理
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


}
