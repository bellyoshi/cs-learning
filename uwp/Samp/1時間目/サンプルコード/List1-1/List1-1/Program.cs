using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO ここに消費税計算処理を記述する。

            // HACK 以下のコードはリファクタリングする必要あり
            double tax = 100 * 1.08;
            if (tax > 100)
            {
                Console.WriteLine(tax);
            }

            // UNDONE for文の中身を後で実装する 
            for ( int i = 0; i < 10; i++ )
            {

            }

        }
    }
}
