using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Tests
{
    internal class FakeAccountRepository : IAccountRepository
    {
        private Account _account;
        public FakeAccountRepository(Account account)
        {
            _account = account;
        }

        public Account GetByName(string accountName)
        {
            return _account;
        }
    }
}
