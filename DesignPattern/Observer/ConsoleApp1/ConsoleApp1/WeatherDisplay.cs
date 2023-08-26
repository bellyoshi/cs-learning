using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Observerクラス
    public class WeatherDisplay
    {
        public WeatherDisplay(WeatherData weatherData)
        {
            weatherData.WeatherChange += Update;
        }

        public void Update(object sender, WeatherChangeEventArgs e)
        {
            Console.WriteLine($"Weather display updated: New temperature is {e.Temperature}");
        }
    }
}
