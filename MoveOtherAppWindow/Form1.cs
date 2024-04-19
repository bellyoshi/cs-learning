using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MoveOtherAppWindow;


public partial class Form1 : Form
{
    [DllImport("user32.dll")]
    private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);




    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

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

    // �E�C���h�E�̏����ʒu���L�^���邽�߂̕ϐ�
    private Rectangle originalRect;
    private bool isMoved = false;



    private void btnMoveToSecondMonitor_Click(object sender, EventArgs e)
    {
        IntPtr hWnd = FindWindow(null, textBox1.Text);
        if (hWnd != IntPtr.Zero)
        {
            GetWindowRect(hWnd, out originalRect); // ���̃E�C���h�E�ʒu��ۑ�
            isMoved = true;
            // �Z�J���h���j�^�[��T���A���݂��Ȃ��ꍇ�͎僂�j�^�[���g�p
            Screen? targetScreen
                = Screen.AllScreens.FirstOrDefault(s => !s.Primary) ?? Screen.PrimaryScreen;

            if (targetScreen != null)
                MoveWindow(hWnd, targetScreen.WorkingArea.Left, targetScreen.WorkingArea.Top, targetScreen.WorkingArea.Width, targetScreen.WorkingArea.Height, true);
        }
        else
        {
            MessageBox.Show("�E�C���h�E��������܂���B");
        }
    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
        if (isMoved)
        {
            IntPtr hWnd = FindWindow(null, textBox1.Text);
            if (hWnd != IntPtr.Zero)
            {
                MoveWindow(hWnd, originalRect.Left, originalRect.Top, originalRect.Width, originalRect.Height, true);
            }
        }
    }

    private void btnDoubleClick_Click(object sender, EventArgs e)
    {
        IntPtr hWnd = FindWindow(null, textBox1.Text);
        if (hWnd != IntPtr.Zero)
        {
            // �E�C���h�E�̈ʒu�Ƒ傫�����擾
            GetWindowRect(hWnd, out Rectangle rect);

            // �E�C���h�E�̒��S���v�Z
            int centerX = rect.Left + (rect.Width - rect.Left) / 2;
            int centerY = rect.Top + (rect.Height - rect.Top) / 2;

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

    private void button2_Click(object sender, EventArgs e)
    {
        btnMoveToSecondMonitor_Click(sender, e);
        btnDoubleClick_Click(sender, e);
    }
}

