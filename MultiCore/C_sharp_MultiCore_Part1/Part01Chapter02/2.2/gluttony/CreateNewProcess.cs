using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gluttony
{
    internal class CreateNewProcess
    {

        internal void RunAsync()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            ProcessStartInfo psi = new ProcessStartInfo(asm.Location);
            Process.Start(psi);
        }


    
    }
}
