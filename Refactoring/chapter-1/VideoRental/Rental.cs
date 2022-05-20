namespace VideoRental;

public class Rental
{
    public Movie Movie { get; }
    private int _daysRented;

    public Rental(Movie movie, int daysRented)
    {
        Movie = movie;
        _daysRented = daysRented;
    }

    public int getDaysRented() => _daysRented;

    internal double getCharge()
        => Movie.getCharge(_daysRented);
    

    internal int getFrequentRenterPoints() 
        => Movie.getFrequentRenterPoints(_daysRented);

}
