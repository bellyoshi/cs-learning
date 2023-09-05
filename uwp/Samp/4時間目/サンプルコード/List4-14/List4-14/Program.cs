using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[] { 1, 3, 4, 6, 2, 9, 7, 8, 5, 10 };
            int total = 0;

            foreach (int data in score)
            {
                if (data == 9)
                {
                    continue;
                }

                total += data;
            }

            Console.WriteLine($"スコアの合計は{total}です。");
        }
    }
}
