using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_16
{
    class Program
    {
        // 列挙型 CRUDの定義
        enum CRUD
        {
            CREATE,
            READ,
            UPDATE,
            DELETE
        }

        static void Main(string[] args)
        {
            // 列挙型 CRUD の変数を作成し、CREATEで初期化
            CRUD operate = CRUD.CREATE;

            Console.Write("現在の操作ステータスは{0}です。", operate);
        }
    }
}
