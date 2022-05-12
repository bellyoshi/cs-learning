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
        int frequentRenterPoints = 0;
        string result = "Rental Record for " + getName() + "\n";
        foreach(Rental each in rentals)
        {
            frequentRenterPoints+=each.getFrequentRenterPoints();
            result += "\t" + each.getMovie().getTitle() + "\n";
        }
        result += "Amount owed in " + getTotalCharge() + "\n";
        result += "You earned " + frequentRenterPoints + " frequent renter points";
        return result;
    }

    private double getTotalCharge()
    {
        //return rentals.Sum(rental => rental.getCharge());
        double result = 0;
        foreach (Rental each in rentals)
        {
            result += each.getCharge();
        }
        return result;
    }




}
