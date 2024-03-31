using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;

namespace WpfApp12;

public class MediaSyncBehavior : Behavior<MediaElement>
{
    public static readonly DependencyProperty IsPlayingProperty =
        DependencyProperty.Register("IsPlaying", typeof(bool), typeof(MediaSyncBehavior), new PropertyMetadata(false, OnIsPlayingChanged));

    public static readonly DependencyProperty MediaPositionProperty =
        DependencyProperty.Register("MediaPosition", typeof(TimeSpan), typeof(MediaSyncBehavior), new PropertyMetadata(default(TimeSpan), OnMediaPositionChanged));

    private DispatcherTimer? positionTimer;

    public bool IsPlaying
    {
        get => (bool)GetValue(IsPlayingProperty);
        set => SetValue(IsPlayingProperty, value);
    }

    public TimeSpan MediaPosition
    {
        get => (TimeSpan)GetValue(MediaPositionProperty);
        set => SetValue(MediaPositionProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        SetupPositionTimer();
    }

    protected override void OnDetaching()
    {
        positionTimer?.Stop();
        positionTimer = null;
        base.OnDetaching();
    }

    private static void OnIsPlayingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var behavior = d as MediaSyncBehavior;
        if (behavior?.AssociatedObject != null)
        {
            if ((bool)e.NewValue)
            {
                behavior.AssociatedObject.Play();
                behavior.positionTimer?.Start();
            }
            else
            {
                behavior.AssociatedObject.Pause();
                behavior.positionTimer?.Stop();
            }
        }
    }

    private static void OnMediaPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var behavior = d as MediaSyncBehavior;
        if (behavior?.AssociatedObject != null && e.NewValue is TimeSpan newPosition)
        {
            // Avoid updating the position if the change is originated from the timer check
            if (Math.Abs((behavior.AssociatedObject.Position - newPosition).TotalSeconds) > 1)
            {
                behavior.AssociatedObject.Position = newPosition;
            }
        }
    }

    private void SetupPositionTimer()
    {
        positionTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(10), // Update interval
        };
        positionTimer.Tick += (sender, e) =>
        {
            // Update the MediaPosition without causing a recursive update
            var newPosition = AssociatedObject.Position;
            if (Math.Abs((MediaPosition - newPosition).TotalMilliseconds) > 20)
            {
                MediaPosition = newPosition;
            }
            Debug.WriteLine($"MediaPosition: {newPosition}");
        };
    }
}
