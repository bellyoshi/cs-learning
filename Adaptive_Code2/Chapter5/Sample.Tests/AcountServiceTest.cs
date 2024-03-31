using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;

namespace Sample.Tests
{
    [TestClass]
    public class AcountServiceTest
    {
        private AccountServiceBuilder accountServiceBuilder;

        [TestInitialize]
        public void Setup()
        {
            accountServiceBuilder = new AccountServiceBuilder();
            
        }
        
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            var sut = accountServiceBuilder
                .WithAccountCalled("Trading Account")
                .AddTransactionOfValue(200m)
                .Build();

            sut.AddTransactionToAccount("Trading Account", 200m);

            accountServiceBuilder.MockAccount.Verify();
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
            var sut = accountServiceBuilder.Build();
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
            var sut = accountServiceBuilder
                .WithAccountCalled("Trading Account")
                .Build();
            accountServiceBuilder.MockAccount.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();


            // Act
            try
            {
                sut.AddTransactionToAccount("Trading Account", 100m);
            }catch(ServiceException ex)
            {
                Assert.IsInstanceOfType<DomainException>(ex.InnerException);
            }

            //Assert
            Assert.AreEqual(200m, account.Balance);
        }
    }
}