using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Devices.Core;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TDD_Jumper
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        readonly BitmapImage[] images = new BitmapImage[8];
        DispatcherTimer timer;
        int StickmanCounter = 0;
        int speed = 0;
        int stickY = 200;
        int boxX = 600;
        public MainWindow()
        {
            this.InitializeComponent();

            LoadImage();

            SetTimer();

        }
        private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Space && stickY == 200)
            {
                speed = -15;
            }
        }


        private void SetTimer()
        {
            timer = new ()
            {
                Interval = TimeSpan.FromMilliseconds(3)
            };
            timer.Tick +=Timer_Tick;
            timer.Start();
        }

        private void LoadImage()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = new(GetStickmanUri(i));
            }
        }

        private static Uri GetStickmanUri(int i)
        {
            return new Uri($"ms-appx:///Images/stickman{i}.png");
        }

        private void Timer_Tick(object sender, object e)
        {
            StickmanUpdate();

            BoxUpdate();
        }

        private void BoxUpdate()
        {
            boxX = (boxX > -100) ? boxX - 10 : 600;
            Box.SetValue(Canvas.TopProperty, 300);
            Box.SetValue(Canvas.LeftProperty, boxX);
        }

        private void StickmanUpdate()
        {
            StickmanCounter = (StickmanCounter + 1) % (images.Length );
            Stickman.Source = images[StickmanCounter ];

            speed += 1;
            stickY += speed;
            if(stickY > 200)
            {
                stickY = 200;
                speed = 0;
            }
            Stickman.SetValue(Canvas.TopProperty, stickY);
        }
    }
}
