﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[] { 1, 3, 4, 6, 2, 9, 7, 8, 5, 10 };
            int total = 0;
            int i = 0;

            while (i < score.Length)
            {
                total += score[i];
                i++;
            }

            Console.WriteLine($"スコアの合計は{total}です。");
        }
    }
}
