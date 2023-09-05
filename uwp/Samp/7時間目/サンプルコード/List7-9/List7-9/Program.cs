using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> fruit = new Dictionary<int, string>();

            fruit.Add(1, "リンゴ");
            fruit.Add(2, "ミカン");
            fruit.Add(3, "バナナ");

            // キーが2の果物を表示
            Console.WriteLine(fruit[2]);

            // すべてのキーを表示
            foreach(var key in fruit.Keys)
            {
                Console.WriteLine(key);
            }

            // すべての値を表示
            foreach(var value in fruit.Values)
            {
                Console.WriteLine(value);
            }

            // キーと値のペアを表示
            foreach(var dic in fruit)
            {
                Console.WriteLine($"key={dic.Key}, value={dic.Value}");
            }
        }
    }
}
