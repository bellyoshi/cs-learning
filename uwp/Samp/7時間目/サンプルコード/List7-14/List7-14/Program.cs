using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "Apple", "Banana", "Orange" };

            var query = from name in fruit
                        where name.Length >= 6
                        select name;

            foreach (var data in query)
            {
                Console.WriteLine(data);
            }
        }
    }
}
