using ManyCore0401.CellularAutomaton.Logic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;


// 基本ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234237 を参照してください

namespace ManyCore0401.CellularAutomaton
{
  /// <summary>
  /// 多くのアプリケーションに共通の特性を指定する基本ページ。
  /// </summary>
  public sealed partial class MainPage : ManyCore0401.CellularAutomaton.Common.LayoutAwarePage
  {
    const int SIZE = 512;

    LangtonsLoops _langtonsLoops;

    WriteableBitmap _bitmap;
    Color[] _cellColors = new Color[8];

    public MainPage()
    {
      this.InitializeComponent();

      InitializeCellColors();
      PrepareBitmap();
      InitializeLangtonsLoops();
    }

    private void InitializeCellColors()
    {
      _cellColors[0] = Colors.Black;
      _cellColors[1] = Colors.Blue;
      _cellColors[2] = Colors.Red;
      _cellColors[3] = Colors.Green;
      _cellColors[4] = Colors.Yellow;
      _cellColors[5] = Colors.Magenta;
      _cellColors[6] = Colors.White;
      _cellColors[7] = Colors.Cyan;
    }

    private void PrepareBitmap()
    {
      _bitmap = BitmapFactory.New(SIZE, SIZE);
      this.imageLiveSpace.Source = _bitmap;
    }

    private void InitializeLangtonsLoops()
    {
      _langtonsLoops = new LangtonsLoops(SIZE);
      UpdateBitmap(_langtonsLoops.Lives);
    }

    private void UpdateBitmap(int[,] lives)
    {
      _bitmap.ForEach((x, y) => _cellColors[lives[y, x]]);
    }



    /// <summary>
    /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
    /// 再作成する場合は、保存状態も指定されます。
    /// </summary>
    /// <param name="navigationParameter">このページが最初に要求されたときに
    /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたパラメーター値。
    /// </param>
    /// <param name="pageState">前のセッションでこのページによって保存された状態の
    /// ディクショナリ。ページに初めてアクセスするとき、状態は null になります。</param>
    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
    }

    /// <summary>
    /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
    /// このページに関連付けられた状態を保存します。値は、
    /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
    /// </summary>
    /// <param name="pageState">シリアル化可能な状態で作成される空のディクショナリ。</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
    }



    private async void StartStopButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      const string START = "START";
      const string STOP = "STOP";

      var button = sender as Button;
      var label = button.Content as string;
      if (label == START)
      {
        button.Content = STOP;

        await RunLoops();

        button.Content = START;
      }
      else 
      {
        await Stop();
      }
    }

    private async void ResetButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      await Stop();
      InitializeLangtonsLoops();
    }



    private bool _isRunning;
    private bool _isStopped = true;

    private async Task RunLoops()
    {
      _isRunning = true;
      _isStopped = false;

      DateTimeOffset startTime = DateTimeOffset.Now;
      int count = 0;

      while (_isRunning)
      {
        _langtonsLoops.Update();
        UpdateBitmap(_langtonsLoops.Lives);

        count++;
        TimeSpan duration = DateTimeOffset.Now.Subtract(startTime);
        this.textCycleTime.Text = string.Format("{0:0.000}秒", duration.TotalMilliseconds / count / 1000.0);

        await Task.Yield(); //画面更新の機会を与える (お行儀悪っ!!)
      }

      _isStopped = true;
    }

    private async Task Stop()
    {
      _isRunning = false;

      while (!_isStopped)
        await Task.Delay(100);
    }

  }
}
