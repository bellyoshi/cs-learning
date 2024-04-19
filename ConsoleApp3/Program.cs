// メインモニタの作業領域情報
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
    Console.WriteLine(mos.Get().Count);

    // 各種プロパティ
    foreach (var m in mos.Get())
    {
        Console.WriteLine(m);
        foreach (var p in m.Properties)
        {
            Console.WriteLine("    - {0}: {1}", p.Name, p.Value);
        }
    }
}