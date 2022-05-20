namespace VideoRental;

public class Customer
{
    public string Name { get; }
    private List<Rental> rentals = new List<Rental>();

    public Customer(string name)
    {
        Name = name;
    }

    public void addRental(Rental rental)
    =>
        rentals.Add(rental);
    

    public string statement()
    {
        string result = $"Rental Record for {Name}\n";
        foreach(Rental each in rentals)
        {
            result += "\t" + each.Movie.Title +"\t" + each.getCharge() + "\n";
        }
        result += "Amount owed in " + getTotalCharge() + "\n";
        result += "You earned " + getTotalFrequentRentalPoints() + " frequent renter points";
        return result;
    }

    public string htmlStatement()
    {
        string result = $"<H1>Rental Record for <EM>{Name}</EM></H1>\n";
        result += "<P>";
        foreach (Rental each in rentals)
        {
            result += $"{each.Movie.Title}:{each.getCharge()}<BR>\n";
        }
        result +="</P>";
        result += $"<P>You owe <EM>{getTotalCharge()}</EM></P>\n";
        result += "<P>On this rental you earned ";
        result += $"<EM>{getTotalFrequentRentalPoints()}</EM>";
        result += "frequent renter points</P>";
        return result;
    }

    private int getTotalFrequentRentalPoints()
        => rentals.Sum(rental => rental.getFrequentRenterPoints());
    
    private double getTotalCharge()
        => rentals.Sum(rental => rental.getCharge());

}
