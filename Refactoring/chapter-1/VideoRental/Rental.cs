namespace VideoRental;

public class Rental
{
    public Movie Movie { get; }
    public int DaysRented { get; }
    public string Title => Movie.Title;
    public Rental(Movie movie, int daysRented)
    {
        Movie = movie;
        DaysRented = daysRented;
    }
    internal double getCharge()
        => Movie.getCharge(DaysRented);
    internal int getFrequentRenterPoints()
        => Movie.getFrequentRenterPoints(DaysRented);
}
