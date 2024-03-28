//using Microsoft.Xaml.Behaviors;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;

//namespace ListReactiveProperty.Behaviors;

//public class MediaBehavior : Behavior<MediaElement>
//{
//    public ICommand PlayCommand
//    {
//        get { return (ICommand)GetValue(PlayCommandProperty); }
//        set { SetValue(PlayCommandProperty, value); }
//    }

//    public static readonly DependencyProperty PlayCommandProperty =
//        DependencyProperty.Register("PlayCommand", typeof(ICommand), typeof(MediaBehavior), new PropertyMetadata(null));

//    public ICommand PauseCommand
//    {
//        get { return (ICommand)GetValue(PauseCommandProperty); }
//        set { SetValue(PauseCommandProperty, value); }
//    }

//    public static readonly DependencyProperty PauseCommandProperty =
//        DependencyProperty.Register("PauseCommand", typeof(ICommand), typeof(MediaBehavior), new PropertyMetadata(null));

//    protected override void OnAttached()
//    {
//        base.OnAttached();

//        PlayCommand = new RelayCommand(_ => AssociatedObject.Play());
//        PauseCommand = new RelayCommand(_ => AssociatedObject.Pause());
//    }

//    protected override void OnDetaching()
//    {
//        base.OnDetaching();
//        リソースのクリーンアップやイベントのデタッチなど、必要に応じてここにコードを追加
//        }
//}

//public class RelayCommand : ICommand
//{
//    private readonly Action<object> execute;
//    private readonly Func<object, bool> canExecute;

//    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
//    {
//        this.execute = execute;
//        this.canExecute = canExecute ?? (_ => true);
//    }

//    public event EventHandler CanExecuteChanged
//    {
//        add { CommandManager.RequerySuggested += value; }
//        remove { CommandManager.RequerySuggested -= value; }
//    }

//    public bool CanExecute(object parameter)
//    {
//        return canExecute(parameter);
//    }

//    public void Execute(object parameter)
//    {
//        execute(parameter);
//    }
//}

