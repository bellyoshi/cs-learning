using System.Threading.Tasks;

namespace ManyCore0404.CellularAutomaton.Logic
{
  public class LangtonsLoops : System.ComponentModel.INotifyPropertyChanged
  {
    // 世界のサイズ(正方形の一辺)
    int _size;

    // 世界(intの2次元配列)
    byte[,] _lives;
    byte[,] _nextLives;
    public byte[,] Lives { get { return _lives; } }

    // セル・オートマトンの規則
    Rule _rule;
    bool _isRuleLoaded;

    // 初期配置(実行するときに世界の中央付近に置く)
    readonly byte[,] DefaultLives ={
            {0,2,2,2,2,2,2,2,2,0,0,0,0,0,0},
            {2,1,7,0,1,4,0,1,4,2,0,0,0,0,0},
            {2,0,2,2,2,2,2,2,0,2,0,0,0,0,0},
            {2,7,2,0,0,0,0,2,1,2,0,0,0,0,0},
            {2,1,2,0,0,0,0,2,1,2,0,0,0,0,0},
            {2,0,2,0,0,0,0,2,1,2,0,0,0,0,0},
            {2,7,2,0,0,0,0,2,1,2,0,0,0,0,0},
            {2,1,2,2,2,2,2,2,1,2,2,2,2,2,0},
            {2,0,7,1,0,7,1,0,7,1,1,1,1,1,2},
            {0,2,2,2,2,2,2,2,2,2,2,2,2,2,0},
          };


    public LangtonsLoops()
    {
      Prepare(64); //デフォルトサイズ
    }

    public LangtonsLoops(int size)
    {
      Prepare(size);
    }

    private void Prepare(int size)
    {
      _size = size;
      LoadRule();
      CreateLives();
    }

    private void CreateLives()
    {
      _lives = new byte[_size, _size];
      _nextLives = new byte[_size, _size];

      int defaultRow = (_size - DefaultLives.GetLength(0)) / 2;
      int defaultColmn = (_size - DefaultLives.GetLength(1)) / 2;
      for (int r0 = 0; r0 < DefaultLives.GetLength(0); r0++)
      {
        for (int c0 = 0; c0 < DefaultLives.GetLength(1); c0++)
        {
          int r = defaultRow + r0;
          int c = defaultColmn + c0;
          _lives[r, c] = DefaultLives[r0, c0];
        }
      }
    }

    private async void LoadRule()
    {
      _rule = await RuleLoader.LoadAsync("Langtons-Loops.table.txt");
      _isRuleLoaded = true;
    }






    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    private bool _isRunning;
    private bool _isStopped = true;

    public async Task RunLoopsAsync()
    {
      _isRunning = true;
      _isStopped = false;

      while (!_isRuleLoaded)
        await Task.Delay(100);

      await Task.Run(() =>
        {
          while (_isRunning)
          {
            Update();

            if (this.PropertyChanged != null)
              this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Lives"));
          }
        });

      _isStopped = true;
    }

    public async Task StopAsync()
    {
      _isRunning = false;

      while (!_isStopped)
        await Task.Delay(10);
    }





    private void Update()
    {
      Parallel.For(1, _size - 1, (r) =>
      {
        for (int c = 1; c < _size - 1; c++)
        {
          byte north = _lives[r - 1, c];
          byte east = _lives[r, c + 1];
          byte south = _lives[r + 1, c];
          byte west = _lives[r, c - 1];
          _nextLives[r, c] = _rule.Next(_lives[r, c], north, east, south, west);
        }
      });
      
      // swap world
      byte[,] temp = _lives;
      _lives = _nextLives;
      _nextLives = temp;
    }

  }
}
