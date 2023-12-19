using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty
{
    internal class FileViewParam
    {
        string filename { get; set; }
        public FileViewParam(string filename)
        {
            this.filename = filename;
        }

        public override string ToString()
        {
            return filename;
        }
    }
}
