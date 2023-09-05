using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 3, 5 };

            // ToList()で即時実行する
            var data = (from no in numbers
                       select no).ToList();

            numbers.Add(7);

            foreach (int num in data)
            {
                Console.WriteLine(num);
            }
        }
    }
}
