using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoRental.Tests;


[TestClass()]
public class RentalTests
{
    [TestMethod()]
    public void RentalTest()
    {
        var movie = new Movie("", 0);
        var sut = new Rental(movie, 1);
        Assert.AreEqual(1,sut.getDaysRented());
        Assert.AreEqual(movie,sut.getMovie());
    }
}
