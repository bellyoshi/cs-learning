using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_5
{
    class DVDMember
    {
        // 会員ID管理用変数
        private string _id = "00001";

        /// <summary>
        /// 会員IDを表示する
        /// </summary>
        public void ShowID()
        {
            Console.WriteLine($"会員IDは{this._id}です。");
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
