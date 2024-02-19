using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        readonly Stopwatch stopwatch = new Stopwatch();
        readonly DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            var result = stopwatch.Elapsed;
            Timer.Text = result.Minutes.ToString() + ":" + result.Seconds.ToString() + ":" + (result.Milliseconds / 100).ToString();
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Start();
        }

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            stopwatch.Stop();
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            stopwatch.Reset();
            Timer.Text = "0:0:0";
        }
    }
}
