using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int seisu = 3;

            // 文字列中への変数の埋め込み例1
            Console.WriteLine($"変数seisuの値は{seisu}です。");

            // 文字列中への変数の埋め込み例2
            string name = "HIRO";
            string msg = $"{name}さん、こんにちは";

            Console.WriteLine(msg);
        }
    }
}
