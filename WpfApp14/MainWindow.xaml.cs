using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;

namespace WpfApp14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Console.WriteLine("WorkArea_幅　 : " + SystemParameters.WorkArea.Width);
            Console.WriteLine("WorkArea_高さ : " + SystemParameters.WorkArea.Height);
            Console.WriteLine("WorkArea_左辺 : " + SystemParameters.WorkArea.Left);
            Console.WriteLine("WorkArea_上辺 : " + SystemParameters.WorkArea.Top);
            Console.WriteLine("WorkArea_左上 : " + SystemParameters.WorkArea.TopLeft);

            // マルチモニタ時の作業領域情報
            Console.WriteLine("VirtualScreen_幅　　 : " + SystemParameters.VirtualScreenWidth);
            Console.WriteLine("VirtualScreen_高さ　 : " + SystemParameters.VirtualScreenHeight);
            Console.WriteLine("VirtualScreen_左辺　 : " + SystemParameters.VirtualScreenLeft);
            Console.WriteLine("VirtualScreen_上辺　 : " + SystemParameters.VirtualScreenTop);

            // System.Management (WMI) を使用すればモニタ数や各モニタの詳細を取得できる
            using (var mos = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity WHERE Service=\"monitor\""))
            {
                // 使用中のモニタ数
                System.Diagnostics.Debug.WriteLine(mos.Get().Count);

                // 各種プロパティ
                foreach (var m in mos.Get())
                {
                    Console.WriteLine(m);
                    foreach (var p in m.Properties)
                    {
                        System.Diagnostics.Debug.WriteLine("    - {0}: {1}", p.Name, p.Value);
                    }
                }
            }
        }
    }
}