using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_17
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 3, 5};

            var data = from no in numbers
                       select no;

            numbers.Add(7);

            foreach(int num in data)
            {
                Console.WriteLine(num);
            }
        }
    }
}
