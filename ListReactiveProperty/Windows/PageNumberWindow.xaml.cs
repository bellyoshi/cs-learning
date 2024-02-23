using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListReactiveProperty.Windows
{
    /// <summary>
    /// PageNumberWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class PageNumberWindow : Window
    {
        public static int GetPageNumber(int pageNumber, int pageCount)
        {
            var window = new PageNumberWindow
            {
                PageNumber = pageNumber,
                PageCount =  pageCount
            };

            window.ShowDialog();
            return window.PageNumber;
        }
        private int PageNumber { get; set; }
        private int BackupPageNumber { get; set; }
        private int PageCount { get; set; }

        public PageNumberWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PageNumberTextBox.Text = PageNumber.ToString();
            PageCountTextBox.Content = PageCount.ToString();
            BackupPageNumber = PageNumber;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            PageNumber = int.Parse(PageNumberTextBox.Text);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            PageNumber = BackupPageNumber;
            Close();
        }
    }
}
