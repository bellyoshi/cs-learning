
namespace Sample.Tests
{
    public class AccountService
    {
        private readonly IAccountRepository repository;
        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public void AddTransactionToAccount(string accountName, decimal amount)
        {
            var account = repository.GetByName(accountName);
            account.AddTransaction(amount);
        }
    }
}