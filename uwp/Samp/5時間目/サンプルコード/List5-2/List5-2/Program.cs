using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // インスタンス生成
            DVDMember member = new DVDMember();

            member.ID = "000-00001";

            string strID = member.GetID();

            Console.WriteLine(strID);
        }
    }
}
