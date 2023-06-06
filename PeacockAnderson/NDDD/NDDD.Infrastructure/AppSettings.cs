using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Infrastructure
    
{
    public class AppSettings
    {
        public static AppSettings Default { get; set; } = new AppSettings();
        public bool IsFake { get; set; } = false;

        public string FakePath { get; set; } = "";
    }
}
