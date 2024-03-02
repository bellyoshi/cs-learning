using Reactive.Bindings;

namespace WpfApp8;
public class MainViewModel
{
    public ReactiveCollection<SearchResultViewModel> SearchResults { get; set; }

    public ReactiveCommand AddCommand { get; } = new();
    public ReactiveCommand DeleteCommand { get; } = new();

    int count = 4;

    public MainViewModel()
    {
        SearchResults = new ReactiveCollection<SearchResultViewModel>();
        SearchResults.Add(new SearchResultViewModel("Hello 1"));
        SearchResults.Add(new SearchResultViewModel("World 2"));
        SearchResults.Add(new SearchResultViewModel("Hello 3"));

        AddCommand.Subscribe(_ =>
            SearchResults.Add(new SearchResultViewModel("New Item" + ++count))
        );
        DeleteCommand.Subscribe(_ =>
            delete()
        );
        // SearchResults にデータを追加するロジック
    }

    void delete()
    {
        // SearchResults からデータを削除するロジック
        // 例えば、IsSelected が true のものを削除する
        foreach (var item in SearchResults.ToArray())
        {
            if (item.IsSelected.Value)
            {
                SearchResults.Remove(item);
            }
        }

    }
}