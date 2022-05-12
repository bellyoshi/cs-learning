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

    public string getName()
    {
        return _name;
    }

    public void addRental(Rental rental)
    {
        rentals.Add(rental);
    }

    public string statement()
    {
        double totalAmout = 0;
        int frequentRenterPoints = 0;
        string result = "Rental Record for " + getName() + "\n";
        foreach(Rental each in rentals)
        {
            frequentRenterPoints+=each.getFrequentRenterPoints();
            result += "\t" + each.getMovie().getTitle() + "\n";
            totalAmout += each.getCharge();
        }
        result += "Amount owed in " + totalAmout + "\n";
        result += "You earned " + frequentRenterPoints + " frequent renter points";
        return result;
    }


}
