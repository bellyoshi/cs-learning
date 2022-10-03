
namespace ManyCore0404.CellularAutomaton.Logic
{
  public class Rule
  {
    // ルールを表すコレクション
    // key: 中央(3bit) 北(3bit) 東(3bit) 南(3bit) 西(3bit) (但し、各位置の値は0～7)
    // value: 次ステップの値
    // keyを配列のインデックスとして、配列にはvalueを格納
    private byte[] _rules = new byte[32767];

    public byte Next(byte c, byte n, byte e, byte s, byte w) // format: CNESWC'
    {
      int key = (c << 12) | (n << 9) | (e << 6) | (s << 3) | w; //インライン展開しておく
      return _rules[key];
    }



    public void Add(string ruleString)
    {
      int c = ruleString[0] - '0';
      int n = ruleString[1] - '0';
      int e = ruleString[2] - '0';
      int s = ruleString[3] - '0';
      int w = ruleString[4] - '0';
      byte next = (byte)(ruleString[5] - '0');
      int key1 = CalcKey(c, n, e, s, w);
      _rules[key1] = next;

      int key2 = CalcKey(c, w, n, e, s);
      _rules[key2] = next;

      int key3 = CalcKey(c, s, w, n, e);
      _rules[key3] = next;

      int key4 = CalcKey(c, e, s, w, n);
      _rules[key4] = next;
    }

    private int CalcKey(int c, int n, int e, int s, int w)
    {
      return (c << 12) | (n << 9) | (e << 6) | (s << 3) | w;
    }
  }
}
