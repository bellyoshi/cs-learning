using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_7
{
    class Member
    {
        // クラス名称
        private const string CLASS_NAME = "Member";

        // 入会日
        protected DateTime JoinDate { get; set; }


        /// <summary>
        /// 会員番号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 氏名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 会員データ表示
        /// </summary>
        public void ShowMemberData()
        {
            Console.WriteLine($"会員番号:{this.ID}");
            Console.WriteLine($"氏　　名:{this.Name}");
            Console.WriteLine($"生年月日:{this.Birthday.ToShortDateString()}");
            Console.WriteLine($"住　　所:{this.Address}");
            Console.WriteLine($"電話番号:{this.Tel}");
        }
    }
}
