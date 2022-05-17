namespace VideoRental;

abstract class Price 
{
    abstract public int getPriceCode();

    abstract public double getCharge(int daysRented);
    
    internal double getCharge(int daysRented, int basicDays, double basicCharge, double chargeOfday)
    {
        var charge = basicCharge;
        if (daysRented > basicDays)
            charge +=  (daysRented - basicDays) * chargeOfday;
        return charge;

    }

}

class ChildrensPrice : Price
{
    public override double getCharge(int daysRented)
        => getCharge(daysRented, 3, 1.5, 1.5);       
    

    public override int getPriceCode()
    =>
         Movie.CHILDRENS;
    
}

class NewReleasePrice : Price
{
    public override double getCharge(int daysRented)
       => daysRented * 3;
    

    public override int getPriceCode()
    =>
         Movie.NEW_RELEASE;
    
}

class RegularPrice : Price
{
    public override double getCharge(int daysRented)
    => getCharge(daysRented, 2, 2.0, 1.5);

        

    public override int getPriceCode()
    =>
         Movie.REGULAR;
    
}