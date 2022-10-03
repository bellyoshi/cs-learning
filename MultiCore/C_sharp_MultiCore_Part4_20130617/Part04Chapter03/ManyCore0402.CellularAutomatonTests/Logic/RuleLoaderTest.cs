using ManyCore0402.CellularAutomaton.Logic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace ManyCore0402.CellularAutomatonTests
{
  [TestClass]
  public class RuleLoaderTest
  {
    [TestMethod]
    public async Task LoadTest_LangtonsLoops()
    {
      Rule rule = await RuleLoader.LoadAsync("Langtons-Loops.table.txt");
      Assert.AreEqual(857, rule.Count); //回転しても同じルールのものがあるので、219x4より少なくなる
    }

    [TestMethod]
    public async Task LoadAndNextTest_LangtonsLoops()
    {
      Rule rule = await RuleLoader.LoadAsync("Langtons-Loops.table.txt");

      Assert.AreEqual(5, rule.Next(7, 0, 2, 5, 2));
      Assert.AreEqual(5, rule.Next(7, 2, 0, 2, 5));
      Assert.AreEqual(5, rule.Next(7, 5, 2, 0, 2));
      Assert.AreEqual(5, rule.Next(7, 2, 5, 2, 0));
    }

  }
}
