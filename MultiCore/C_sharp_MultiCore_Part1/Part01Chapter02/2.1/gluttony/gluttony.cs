using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gluttony
{
    internal class gluttony
    {
        public bool IsRunning { get; set; }
        public void WorkInfinite()
        {
            this.IsRunning =    true;
            double r = 0.0;
            while (true)
            {
                for(int i = 1; i <= int.MaxValue; i++)
                {
                    for(int j =1; j <= int.MaxValue; j++)
                    {
                        if (!this.IsRunning) return;
                        r = (double)i/(double)j;
                        Application.DoEvents();
                    }
                }
            }
        }
    }
}
