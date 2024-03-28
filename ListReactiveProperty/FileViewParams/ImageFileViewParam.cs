using ListReactiveProperty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ListReactiveProperty.FileViewParams
{
    public class ImageFileViewParam(string filename) : DocuGraphFileViewParam(filename)
    {
        public override BitmapSource GetImageFromFile()
        {
            return ImageCreater.GetImageFromFile(this);
        }
    }
    

}
