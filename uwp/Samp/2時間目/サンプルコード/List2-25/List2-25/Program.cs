using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_25
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1次元配列の宣言と初期化
            string[] fruit = new string[] { "リンゴ", "ミカン", "バナナ" };

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

            // 1次元配列のデータの表示（ミカンを表示）
            Console.WriteLine($"fruit[1] = {fruit[1]}");

            // 2次元配列のデータを表示
            Console.WriteLine($"array2D[0, 1] = {array2D[0, 1]}");   // 2を表示
            Console.WriteLine($"array2D[1, 4] = {array2D[1, 4]}");   // 10を表示

            // 3次元配列のデータを表示
            Console.WriteLine($"array3D[0, 0, 1] = {array3D[0, 0, 1]}");    // 2を表示
            Console.WriteLine($"array3D[0, 1, 2] = {array3D[0, 1, 2]}");    // 6を表示
            Console.WriteLine($"array3D[1, 0, 0] = {array3D[1, 0, 0]}");    // 7を表示
            Console.WriteLine($"array3D[1, 1, 0] = {array3D[1, 1, 0]}");    // 10を表示

            // データの代入
            fruit[1] = "イチゴ";
            array2D[0, 1] = 20;
            array2D[1, 4] = 100;
            array3D[0, 0, 1] = 20;
            array3D[0, 1, 2] = 60;
            array3D[1, 0, 0] = 70;
            array3D[1, 1, 0] = 100;
        }
    }
}
