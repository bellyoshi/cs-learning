﻿using System.IO;
using System.Windows.Media.Imaging;
using ViewerBy2ndLib;

namespace ListReactiveProperty;

internal class ImageCreater
{
    public static BitmapSource GetImageFromFile(FileViewParam viewParam)
    {
        if (FileTypes.IsImageExt(viewParam.filename))
        {
            return new BitmapImage(new Uri(viewParam.filename));
        }
        else if (FileTypes.IsPDFExt(viewParam.filename))
        {
            return pdfiumWrapper.PDFRender.GetImage(viewParam.filename, 0);
        }
        else
        {
            return null;
        }

    }



}
