using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int getDaysRented() => _daysRented;
       
        public Movie getMovie() => _movie;

        internal double getCharge()
        
            => _movie.getCharge(_daysRented);
        

        internal int getFrequentRenterPoints()
        {
            if (getMovie().getPriceCode() == Movie.NEW_RELEASE && getDaysRented() > 1)
                return 2;
            return 1;
        }
    }
}
