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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAccountServiceWithNullRepository()
        {
            // Arrange
            var sut = new AccountService(null);
        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IAccountRepository>();

            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 00m);

            // Assert
            // No exception is thrown
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account"))
                .Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            // Act
            try
            {
                sut.AddTransactionToAccount("Trading Account", 100m);
            }catch(ServiceException ex)
            {
                Assert.IsInstanceOfType<DomainException>(ex.InnerException);
            }

        }
    }
}