using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "Apple", "Banana", "Orange" };

            var query = from name in fruit
                        select new { Name = name, Len = name.Length };

            foreach (var data in query)
            {
                Console.WriteLine($"{data.Name} の文字数は {data.Len }です。");
            }
        }
    }
}
