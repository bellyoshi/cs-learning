using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;

            Console.WriteLine("整数を入力してください。");
            string strNo = Console.ReadLine();

            try
            {
                x = int.Parse(strNo);

                Console.WriteLine("整数を受け取りました。");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("処理を終了します。");
            }
        }
    }
}
