
namespace Sample.Tests
{
    public class Account
    {
        public Account()
        {
        }

        public decimal Balance { get; set; }

        public void AddTransaction(decimal v)
        {
            Balance = 200m;
        }
    }
}