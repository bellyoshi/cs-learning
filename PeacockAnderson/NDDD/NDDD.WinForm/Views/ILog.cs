using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.WinForm.Views
{
    public interface ILog
    {
        void Error(Exception ex);

        void Info(string msg);
    }
}
