using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_7
{
    class Program
    {
        static void Main(string[] args)
        {
            DVDMember member = new DVDMember();

            member.ShowID(string.Empty, false);

            Console.WriteLine("-----------");

            member.ShowID("会員ID:", true);
        }
    }
}
