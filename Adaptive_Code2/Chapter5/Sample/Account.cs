
namespace Sample.Tests
{
    public class Account
    {
        public Account()
        {

        }

        public decimal Balance { get; set; }

        public void AddTransaction(decimal amount)
        {
            Balance = amount;
        }
    }
}