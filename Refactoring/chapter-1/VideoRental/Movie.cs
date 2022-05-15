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
        _priceCode = priceCode;
    }

    public void setPriceCode(int arg)
    {
        _priceCode=arg;
    }
    public string getTitle() => _title;
    
    public int getPriceCode() => _priceCode;

    internal double getCharge(int daysRented)
    {
        double result = 0;
        switch (getPriceCode())
        {
            case Movie.REGULAR:
                result += 2;
                if (daysRented > 2)
                    result += (daysRented - 2) * 1.5;
                break;
            case Movie.NEW_RELEASE:
                result += daysRented * 3;
                break;
            case Movie.CHILDRENS:
                result += 1.5;
                if (daysRented > 3)
                    result += (daysRented - 3) * 1.5;
                break;
        }

        return result;
    }

    internal int getFrequentRenterPoints(int dayRented)
    {
        if (getPriceCode() == Movie.NEW_RELEASE && dayRented > 1)
            return 2;
        return 1;
    }
}
