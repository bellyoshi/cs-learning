using System.Threading.Tasks;

namespace ManyCore0401.CellularAutomaton.Logic
{
  public class LangtonsLoops
  {
    // 世界のサイズ(正方形の一辺)
    int _size;

    // 世界(intの2次元配列)
    int[,] _lives;
    public int[,] Lives { get { return _lives; } }

    // セル・オートマトンの規則
    Rule _rule;
    bool _isRuleLoaded;

    // 初期配置(実行するときに世界の中央付近に置く)
    readonly int[,] DefaultLives ={
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

    // 観測結果(各方向の隣のセルの値)
    int[,] _northLife;
    int[,] _eastLife;
    int[,] _southLife;
    int[,] _westLife;


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
      PrepareWatchingArray();
    }

    // Lives配列を作成し、初期状態を設定する
    private void CreateLives()
    {
      _lives = new int[_size, _size];

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

    // 観測用の配列を生成
    private void PrepareWatchingArray()
    {
      _northLife = new int[_size, _size];
      _eastLife = new int[_size, _size];
      _southLife = new int[_size, _size];
      _westLife = new int[_size, _size];
    }

    private async void LoadRule()
    {
      _rule = await RuleLoader.LoadAsync("Langtons-Loops.table.txt");
      _isRuleLoaded = true;
    }




    public void Update()
    {
      while (!_isRuleLoaded)
        Task.Delay(100).GetAwaiter().GetResult();

      // 隣を見る (観測し終わるまで _lives を変更してはいけない)
      for (int r = 1; r < _size - 1; r++)
      {
        for (int c = 1; c < _size - 1; c++)
        {
          _northLife[r, c] = _lives[r - 1, c];
          _eastLife[r, c] = _lives[r, c + 1];
          _southLife[r, c] = _lives[r + 1, c];
          _westLife[r, c] = _lives[r, c - 1];
        }
      }

      // 次ステップの状態を計算して書き換える
      for (int r = 1; r < _size - 1; r++)
      {
        for (int c = 1; c < _size - 1; c++)
        {
          _lives[r, c] = _rule.Next(_lives[r, c], _northLife[r, c], _eastLife[r, c], _southLife[r, c], _westLife[r, c]);
        }
      }
    }
  }
}
