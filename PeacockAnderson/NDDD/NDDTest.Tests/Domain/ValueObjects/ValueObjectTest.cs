using NDDD.Infrastructure.Fake;
using NDDD.Domain.ValueObjects;

namespace NDDTest.Tests.Domain.ValueObjects;

[TestClass]
public class ValueObjectTest
{
    private FakeValueObject fvo1A = new (1);
    private FakeValueObject fvo1B = new (1);
    private FakeValueObject fvo2A = new (2);
    

    [TestMethod]
    public void EqualsTest()
    {
        fvo1A.Equals(fvo1A).IsTrue();
        fvo1A.Equals(fvo1B).IsTrue();
        fvo1A.Equals(fvo2A).IsFalse();
        fvo1A.Equals(new object()).IsFalse();
        fvo1A.Equals(null).IsFalse();
    }
    
    [TestMethod]
    public void operatorEqualTest()
    {
        Assert.IsTrue(fvo1A == fvo1B);
        Assert.IsFalse(fvo1A == fvo2A);
        
        Assert.IsFalse(fvo1A != fvo1B);
        Assert.IsTrue(fvo1A != fvo2A);
    }
}
