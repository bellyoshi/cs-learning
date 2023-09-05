using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_11
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> fruit = new SortedList<int, string>();

            fruit[3] = "Orange";
            fruit[5] = "Strawberry";
            fruit[1] = "Apple";
            fruit[4] = "Banana";
            fruit[2] = "Grapes";

            Console.WriteLine("すべてのキーを表示");
            foreach (var key in fruit.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("すべての値を表示");
            foreach (var value in fruit.Values)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("すべてのキーと値のペアを表示");
            foreach (var dic in fruit)
            {
                Console.WriteLine($"key={dic.Key}, value={dic.Value}");
            }
        }
    }
}
