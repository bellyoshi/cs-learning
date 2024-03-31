using System;
using System.Diagnostics;
using Reactive.Bindings;
namespace WpfApp12;

interface ISliderViewModel
{
    public ReactiveProperty<double> RequiredValue { get; }
}

public class MediaStateViewModel : ISliderViewModel
{
    public ReactiveProperty<double> RequiredValue { get; } = new();
    public ReactiveProperty<bool> IsMediaPlaying { get; } = new ReactiveProperty<bool>();
    public ReactiveProperty<TimeSpan> MediaPosition { get; } = new ReactiveProperty<TimeSpan>();
    public ReactiveProperty<TimeSpan> MediaLength { get; } = new ReactiveProperty<TimeSpan>();

    public ReactiveProperty<double> PositionValue { get; } = new ReactiveProperty<double>(500);
    public ReactiveProperty<double> LengthValue { get; } = new ReactiveProperty<double>(1000);

    public ReactiveProperty<Uri> Source { get; } = new (new Uri(@"C:\Users\catik\OneDrive\www\video\hanatokingdom.mp4",UriKind.Relative));


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
        RequiredValue.Subscribe(value =>
        {
            MediaPosition.Value = TimeSpan.FromMilliseconds(value);
            Debug.WriteLine($"ここで処理: {value}");

        });
    }

    private void UpdateMediaPosition()
    {
        // このメソッド内で、必要に応じてMediaPositionの更新ロジックを実装
    }
}
