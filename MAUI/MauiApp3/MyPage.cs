using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MauiApp3
{
    public class MyPage : ContentPage
    {
        public MyPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };



        }
    }
}