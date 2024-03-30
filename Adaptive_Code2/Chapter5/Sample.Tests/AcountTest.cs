using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample;


namespace Sample.Tests
{
    [TestClass]
    public class AcountTest
    {
        [TestMethod]
        public void AddingTransactionChangeBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);

        }
    }
}
