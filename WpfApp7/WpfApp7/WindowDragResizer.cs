using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace WpfApp7;

public class WindowDragResizer
{
    private readonly Window _resizeWindow;
    private Point _initialMousePos;
    private Size _initialWindowSize;
    private Point _initialWindowPosition;
    private ResizeDirection _resizeDirection;
    private int edgeTolerance = 10;

    public WindowDragResizer(Window resizeWindow, int edgeTolerance)
    {
        this.edgeTolerance = edgeTolerance;
        _resizeWindow = resizeWindow;

        // ウィンドウイベントの登録
        _resizeWindow.MouseMove += ResizeWindow_MouseMove;
        _resizeWindow.MouseDown += ResizeWindow_MouseDown;
        _resizeWindow.MouseUp += ResizeWindow_MouseUp;
        _resizeWindow.MouseLeave += ResizeWindow_MouseLeave;
    }

    private void ResizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            _initialMousePos = e.GetPosition(_resizeWindow);
            _initialWindowSize = new Size(_resizeWindow.Width, _resizeWindow.Height);
            _initialWindowPosition = new Point(_resizeWindow.Left, _resizeWindow.Top);
            _resizeDirection = DetermineResizeDirection(_initialMousePos);
            if (_resizeDirection != ResizeDirection.None)
            {
                _resizeWindow.CaptureMouse();
            }
        }
    }

    private void GetInitialiBound(MouseButtonEventArgs e)
    {

    }

    private void ResizeWindow_MouseMove(object sender, MouseEventArgs e)
    {
        if (_resizeWindow.IsMouseCaptured && e.LeftButton == MouseButtonState.Pressed)
        {
            ApplyResize(e.GetPosition(_resizeWindow));
            _initialWindowSize = new Size(_resizeWindow.Width, _resizeWindow.Height);
            _initialWindowPosition = new Point(_resizeWindow.Left, _resizeWindow.Top);
         }
        else
        {
            UpdateCursor(e.GetPosition(_resizeWindow));
        }
    }

    private void ResizeWindow_MouseUp(object sender, MouseButtonEventArgs e)
    {
        _resizeWindow.ReleaseMouseCapture();
    }

    private void ResizeWindow_MouseLeave(object sender, MouseEventArgs e)
    {
        if (!_resizeWindow.IsMouseCaptured)
        {
            _resizeWindow.Cursor = Cursors.Arrow;
        }
    }

    private ResizeDirection DetermineResizeDirection(Point position)
    {
 
        bool onTop = position.Y <= edgeTolerance;
        bool onLeft = position.X <= edgeTolerance;
        bool onBottom = position.Y >= _resizeWindow.ActualHeight - edgeTolerance;
        bool onRight = position.X >= _resizeWindow.ActualWidth - edgeTolerance;

        if (onTop && onLeft) return ResizeDirection.TopLeft;
        if (onTop && onRight) return ResizeDirection.TopRight;
        if (onBottom && onLeft) return ResizeDirection.BottomLeft;
        if (onBottom && onRight) return ResizeDirection.BottomRight;
        if (onTop) return ResizeDirection.Top;
        if (onLeft) return ResizeDirection.Left;
        if (onBottom) return ResizeDirection.Bottom;
        if (onRight) return ResizeDirection.Right;

        return ResizeDirection.None;
    }

    private void ApplyResize(Point currentMousePos)
    {
        if (_resizeDirection == ResizeDirection.None) return;

        double dx = currentMousePos.X - _initialMousePos.X;
        double dy = currentMousePos.Y - _initialMousePos.Y;


        switch (_resizeDirection)
        {
            case ResizeDirection.Right:
                _resizeWindow.Width = Math.Max(_resizeWindow.MinWidth, _initialWindowSize.Width + dx);
                _initialMousePos = new Point(_resizeWindow.Width, currentMousePos.Y);
                break;
            case ResizeDirection.Bottom:
                _resizeWindow.Height = Math.Max(_resizeWindow.MinHeight, _initialWindowSize.Height + dy);
                _initialMousePos = new Point(currentMousePos.Y, _resizeWindow.Height);
                break;
            case ResizeDirection.Left:
                double newWidth = Math.Max(_resizeWindow.MinWidth, _initialWindowSize.Width - dx);
                if (newWidth != _resizeWindow.Width)
                {
                    _resizeWindow.Left = _initialWindowPosition.X + dx;
                    _resizeWindow.Width = newWidth;
                    _initialMousePos = new Point(0, currentMousePos.Y);

                }
                break;
            case ResizeDirection.Top:
                double newHeight = Math.Max(_resizeWindow.MinHeight, _initialWindowSize.Height - dy);
                if (newHeight != _resizeWindow.Height)
                {

                    _resizeWindow.Top = _initialWindowPosition.Y + dy;
                    _resizeWindow.Height = newHeight;
                    _initialMousePos = new Point(currentMousePos.X, 0);
                }
                break;
            case ResizeDirection.TopLeft:
                newWidth = Math.Max(_resizeWindow.MinWidth, _initialWindowSize.Width - dx);
                newHeight = Math.Max(_resizeWindow.MinHeight, _initialWindowSize.Height - dy);
                if (newWidth != _resizeWindow.Width)
                {
                    _resizeWindow.Left = _initialWindowPosition.X + dx;
                    _resizeWindow.Width = newWidth;
                    _initialMousePos = new(0, 0);


                }
                if (newHeight != _resizeWindow.Height)
                {
                    _resizeWindow.Top = _initialWindowPosition.Y + dy;
                    _resizeWindow.Height = newHeight;
                    _initialMousePos = new(0, 0);

                }
                break;
            case ResizeDirection.TopRight:
                _resizeWindow.Width = Math.Max(_resizeWindow.MinWidth, _initialWindowSize.Width + dx);
                newHeight = Math.Max(_resizeWindow.MinHeight, _initialWindowSize.Height - dy);
                if (newHeight != _resizeWindow.Height)
                {
                    _resizeWindow.Top = _initialWindowPosition.Y + dy;
                    _resizeWindow.Height = newHeight;
                    _initialMousePos = new Point(_resizeWindow.Width, 0);
                }
                break;
            case ResizeDirection.BottomLeft:
                newWidth = Math.Max(_resizeWindow.MinWidth, _initialWindowSize.Width - dx);
                _resizeWindow.Height = Math.Max(_resizeWindow.MinHeight, _initialWindowSize.Height + dy);
                if (newWidth != _resizeWindow.Width)
                {
                    _resizeWindow.Left = _initialWindowPosition.X + dx;
                    _resizeWindow.Width = newWidth;
                    _initialMousePos = new Point(0, _resizeWindow.Height);

                }
                break;
            case ResizeDirection.BottomRight:
                _resizeWindow.Width = Math.Max(_resizeWindow.MinWidth, _initialWindowSize.Width + dx);
                _resizeWindow.Height = Math.Max(_resizeWindow.MinHeight, _initialWindowSize.Height + dy);
                _initialMousePos = new Point(_resizeWindow.Width, _resizeWindow.Height);
                break;
         
        }

    }

    private void UpdateCursor(Point position)
    {
        var direction = DetermineResizeDirection(position);
        switch (direction)
        {
            case ResizeDirection.TopLeft:
            case ResizeDirection.BottomRight:
                _resizeWindow.Cursor = Cursors.SizeNWSE;
                break;
            case ResizeDirection.TopRight:
            case ResizeDirection.BottomLeft:
                _resizeWindow.Cursor = Cursors.SizeNESW;
                break;
            case ResizeDirection.Top:
            case ResizeDirection.Bottom:
                _resizeWindow.Cursor = Cursors.SizeNS;
                break;
            case ResizeDirection.Left:
            case ResizeDirection.Right:
                _resizeWindow.Cursor = Cursors.SizeWE;
                break;
            default:
                _resizeWindow.Cursor = Cursors.Arrow;
                break;
        }
    }

    private enum ResizeDirection
    {
        None,
        Top,
        Bottom,
        Left,
        Right,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
