using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace ListReactiveProperty.Utils;

/// <summary>
/// ウィンドウをドラッグして移動するクラス
/// </summary>
public class WindowDragMover
{
    public bool Enabled { get; set; } = true;
    // 移動の対象となるウィンドウ
    private readonly Window moveWindow;

    // ドラッグを無効とする幅
    private readonly int noDragAreaWidth;

    // マウスをクリックした位置
    private Point lastMouseDownPoint;

    public WindowDragMover(Window moveWindow, int noDragAreaWidth, UIElement[] elements)
    {
        this.moveWindow = moveWindow;
        this.noDragAreaWidth = noDragAreaWidth;

        foreach (UIElement element in elements)
        {
            // イベントハンドラを追加
            element.MouseDown += MoveWindow_MouseDown;
        }
    }

    void MoveWindow_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (!Enabled)
        {
            return;
        }

        if (e.LeftButton != MouseButtonState.Pressed) return;

        var moveArea = new Rect(
            noDragAreaWidth, noDragAreaWidth,
            moveWindow.Width - (noDragAreaWidth * 2), moveWindow.Height - (noDragAreaWidth * 2));

        if (moveArea.Contains(e.GetPosition(moveWindow)))
        {
            moveWindow.DragMove();
            e.Handled = true;
        }
    }


}
