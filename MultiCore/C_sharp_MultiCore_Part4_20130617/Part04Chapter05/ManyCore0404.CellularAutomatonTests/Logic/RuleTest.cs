using ManyCore0404.CellularAutomaton.Logic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace ManyCore0404.CellularAutomatonTests
{
  [TestClass]
  public class RuleTest
  {
    [TestMethod]
    public void NextTest_000000()
    {
      var rule = new Rule();
      rule.Add("000000");
      Assert.AreEqual(0, rule.Next(0, 0, 0, 0, 0));
    }

    [TestMethod]
    public void NextTest_702525()
    {
      var rule = new Rule();
      rule.Add("702525");
      Assert.AreEqual(5, rule.Next(7, 0, 2, 5, 2));
      Assert.AreEqual(5, rule.Next(7, 2, 0, 2, 5));
      Assert.AreEqual(5, rule.Next(7, 5, 2, 0, 2));
      Assert.AreEqual(5, rule.Next(7, 2, 5, 2, 0));
    }

  }
}
