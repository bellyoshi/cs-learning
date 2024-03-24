using Reactive.Bindings;
using System.Windows;

namespace DrawRectangle.ViewModels
{
    public class CanvasDrawingViewModel
    {
        public ReactivePropertySlim<string> Text { get; } = new ReactivePropertySlim<string>("クリックされていないな...");

        public ReactiveCommand<Point> ClickLeftCommand { get; } = new ReactiveCommand<Point>();

        public CanvasDrawingViewModel()
        {
            ClickLeftCommand.WithSubscribe(p => OnClickLeft(p));
        }

        private void OnClickLeft(Point p)
        {

            Text.Value = $"左クリックされたよ！ X: {p.X} Y: {p.Y}";
        }
    }
}
