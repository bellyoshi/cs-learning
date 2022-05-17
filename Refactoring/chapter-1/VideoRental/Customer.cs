using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental;

public class Customer
{
    private string _name;
    private List<Rental> rentals = new List<Rental>();

    public Customer(string name)
    {
        _name = name;
    }

    public string getName() => _name;

    public void addRental(Rental rental)
    =>
        rentals.Add(rental);
    

    public string statement()
    {
        string result = "Rental Record for " + getName() + "\n";
        foreach(Rental each in rentals)
        {
            result += "\t" + each.getMovie().getTitle() +"\t" + each.getCharge() + "\n";
        }
        result += "Amount owed in " + getTotalCharge() + "\n";
        result += "You earned " + getTotalFrequentRentalPoints() + " frequent renter points";
        return result;
    }

    public string htmlStatement()
    {
        string result = $"<H1>Rental Record for <EM>{getName()}</EM></H1>\n";
        result += "<P>";
        foreach (Rental each in rentals)
        {
            result += $"{each.getMovie().getTitle()}:{each.getCharge()}<BR>\n";
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
