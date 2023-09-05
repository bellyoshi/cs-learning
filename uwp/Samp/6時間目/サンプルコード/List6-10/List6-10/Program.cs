using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_10
{
    class Program
    {
        static void Main(string[] args)
        {
            DVDMember dvdMember = new DVDMember();

            dvdMember.ID = "D00001";
            dvdMember.Name = "HIRO";
            dvdMember.Birthday = new DateTime(1972, 6, 19);
            dvdMember.Address = "宮城県仙台市";
            dvdMember.Tel = "090-XXXX-XXXX";
            dvdMember.LastDate = new DateTime(2016, 4, 1);

            dvdMember.ShowMemberData();
        }
    }
}
