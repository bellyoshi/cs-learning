using NUnit.Framework;
using ViewerBy2ndLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewerBy2ndLib.Tests
{
    [TestFixture()]
    public class FileTypesTests
    {
        [Test()]
        public void CreateFilterTest()
        {
            var expected = "画像ファイル|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff;*.ico;*.cur|動画ファイル|*.mp4;*.wmv;*.avi;*.mpg;*.mpeg;*.mov;*.mkv;*.flv;*.swf;*.3gp;*.3g2;*.asf;*.m4v;*.m2ts;*.mts;*.ts;*.vob;*.divx;*.xvid|SVGファイル|*.svg|PDFファイル|*.pdf|All Supported Files|*.pdf;*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff;*.ico;*.cur;*.mp4;*.wmv;*.avi;*.mpg;*.mpeg;*.mov;*.mkv;*.flv;*.swf;*.3gp;*.3g2;*.asf;*.m4v;*.m2ts;*.mts;*.ts;*.vob;*.divx;*.xvid;*.svg|All Files(*.*)|*.*";
            var actual = ListReactiveProperty.FileTypes.CreateFilter();
            Assert.AreEqual(expected, actual);
        }
    }
}