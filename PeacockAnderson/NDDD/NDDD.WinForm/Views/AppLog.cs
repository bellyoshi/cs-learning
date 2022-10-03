using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.WinForm.Views
{
    internal class AppLog : ILog
    {
        static AppLog applog = new AppLog();
        internal static ILog GetLogger() => applog;

        //private static log4net.ILog _logger =
        //    log4net.LogManager.GetLogger(
        //        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Error(Exception ex)
        {
            //logger.Error(ex.Message, ex);
        }

        public void Info(string msg)
        {
            //logger.Info(ex.Message, ex);
        }
    }
}
