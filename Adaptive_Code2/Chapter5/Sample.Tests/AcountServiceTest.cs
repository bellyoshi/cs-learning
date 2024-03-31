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
        private Mock<Account> mockAccount;
        private Mock<IAccountRepository> mockRepository;
        private AccountService sut;

        [TestInitialize]
        public void Setup()
        {
            // Setup
            mockAccount = new Mock<Account>();
            mockRepository = new Mock<IAccountRepository>();
            sut = new AccountService(mockRepository.Object);
            
        }
        
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            mockAccount.Setup(a => a.AddTransaction(200m)).Verifiable();
            mockRepository.Setup(r => r.GetByName("Trading Account"))
                .Returns(mockAccount.Object);

            //Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            //Assert
            mockAccount.Verify();
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

            // Act
            sut.AddTransactionToAccount("Trading Account", 0m);

            // Assert
            // No exception is thrown
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            mockAccount.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();
            mockRepository.Setup(r => r.GetByName("Trading Account"))
                .Returns(mockAccount.Object);
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