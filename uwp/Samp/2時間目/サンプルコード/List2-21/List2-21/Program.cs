using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string sNo1 = "2016";
            string sNo2 = "1.23";
            int iNo = 0;
            double dNo = 0.0;

            // int型への変換を試みる
            if ( int.TryParse(sNo1, out iNo)  == false )
            {
                Console.WriteLine("int型に変換できませんでした。");
            }

            if ( double.TryParse(sNo2, out dNo ) == false )
            {
                Console.WriteLine("double型に変換できませんでした。");
            }

        }
    }
}
