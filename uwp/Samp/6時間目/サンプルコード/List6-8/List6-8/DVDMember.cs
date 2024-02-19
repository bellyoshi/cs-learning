using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_8
{
    class DVDMember : Member
    {
        // 基底クラス名を表示する
        public void ShowBaseClass()
        {
            // 基底クラスで定義された CLASS_NAME は privateなので使用できない
            //Console.WriteLine($"基底クラスは{CLASS_NAME}です。");
        }

        // 会員登録日を表示する
        public void ShowJoinDate()
        {
            string strJoinDate = JoinDate.ToShortDateString();
            Console.WriteLine($"会員登録日は{strJoinDate}です。");
        }

        /// <summary>
        /// 会員データ表示 DVDmemberクラス版
        /// </summary>
        public override void ShowMemberData()
        {
            // 基本クラスの ShowMemberData を呼び出し
            base.ShowMemberData();

            Console.WriteLine($"最終レンタル日:{this.LastDate.ToShortDateString()}");
        }

        /// <summary>
        /// 最終レンタル日
        /// </summary>
        public DateTime LastDate { get; set; }
    }
}
