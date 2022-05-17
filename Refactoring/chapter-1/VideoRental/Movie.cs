namespace VideoRental;


public class Movie
{
    public const int CHILDRENS = 2;
    public const int REGULAR = 0;
    public const int NEW_RELEASE = 1;

    private string _title;
    private int _priceCode;

    public Movie(string title, int priceCode)
    {
        _title = title;
        setPriceCode(priceCode);
    }

    public void setPriceCode(int arg)
    {
        _priceCode=arg;
    }
    public string getTitle() => _title;
    
    public int getPriceCode() => _priceCode;

    public double getCharge(int daysRented)
    {
        switch (getPriceCode())
        {
            case Movie.REGULAR:
                if (daysRented > 2)
                    return 2 + (daysRented - 2) * 1.5;
                return 2;
            case Movie.NEW_RELEASE:
                return daysRented * 3;
            case Movie.CHILDRENS:
                if (daysRented > 3)
                    return 1.5 +  (daysRented - 3) * 1.5;
                return 1.5;
        }
        return 0;
    }

    internal int getFrequentRenterPoints(int dayRented)
    {
        if (getPriceCode() == Movie.NEW_RELEASE && dayRented > 1)
            return 2;
        return 1;
    }
}
