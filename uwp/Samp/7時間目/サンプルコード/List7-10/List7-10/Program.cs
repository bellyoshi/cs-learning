using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> fruit = new Dictionary<int, string>();

            fruit[1] = "リンゴ";
            fruit[2] = "ミカン";
            fruit[3] = "バナナ";

            // キー = 2 をイチゴに変更
            fruit[2] = "イチゴ";
        }
    }
}
