using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_10
{
    class Program
    {
        static void Main(string[] args)
        {
            DVDMember member = new DVDMember();

            member.ShowID("会員ID");
            member.ShowID("会員ID", false);
            member.ShowID("会員ID", true);
        }
    }
}
