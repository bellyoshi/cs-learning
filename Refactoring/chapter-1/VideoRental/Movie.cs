namespace VideoRental;

public class Movie
{
    public const int CHILDRENS = 2;
    public const int REGULAR = 0;
    public const int NEW_RELEASE = 1;

    public string Title { get;}

    private Price _price;

    public Movie(string title, int priceCode)
    {
        Title = title;
        setPriceCode(priceCode);
    }

    public void setPriceCode(int arg)
    {
        _price = arg switch
        {
            Movie.REGULAR => new RegularPrice(),
            Movie.NEW_RELEASE => new NewReleasePrice(),
            Movie.CHILDRENS => new ChildrensPrice(),
            _ => throw new InvalidOperationException(),
        };
    }

    public int getPriceCode()
        => _price.getPriceCode();
    public double getCharge(int daysRented)
        => _price.getCharge(daysRented);
    public int getFrequentRenterPoints(int daysRented)
        => _price.getFrequentRenterPoints(daysRented);
}
