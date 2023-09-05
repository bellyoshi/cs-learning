using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_2
{
    class DVDMember
    {
        // 会員ID管理用変数
        private string _id = string.Empty;

        // 会員ID用プロパティ
        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        // 会員ID表示用メソッド
        public void GetID()
        {
            Console.WriteLine(this._id);
        }
    }
}
