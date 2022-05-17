namespace VideoRental;

abstract class Price 
{
    abstract public int getPriceCode();

    abstract public double getCharge(int daysRented);

    
}

class ChildrensPrice : Price
{
    public override double getCharge(int daysRented)
    {
        if (daysRented > 3)
            return 1.5 +  (daysRented - 3) * 1.5;
        return 1.5;
    }

    public override int getPriceCode()
    {
        return Movie.CHILDRENS;
    }
}

class NewReleasePrice : Price
{
    public override double getCharge(int daysRented)
    {
       return daysRented * 3;
    }

    public override int getPriceCode()
    {
        return Movie.NEW_RELEASE;
    }
}

class RegularPrice : Price
{
    public override double getCharge(int daysRented)
    {

        if (daysRented > 2)
            return 2 + (daysRented - 2) * 1.5;
        return 2;

        
    }

    public override int getPriceCode()
    {
        return Movie.REGULAR;
    }
}