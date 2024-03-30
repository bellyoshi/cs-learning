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

        [TestMethod]
        // Account Opening Balance is 0
        public void AccountOpeningBalanceIsZero()
        {
            // Arrange
            var account = new Account();

            // Act
            // Assert
            Assert.AreEqual(0m, account.Balance);
        }

        [TestMethod]
        // Adding 100 Transaction Change Balance
        public void Adding100TransactionChangeBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(100m);

            // Assert
            Assert.AreEqual(100m, account.Balance);
        }

        [TestMethod]
        // Adding Two Transactions Create Summation Balance
        public void AddingTwoTransactionsCreateSummationBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(100m);
            account.AddTransaction(200m);

            // Assert
            Assert.AreEqual(300m, account.Balance);
        }
    }
}
