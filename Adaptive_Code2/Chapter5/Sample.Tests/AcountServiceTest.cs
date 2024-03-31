using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Sample.Tests
{
    [TestClass]
    public class AcountServiceTest
    {
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(200m)).Verifiable();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account"))
                .Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            //Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            //Assert
            account.Verify();
        }
    }
}