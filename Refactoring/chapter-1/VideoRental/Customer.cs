﻿using System;
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
            double thisAmount = amountFor(each);

            frequentRenterPoints++;
            if (each.getMovie().getPriceCode() == Movie.NEW_RELEASE && each.getDaysRented() > 1)
                frequentRenterPoints++;
            result += "\t" + each.getMovie().getTitle() + "\n";
            totalAmout += thisAmount;
        }
        result += "Amount owed in " + totalAmout + "\n";
        result += "You earned " + frequentRenterPoints + " frequent renter points";
        return result;
    }

    private static double amountFor(Rental aRental)
    {
        double result = 0;
        switch (aRental.getMovie().getPriceCode())
        {
            case Movie.REGULAR:
                result += 2;
                if (aRental.getDaysRented() > 2)
                    result += (aRental.getDaysRented() - 2) * 1.5;
                break;
            case Movie.NEW_RELEASE:
                result += aRental.getDaysRented() * 3;
                break;
            case Movie.CHILDRENS:
                result += 1.5;
                if (aRental.getDaysRented() > 3)
                    result += (aRental.getDaysRented() - 3) * 1.5;
                break;
        }

        return result;
    }
}
