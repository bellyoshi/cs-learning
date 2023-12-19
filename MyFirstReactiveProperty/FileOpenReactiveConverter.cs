using Reactive.Bindings.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFirstReactiveProperty
{
        internal class FileOpenReactiveConverter : ReactiveConverter<RoutedEventArgs, string>
        {
        
                protected override IObservable<string> OnConvert(IObservable<RoutedEventArgs?> source)
                {
                    return source.SelectMany(async _ =>
                    {
                        // ファイルを開くダイアログを表示
                        var dialog = new Microsoft.Win32.OpenFileDialog();
                        dialog.FileName = ""; // Default file name
                        dialog.DefaultExt = ".pdf"; // Default file extension
                        dialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

                        // Show open file dialog box
                        bool? result = dialog.ShowDialog();

                        // Process open file dialog box results
                        if (result == true)
                        {
                            // Open document
                            string filename = dialog.FileName;
                        }
                        return await Task.FromResult(dialog.FileName);
                    })
                    .Where(x => x != null);

                }
        
        }
}
