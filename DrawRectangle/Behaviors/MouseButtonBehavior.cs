using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace DrawRectangle.Behaviors
{
    public class MouseButtonBehavior : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty MouseLeftButtonClickedProperty =
            DependencyProperty.Register(
                nameof(MouseLeftButtonClicked),
                typeof(ICommand),
                typeof(MouseButtonBehavior),
                new FrameworkPropertyMetadata());

        public ICommand MouseLeftButtonClicked
        {
            get => (ICommand)GetValue(MouseLeftButtonClickedProperty);
            set => SetValue(MouseLeftButtonClickedProperty, value);
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonClicked;
        }

        private void AssociatedObjectOnMouseLeftButtonClicked(object sender, MouseEventArgs e)
        {
            AssociatedObject.CaptureMouse();
            var prevPoint = e.GetPosition(AssociatedObject);
            var point = new Point(prevPoint.X, prevPoint.Y);

            if (MouseLeftButtonClicked == null || !MouseLeftButtonClicked.CanExecute(point)) return;
            MouseLeftButtonClicked.Execute(point);

        }
    }
}
