using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // EventArgsクラス
    public class WeatherChangeEventArgs : EventArgs
    {
        public int Temperature { get; private set; }

        public WeatherChangeEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }
}
