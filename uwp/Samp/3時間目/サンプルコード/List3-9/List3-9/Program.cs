using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string gender = "男性";
            int age = 25;
            bool isMale = true;

            // genderが「男性」かつageが20以上
            bool ans = (gender == "男性" && age >= 20);
            Console.WriteLine($"男性かつ20歳以上 の演算結果 {ans}");

            // genderが「女性」またはageが20以上
            ans = (gender == "女性" || age >= 20);
            Console.WriteLine($"女性または20歳以上 の演算結果 {ans}");

            // isMaleの否定（反転する）
            Console.WriteLine($"!isMale の演算結果 {!isMale}");
        }

    }
}
