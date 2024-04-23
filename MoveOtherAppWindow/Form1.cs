using System.Runtime.InteropServices;
using System.Text;

namespace MoveOtherAppWindow;


public partial class Form1 : Form
{
    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public int Width => Right - Left;
        public int Height => Bottom - Top;
    }

    [DllImport("user32.dll")]
    private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);



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

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindowVisible(IntPtr hWnd);
    struct INPUT
    {
        public int type;
        public InputUnion U;
        public static int Size => Marshal.SizeOf(typeof(INPUT));
    }

    [StructLayout(LayoutKind.Explicit)]
    struct InputUnion
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
    }

    struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }



    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);


    public Form1()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        lstWindows.Items.Clear();
        EnumWindows((hWnd, lParam) =>
        {
            if (IsWindowVisible(hWnd))
            {
                StringBuilder title = new StringBuilder(256);
                GetWindowText(hWnd, title, title.Capacity);
                if (title.ToString().StartsWith(txtSearchTitle.Text))
                {
                    lstWindows.Items.Add($"{hWnd} - {title}");
                }
            }
            return true;
        }, IntPtr.Zero);
    }

    private void btnMoveToSecondMonitor_Click(object sender, EventArgs e)
    {
        if (lstWindows.SelectedItem != null)
        {
            var selectedWindowInfo = lstWindows.SelectedItem.ToString().Split('-')[0].Trim();
            IntPtr hWnd = new IntPtr(Convert.ToInt32(selectedWindowInfo));

            // ���j�^�[�̏����擾
            if (Screen.AllScreens.Length > 1)
            {
                // �Z�J���h���j�^�[�����肵�Ď擾�i�C���f�b�N�X�� 1 �ł��j
                Screen secondMonitor = Screen.AllScreens[1];
                Rectangle monitorArea = secondMonitor.WorkingArea;

                // �E�C���h�E�̃T�C�Y���擾�iMoveWindow ���g���ꍇ�͕K�v�j
                RECT rect;
                GetWindowRect(hWnd, out rect);

                // �E�C���h�E���Z�J���h���j�^�[�̍���Ɉړ�
                MoveWindow(hWnd, monitorArea.X, monitorArea.Y, rect.Width, rect.Height, true);
            }
            else
            {
                MessageBox.Show("�Z�J���h���j�^�[�����o����܂���ł����B");
            }
        }
        else
        {
            MessageBox.Show("���X�g����E�C���h�E��I�����Ă��������B");
        }
    }

    private void btnDoubleClick_Click(object sender, EventArgs e)
    {
        if (lstWindows.SelectedItem != null)
        {
            var selectedWindowInfo = lstWindows.SelectedItem.ToString().Split('-')[0].Trim();
            IntPtr hWnd = new IntPtr(Convert.ToInt32(selectedWindowInfo));

            // PerformDoubleClick ���\�b�h���Ăяo���ă_�u���N���b�N���V�~�����[�g
            PerformDoubleClick(hWnd);
        }
        else
        {
            MessageBox.Show("���X�g����E�C���h�E��I�����Ă��������B");
        }
    }


    private void PerformDoubleClick(IntPtr hWnd)
    {
        if (hWnd != IntPtr.Zero)
        {
            // �E�C���h�E�̈ʒu�Ƒ傫�����擾
            GetWindowRect(hWnd, out RECT rect);

            // �E�C���h�E�̒��S���v�Z
            int centerX = (rect.Left + rect.Right) / 2;
            int centerY = (rect.Top +  rect.Bottom) / 2;

            // �}�E�X�J�[�\�����E�C���h�E�̒��S�Ɉړ�
            SetCursorPos(centerX, centerY);

            // �}�E�X�̍��{�^���Ń_�u���N���b�N
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        else
        {
            MessageBox.Show("�w�肳�ꂽ�E�C���h�E��������܂���B");
        }
    }

}

