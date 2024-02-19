using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 追加
using System.IO;

namespace List8_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // ファイル読み取りデータ用変数
            string textData = string.Empty;

            Console.WriteLine("読み取りたいファイルのパスを入力してください。");

            // ユーザーが入力したパスをstrPathに代入
            string strPath = Console.ReadLine();

            try
            {
                // ファイルを読み取りtextDataに代入
                textData = System.IO.File.ReadAllText(strPath);

                // 読み取った内容を表示
                Console.WriteLine(textData);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("パスに誤りがあります。");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ファイルが存在しません。");
            }
            catch (Exception e)
            {
                Console.WriteLine("予期せぬエラーが発生しました。");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("処理を終了します。");
            }
        }
    }
}
