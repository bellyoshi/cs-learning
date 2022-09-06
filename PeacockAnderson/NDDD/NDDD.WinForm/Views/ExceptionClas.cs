using NDDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.WinForm.Views
{
    internal class ExceptionClas
    {
        private static ILog _logger = AppLog.GetLogger();

        protected void ExceptionProc(Exception ex)
        {

            _logger.Error(ex);
            
            MessageBoxIcon icon = MessageBoxIcon.Error;
            string caption = "エラー";

            if (ex is ExceptionBase exceptionBase)
            {

                if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Info)
                {
                    icon = MessageBoxIcon.Information;
                    caption = "情報";
                }
                else if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Warning)
                {
                    icon = MessageBoxIcon.Warning;
                    caption = "警告";
                }
            }

            MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, icon);
        }
    }
}
