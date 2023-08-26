using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WeatherData
    {
        public delegate void WeatherChangeHandler(object sender, WeatherChangeEventArgs e);
        public event WeatherChangeHandler? WeatherChange;

        private int _temperature;

        public void SetTemperature(int newTemperature)
        {
            if (_temperature != newTemperature)
            {
                _temperature = newTemperature;
                OnWeatherChange(new WeatherChangeEventArgs(_temperature));
            }
        }

        protected virtual void OnWeatherChange(WeatherChangeEventArgs e)
        {
            WeatherChange?.Invoke(this, e);
        }
    }
   





}
