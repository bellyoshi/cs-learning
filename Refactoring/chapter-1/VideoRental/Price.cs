namespace VideoRental;

abstract class Price 
{
    abstract public int getPriceCode();

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
    
}

class ChildrensPrice : Price
{
    public override int getPriceCode()
    {
        return Movie.CHILDRENS;
    }
}

class NewReleasePrice : Price
{
    public override int getPriceCode()
    {
        return Movie.NEW_RELEASE;
    }
}

class RegularPrice : Price
{
    public override int getPriceCode()
    {
        return Movie.REGULAR;
    }
}