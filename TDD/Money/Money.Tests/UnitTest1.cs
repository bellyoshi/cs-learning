namespace Money.Tests;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMultiplication()
    {
        Dollar  five = new Dollar(5);
        Dollar product = five.Times(2);
        Assert.AreEqual(new Dollar(10), product);
        product = five.Times(3);
        Assert.AreEqual(new Dollar(15), product);
    }

    [TestMethod]
    public void TestEquality()
    {
        Assert.IsTrue(new Dollar(5).Equals(new Dollar(5)));
        Assert.IsFalse(new Dollar(5).Equals(new Dollar(6)));
    }
}