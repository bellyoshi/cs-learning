using System;
using Reactive.Bindings;
namespace WpfApp12;
public class MediaStateViewModel
{
    public ReactiveProperty<bool> IsMediaPlaying { get; } = new ReactiveProperty<bool>();
    public ReactiveProperty<TimeSpan> MediaPosition { get; } = new ReactiveProperty<TimeSpan>();

    public MediaStateViewModel()
    {
        IsMediaPlaying.Subscribe(_ => UpdateMediaPosition());
    }

    private void UpdateMediaPosition()
    {
        // このメソッド内で、必要に応じてMediaPositionの更新ロジックを実装
        // 例: MediaPosition.Value = new TimeSpan(0, 0, 1); // 仮の値
    }
}
