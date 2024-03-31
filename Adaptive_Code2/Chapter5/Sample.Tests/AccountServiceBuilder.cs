using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Tests
{
    internal class AccountServiceBuilder
    {
        private readonly AccountService _accountService;
        private readonly Mock<IAccountRepository> _mockRepository;

        public Mock<Account> MockAccount
        { get; private set; }

        public AccountServiceBuilder()
        {
            _mockRepository = new Mock<IAccountRepository>();
            _accountService = new AccountService(_mockRepository.Object);
        }

        public AccountServiceBuilder WithAccountCalled(string accountName)
        {
            MockAccount = new Mock<Account>();
            _mockRepository.Setup(r => r.GetByName(accountName))
                .Returns(MockAccount.Object);
            return this;
        }

        public AccountServiceBuilder AddTransactionOfValue(decimal transactionValue)
        {
            MockAccount.Setup(a => a.AddTransaction(transactionValue)).Verifiable();
            return this;
        }

        public AccountService Build()
        {
            return _accountService;
        }

    }
}
