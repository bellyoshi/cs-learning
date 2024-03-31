using Sample.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public interface IAccountRepository
    {
        public Account GetByName(string accountName);

    }
}
