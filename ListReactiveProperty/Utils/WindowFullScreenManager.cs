using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Reactive.Bindings;
using System.Windows;

namespace ListReactiveProperty.Utils;

internal class WindowFullScreenManager(Window window)
{
    public Rectangle FullScreenWindowLayout => System.Windows.Forms.Screen.AllScreens[ScreenIndex].Bounds;
    public int ScreenIndex { get; set; } = 0;


    private readonly Window window = window;

    public double BakupHeight { get; set; }
    public double BakupWidth { get; set; }

    public double BackupTop { get; set; }
    public double BackupLeft { get; set; }

    private bool _IsFullScreen;
    public bool IsFullScreen
    {
        get => _IsFullScreen;
        set
        {
            if (value)
                SetFullScreen();
            else
                SetNormalScreen();

        }
    }

    void SetFullScreen()
    {
        // Set the window to full screen
        if (!_IsFullScreen)
        {
            this.BakupHeight = window.Height;
            this.BakupWidth = window.Width;
            this.BackupLeft = window.Left;
            this.BackupTop = window.Top;

        }

        SetWindowBound(
            FullScreenWindowLayout.Top,
            FullScreenWindowLayout.Left,
            FullScreenWindowLayout.Height,
            FullScreenWindowLayout.Width);
        

        _IsFullScreen = true;
    }

    private void SetWindowBound(double top, double left, double height, double width)
    {
        window.Top = top;
        window.Left = left;
        window.Height = height;
        window.Width = width;
    }

    void SetNormalScreen()
    {
        if (_IsFullScreen)
        {
            SetWindowBound(BackupTop, BackupLeft, BakupHeight, BakupWidth);
        }

        // Set the window to normal screen
        _IsFullScreen = false;
    }

}
