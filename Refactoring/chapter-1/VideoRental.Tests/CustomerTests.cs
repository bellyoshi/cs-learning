using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoRental.Tests;

[TestClass()]
public class CustomerTests
{
    [TestMethod()]
    public void CustomerTest()
    {
        var sut = new Customer("name");
        Assert.AreEqual("name", sut.Name);
    }

    [TestMethod()]
    public void addRentalTest()
    {
        var sut = new Customer("");
        Rental rental = new Rental(new Movie("", 0), 0);
        sut.addRental(rental);
    }

    [TestMethod()]
    public void statementTest()
    {
        var sut = new Customer("");
        Assert.AreEqual("Rental Record for \n" +
                        "Amount owed in 0\n" +
                        "You earned 0 frequent renter points", sut.statement());
    }

    [TestMethod]
    public void statementMovieTest()
    {
        var sut = new Customer("customer name");
        sut.addRental(new Rental(new Movie("movie1", Movie.REGULAR), 7));
        sut.addRental(new Rental(new Movie("movie2", Movie.NEW_RELEASE), 7));
        Assert.AreEqual("Rental Record for customer name\n" +
            "\tmovie1\t9.5\n" +
            "\tmovie2\t21\n" +
            "Amount owed in 30.5\n" +
            "You earned 3 frequent renter points", sut.statement());
    }

    [TestMethod()]
    public void htmlStatementTest()
    {
        var sut = new Customer("customer name");
        sut.addRental(new Rental(new Movie("movie1", Movie.REGULAR), 7));
        sut.addRental(new Rental(new Movie("movie2", Movie.NEW_RELEASE), 7));
        Assert.AreEqual("<H1>Rental Record for <EM>customer name</EM></H1>\n"+
            "<P>movie1:9.5<BR>\n"+
            "movie2:21<BR>\n</P>" +
            "<P>You owe <EM>30.5</EM></P>\n" +
            "<P>On this rental you earned <EM>3</EM>frequent renter points</P>"
            , sut.htmlStatement());
    }
}
