using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_3
{
    class DVDMember
    {
        // 会員ID管理用変数（フィールド）
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

        // 会員ID取得用メソッド
        public void GetID()
        {
            Console.WriteLine(this._id);
        }
    }
}
