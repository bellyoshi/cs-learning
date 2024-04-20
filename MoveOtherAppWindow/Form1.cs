using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MoveOtherAppWindow;


public partial class Form1 : Form
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }

    [DllImport("user32.dll")]
    private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);




    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

    private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const uint MOUSEEVENTF_LEFTUP = 0x0004;

    public Form1()
    {
        InitializeComponent();
    }


    private bool isMoved = false;



    private void btnMoveToSecondMonitor_Click(object sender, EventArgs e)
    {
        IntPtr hWnd = FindWindow(null, textBox1.Text);
        if (hWnd != IntPtr.Zero)
        {
            GetWindowRect(hWnd, out RECT originalRect); // 元のウインドウ位置を保存
            isMoved = true;
            // セカンドモニターを探す、存在しない場合は主モニターを使用
            Screen? targetScreen
                = Screen.AllScreens.FirstOrDefault(s => !s.Primary) ?? Screen.PrimaryScreen;

            if (targetScreen != null)
                MoveWindow(hWnd, targetScreen.WorkingArea.Left, targetScreen.WorkingArea.Top, targetScreen.WorkingArea.Width, targetScreen.WorkingArea.Height, true);
        }
        else
        {
            MessageBox.Show("ウインドウが見つかりません。");
        }
    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
        RECT originalRect = new();
        originalRect.Right = int.Parse(RightTextBox.Text);
        originalRect.Bottom = int.Parse(BottomTextBox.Text);
        originalRect.Left = int.Parse(LeftTexBox.Text);
        originalRect.Top = int.Parse(TopTextBox.Text);


        IntPtr hWnd = FindWindow(null, textBox1.Text);
        if (hWnd != IntPtr.Zero)
        {
            MoveWindow(hWnd, originalRect.Left, originalRect.Top, 
                originalRect.Right - originalRect.Left, 
                originalRect.Bottom - originalRect.Top, true);
        }
        
    }

    private void btnDoubleClick_Click(object sender, EventArgs e)
    {
        IntPtr hWnd = FindWindow(null, textBox1.Text);
        if (hWnd != IntPtr.Zero)
        {
            // ウインドウの位置と大きさを取得
            GetWindowRect(hWnd, out RECT rect);

            // ウインドウの中心を計算
            int centerX = (rect.Left + rect.Right) / 2;
            int centerY = (rect.Top + rect.Bottom) / 2;

            // マウスカーソルをウインドウの中心に移動
            SetCursorPos(centerX, centerY);

            // マウスの左ボタンでダブルクリック
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        else
        {
            MessageBox.Show("指定されたウインドウが見つかりません。");
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        btnMoveToSecondMonitor_Click(sender, e);
        btnDoubleClick_Click(sender, e);
    }

    private void button3_Click(object sender, EventArgs e)
    {

        IntPtr hWnd = FindWindow(null, textBox1.Text);
        if (hWnd == IntPtr.Zero) return;
        
        GetWindowRect(hWnd, out RECT originalRect); // 元のウインドウ位置を保存
        BottomTextBox.Text = originalRect.Bottom.ToString();
        LeftTexBox.Text = originalRect.Left.ToString();
        RightTextBox.Text = originalRect.Right.ToString();
        TopTextBox.Text = originalRect.Top.ToString();

        

    }
}

