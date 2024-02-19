using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_7
{
    class DVDMember
    {
        // 会員ID管理用変数
        private string _id = "00001";

        /// <summary>
        /// 会員IDを表示する
        /// </summary>
        /// <param name="msg">会員IDの前に表示する文字列</param>
        /// <param name="showDate">今日の日付を表示する場合はtrue</param>
        public void ShowID(string msg, bool showDate)
        {
            if (showDate)
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }

            Console.WriteLine($"{msg}{this._id}");
        }

        /// <summary>
        /// 会員IDを取得する
        /// </summary>
        /// <returns>会員ID</returns>
        public string GetID()
        {
            return "会員ID:" + this._id;
        }
    }
}
