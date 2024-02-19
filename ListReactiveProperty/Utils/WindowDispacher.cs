using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.Utils
{
    internal class WindowDispacher
    {
        //特定の型のウィンドウを閉じる
        public static void CloseWindow<T>()
        {
            var windows = System.Windows.Application.Current.Windows;
            foreach (var window in windows)
            {
                if (window is T)
                {
                    (window as System.Windows.Window)?.Close();
                }
            }
        }
    }
}
