using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace WpfApp12;


public class MediaSyncBehavior : Behavior<MediaElement>
{
    public static readonly DependencyProperty IsPlayingProperty =
        DependencyProperty.Register(
            "IsPlaying",
            typeof(bool),
            typeof(MediaSyncBehavior),
            new PropertyMetadata(default(bool), OnIsPlayingChanged));

    public bool IsPlaying
    {
        get { return (bool)GetValue(IsPlayingProperty); }
        set { SetValue(IsPlayingProperty, value); }
    }

    protected override void OnAttached()
    {
        base.OnAttached();
    }

    private static void OnIsPlayingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MediaSyncBehavior behavior && behavior.AssociatedObject != null)
        {
            if ((bool)e.NewValue)
            {
                behavior.AssociatedObject.Play();
            }
            else
            {
                behavior.AssociatedObject.Pause();
            }
        }
    }
}
