using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = 56.2;   // 体重56.2kg
            double height = 1.65;   // 身長1.65m

            double bmi = weight / (height * height);

            Console.WriteLine($"入力した体重={weight}kg, 身長={height}m");
            Console.WriteLine($"あなたのBMI = {bmi}");

            if (bmi < 25)
            {
                Console.WriteLine("肥満度指数は標準以下です。");
            }
        }
    }
}
