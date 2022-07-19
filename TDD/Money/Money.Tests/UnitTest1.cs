namespace Money.Tests;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void testMultiplication()
    {
        Dollar five = new Dollar(5);
        five.times(2);
        Assert.AreEqual(10, five.Amount);
    }
}