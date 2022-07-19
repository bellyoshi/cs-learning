namespace Money;

public class Dollar
{
    public int Amount { get; set; } 

    public Dollar(int amount)
    {
        this.Amount = amount;
    }

    public void times(int multiplier)
    {
        Amount *= multiplier;
    }
}