using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NDDD.Domain.ValueObjects;
using NDDD.Infrastructure.Fake;
namespace NDDTest.Tests.Domain.ValueObjects;

[TestClass]
public class ValueObject
{
    [TestMethod]
    public void EqualsTest()
    {
        var fakeValueObject = new FakeValueObject(1);
    }
}
