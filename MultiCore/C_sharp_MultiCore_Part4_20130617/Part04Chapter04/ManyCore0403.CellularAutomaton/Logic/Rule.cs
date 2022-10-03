using System.Collections.Generic;

namespace ManyCore0403.CellularAutomaton.Logic
{
  public class Rule
  {
    // ルールを表すコレクション
    // key: 中央x10000 + 北x1000 + 東x100 + 南x10 + 西 (但し、各位置の値は0～7)
    // value: 次ステップの値
    private Dictionary<int, int> _rules = new Dictionary<int, int>();

    public int Next(int c, int n, int e, int s, int w) // format: CNESWC'
    {
      int key = c * 10000 + n * 1000 + e * 100 + s * 10 + w;
      if (!_rules.ContainsKey(key))
        return 0;

      return _rules[key];
    }

    public int Count { get { return _rules.Count; } }

    public void Add(string ruleString)
    {
      int c = ruleString[0] - '0';
      int n = ruleString[1] - '0';
      int e = ruleString[2] - '0';
      int s = ruleString[3] - '0';
      int w = ruleString[4] - '0';
      int next = ruleString[5] - '0';
      int key1 = c * 10000 + n * 1000 + e * 100 + s * 10 + w;
      _rules.Add(key1, next);
      int key2 = c * 10000 + w * 1000 + n * 100 + e * 10 + s;
      if(!_rules.ContainsKey(key2))
        _rules.Add(key2, next);
      int key3 = c * 10000 + s * 1000 + w * 100 + n * 10 + e;
      if (!_rules.ContainsKey(key3))
        _rules.Add(key3, next);
      int key4 = c * 10000 + e * 1000 + s * 100 + w * 10 + n;
      if (!_rules.ContainsKey(key4))
        _rules.Add(key4, next);
    }
  }
}
