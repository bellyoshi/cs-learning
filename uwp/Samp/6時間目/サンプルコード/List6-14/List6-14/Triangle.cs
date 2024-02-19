using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_14
{
    /// <summary>
    /// 三角形クラス
    /// </summary>
    class Triangle : Zukei
    {
        // 抽象メソッドをオーバーライド
        public override int CalcArea(int x, int y)
        {
            return x * y / 2;
        }
    }
}
