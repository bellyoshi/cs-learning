using NDDD.Infrastructure.Fake;

namespace NDDTest.Tests.Domain.ValueObjects;

[TestClass]
public class ValueObject
{
    [TestMethod]
    public void EqualsTest()
    {
        var fakeValueObject = new FakeValueObject(1);
        fakeValueObject.Equals(fakeValueObject).IsTrue();
        fakeValueObject.Equals(new FakeValueObject(1)).IsTrue();
        fakeValueObject.Equals(new FakeValueObject(2)).IsFalse();
        fakeValueObject.Equals(new object()).IsFalse();
        fakeValueObject.Equals(null).IsFalse();


    }
}
