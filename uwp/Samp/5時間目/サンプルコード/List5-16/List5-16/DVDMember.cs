using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_16
{
    class DVDMember
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        DVDMember()
        {
            Console.WriteLine("コンストラクタが呼び出されました");
        }

        /// <summary>
        /// DVDMember
        /// </summary>
        ~DVDMember()
        {
            Console.WriteLine("デストラクタが呼び出されました");
        }
    }
}
