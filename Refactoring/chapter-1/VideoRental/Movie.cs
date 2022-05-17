namespace VideoRental;


public class Movie
{
    public const int CHILDRENS = 2;
    public const int REGULAR = 0;
    public const int NEW_RELEASE = 1;

    private string _title;
    private Price _price;

    public Movie(string title, int priceCode)
    {
        _title = title;
        setPriceCode(priceCode);
    }

    public void setPriceCode(int arg)
    {
        switch (arg)
        {
            case Movie.REGULAR:
                _price = new RegularPrice();
                break;
            case Movie.NEW_RELEASE:
                _price = new NewReleasePrice();
                break;

            case Movie.CHILDRENS:
                _price = new ChildrensPrice();
                break;
            default: 
                throw new ArgumentOutOfRangeException();
        }
    }
    public string getTitle() => _title;
    
    public int getPriceCode() => _price.getPriceCode();

    public double getCharge(int daysRented) => _price.getCharge(daysRented);

    public int getFrequentRenterPoints(int daysRented) => _price.getFrequentRenterPoints(daysRented);


}
