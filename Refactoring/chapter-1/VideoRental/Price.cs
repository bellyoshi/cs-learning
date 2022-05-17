namespace VideoRental;

abstract class Price 
{
    abstract public int getPriceCode();
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