using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            DVDMember member = new DVDMember();

            // 戻り値のないメソッドの実行
            member.ShowID();

            // 戻り値のあるメソッド
            string id = member.GetID();

            Console.WriteLine(id);
        }
    }
}
