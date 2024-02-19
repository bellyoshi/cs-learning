using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace ListReactiveProperty;
[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}
[StructLayout(LayoutKind.Sequential)]
public struct MONITORINFO
{
    public int cbSize;
    public RECT rcMonitor;
    public RECT rcWork;
    public uint dwFlags;
}

class NativeMethods
{
public delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

[DllImport("user32.dll")]
public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);

[DllImport("user32.dll", CharSet = CharSet.Auto)]
public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

// 他の必要な構造体や定数もここに定義
}
