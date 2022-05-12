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
            var sut = new Movie("",0);
            sut.setPriceCode(1);
            Assert.AreEqual(1, sut.getPriceCode());
        }
    }
}