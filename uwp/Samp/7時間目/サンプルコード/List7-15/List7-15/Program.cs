using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_15
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "Apple", "Banana", "Orange", "Pineapple", "Strawberry"};

            var query = from name in fruit
                        where name.Length >= 7 && name.Substring(0, 1) == "P"
                        select name;

            foreach (var data in query)
            {
                Console.WriteLine(data);
            }
        }
    }
}
