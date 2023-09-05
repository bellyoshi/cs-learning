using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isChecked = false;

            string msg = isChecked ? "男性" : "女性";

            Console.WriteLine($"チェック状態は {isChecked} なので {msg}");
        }
    }
}
