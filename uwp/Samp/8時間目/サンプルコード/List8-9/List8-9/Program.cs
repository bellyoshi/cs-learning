using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List8_9
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberManagement management = new MemberManagement();

            management.Add("Bill");
            management.Add("Steve");
            management.Add("HIRO");

            try
            {
                // 会員ID = 5のメンバーを取得する
                Member member = management.FindMember(5);
            }
            catch (MemberNotFoundException)
            {
                Console.WriteLine("指定した会員は存在しません");
            }
            catch(Exception)
            {
                Console.WriteLine("予期せぬエラーが発生しました。");
            }
        }
    }
}
