using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> iData = new List<int>();

            // データを追加する
            iData.Add(3);
            iData.Add(4);
            iData.Add(5);

            // データを挿入する
            iData.Insert(0, 1);
            iData.Insert(1, 2);

            // データを削除する
            iData.RemoveAt(iData.Count - 1);    // 最後のデータを削除する
            iData.Remove(2);  // 値が2のデータを削除する

            // iDataから1つずつデータを取得して表示する
            foreach (int num in iData)
            {
                Console.WriteLine(num);
            }
        }
    }
}
