
namespace Sample.Tests
{
    public class AccountService
    {
        private readonly IAccountRepository repository;
        public AccountService(IAccountRepository? repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "A valid account repository must by supplied.");
            }
            this.repository = repository;
        }

        public void AddTransactionToAccount(string accountName, decimal amount)
        {
            var account = repository.GetByName(accountName);
            if (account == null)
            {
                return;
            }
            try
            {
            account.AddTransaction(amount);
            }catch(DomainException ex)
            {
                throw new ServiceException("Adding Transaction to account failed", ex);
            }

        }

        
    }
}