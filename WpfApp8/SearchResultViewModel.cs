using Reactive.Bindings;
namespace WpfApp8;

public class SearchResultViewModel
{
    public ReactiveProperty<bool> IsSelected { get; }

    public string Name { get; }

    public SearchResultViewModel(string name)
    {
        IsSelected = new ReactiveProperty<bool>(false);
        this.Name = name;
    }

    public override string ToString()
    {
        return Name + "です";
    }

    // その他のプロパティやメソッド
}
