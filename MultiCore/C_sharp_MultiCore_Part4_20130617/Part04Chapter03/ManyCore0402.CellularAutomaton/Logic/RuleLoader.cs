using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;

namespace ManyCore0402.CellularAutomaton.Logic
{
  public class RuleLoader
  {
    public static async Task<Rule> LoadAsync(string ruleTableFileName)
    {
      var rule = new Rule();
      string line;

      var sf = await StorageFile.GetFileFromApplicationUriAsync(
                      new Uri("ms-appx:///Logic/" + ruleTableFileName));
      using (var stream = await sf.OpenStreamForReadAsync())
      using (TextReader reader = new StreamReader(stream))
      {
        while (null != (line = await reader.ReadLineAsync()))
        {
          if (Regex.IsMatch(line, "^[0-9]"))
            rule.Add(line);
        }
      }
      return rule;
    }
  }
}
