using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample smp = new Sample();
            int id = 7;

            Console.WriteLine("=== 値渡しの例 ===");
            Console.WriteLine($"ShowID1 実行前の id = {id}");
            smp.ShowID1(id);
            Console.WriteLine($"ShowID1 実行後の id = {id}");

            id = 7;

            Console.WriteLine("=== 参照渡しの例 ===");
            Console.WriteLine($"ShowID2 実行前の id = {id}");
            smp.ShowID2(ref id);
            Console.WriteLine($"ShowID2 実行後の id = {id}");
        }
    }
}
