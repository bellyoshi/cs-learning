using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DVDMember dvdMember = new DVDMember();
            FitnessMember fitnessMember = new FitnessMember();

            dvdMember.ID = "D00001";
            dvdMember.Name = "HIRO";
            dvdMember.Birthday = new DateTime(1972, 6, 19);
            dvdMember.Address = "宮城県仙台市";
            dvdMember.Tel = "090-XXXX-XXXX";
            dvdMember.LastDate = new DateTime(2016, 4, 1);
            dvdMember.ShowMemberData();

            Console.WriteLine("------------------------------");

            fitnessMember.ID = "F00001";
            fitnessMember.Name = "Micro";
            fitnessMember.Birthday = new DateTime(1970, 4, 1);
            fitnessMember.Address = "東京都中央区";
            fitnessMember.Tel = "080-XXXX-XXXX";
            fitnessMember.Weight = 65.3;
            fitnessMember.Height = 175.2;
            fitnessMember.ShowMemberData();
        }
    }
}
