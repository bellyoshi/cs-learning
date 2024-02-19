using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "Orange", "Banana", "Apple", "Strawberry" , "Pineapple" };

            var query = from name in fruit
                        orderby name ascending
                        select name;

            foreach (var data in query)
            {
                Console.WriteLine(data);
            }
        }
    }
}
