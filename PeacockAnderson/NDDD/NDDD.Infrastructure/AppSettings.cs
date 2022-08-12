using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain
{
    public class AppSettings
    {
        public static AppSettings Default { get; set; } = new AppSettings();
        public bool IsFake { get; set; } = false;
    }
}
