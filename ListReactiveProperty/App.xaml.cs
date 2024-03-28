using System.Configuration;
using System.Data;
using System.Windows;
using ListReactiveProperty.Utils;

namespace ListReactiveProperty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static public DependencyContainer Container { get; } = new();


    }

}
