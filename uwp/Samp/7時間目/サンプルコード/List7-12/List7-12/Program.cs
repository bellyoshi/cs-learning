using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "Apple", "Banana", "Orange" };

            var query = from name in fruit
                        select name;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }
    }
}
