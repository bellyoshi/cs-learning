using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod()]
        public void CustomerTest()
        {
            var sut = new Customer("name");
            Assert.AreEqual("name", sut.getName());
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
                "\tmovie1\n" +
                "\tmovie2\n" +
                "Amount owed in 30.5\n" +
                "You earned 3 frequent renter points", sut.statement());
        }
    }
}