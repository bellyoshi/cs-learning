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
    public class MovieTests
    {
        [TestMethod()]
        public void MovieTest()
        {
            var sut = new Movie("title", 1);
            Assert.AreEqual("title", sut.getTitle());
            Assert.AreEqual(1, sut.getPriceCode());
        }

        [TestMethod()]
        public void setPriceCodeTest()
        {
            var sut = new Movie("", 0);
            sut.setPriceCode(1);
            Assert.AreEqual(1, sut.getPriceCode());
        }

        [TestMethod()]
        public void MovieREGULAR_getChargeTest()
        {
            var sut = new Movie("", Movie.REGULAR);
            Assert.AreEqual(2, sut.getCharge(1));
            Assert.AreEqual(2,sut.getCharge(2));
            Assert.AreEqual(3.5,sut.getCharge(3));
            
        }
        [TestMethod()]
        public void MovieCHILDRENS_getChargeTest()
        {
            var sut = new Movie("", Movie.CHILDRENS);
            Assert.AreEqual(1.5, sut.getCharge(1));
            Assert.AreEqual(1.5, sut.getCharge(3));
            Assert.AreEqual(3, sut.getCharge(4));

        }

        [TestMethod()]
        public void MovieNEW_RELEASE_getChargeTest()
        {
            var sut = new Movie("", Movie.NEW_RELEASE);
            Assert.AreEqual(3, sut.getCharge(1));
            Assert.AreEqual(6, sut.getCharge(2));

        }
    }
}