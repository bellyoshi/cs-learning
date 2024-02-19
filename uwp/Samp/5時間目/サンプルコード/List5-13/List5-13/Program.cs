using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_13
{
    class Program
    {
        static void Main(string[] args)
        {
            DVDMember member = new DVDMember();

            member.Age = -100;
            Console.WriteLine($"-100を代入したときのAgeの値は{member.Age}です。");

            member.Age = 50;
            Console.WriteLine($"50を代入したときのAgeの値は{member.Age}です。");

            member.Name = "Bill";
            Console.WriteLine(member.Name);
        }
    }
}
