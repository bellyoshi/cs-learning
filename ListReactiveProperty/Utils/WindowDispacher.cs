using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;

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

        public static T GetWindow<T>() where T : Window, new()
        {
            var windows = System.Windows.Application.Current.Windows.OfType<T>();
            return windows.FirstOrDefault() ?? new T();
        }

        public static void ShowWindow<T>() where T : Window, new()
        {
            var window = GetWindow<T>();
            window.Show();
        }
    }
}
