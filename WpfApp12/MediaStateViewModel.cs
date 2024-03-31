using System;
using System.Diagnostics;
using Reactive.Bindings;
namespace WpfApp12;
public class MediaStateViewModel
{
    public ReactiveProperty<bool> IsMediaPlaying { get; } = new ReactiveProperty<bool>();
    public ReactiveProperty<TimeSpan> MediaPosition { get; } = new ReactiveProperty<TimeSpan>();
    public ReactiveProperty<TimeSpan> MediaLength { get; } = new ReactiveProperty<TimeSpan>();

    public ReactiveProperty<double> PositionValue { get; } = new ReactiveProperty<double>();
    public ReactiveProperty<double> LengthValue { get; } = new ReactiveProperty<double>();


    public MediaStateViewModel()
    {
        IsMediaPlaying.Subscribe(_ => UpdateMediaPosition());
        
        MediaPosition.Subscribe(position =>
        {
            PositionValue.Value = position.TotalMilliseconds;
            Debug.WriteLine($"MediaPosition: {position}");
        });
        MediaLength.Subscribe(length =>
        {
            LengthValue.Value = length.TotalMilliseconds;
        });
    }

    private void UpdateMediaPosition()
    {
        // このメソッド内で、必要に応じてMediaPositionの更新ロジックを実装
    }
}
