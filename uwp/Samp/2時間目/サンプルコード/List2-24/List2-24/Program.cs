using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_24
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1次元配列の宣言と初期化
            string[] fruit = new string[]{ "リンゴ","ミカン","バナナ" };

            // 2次元配列の宣言と初期化
            int[,] array2D = new int[,]{
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 }
            };

            // 3次元配列の宣言と初期化
            int[,,] array3D = new int[,,]{
                { 
                    { 1, 2, 3 }, 
                    { 4, 5, 6 }
                },
                {
                    { 7, 8, 9 }, 
                    { 10, 11, 12 }
                } 
            };
        }
    }
}
