using System.Diagnostics;
using System.Text;

namespace ViewerBy2ndLib
{

    //サポートするファイルの種類
    public class FileTypes
    {

        /// 開ける動画の拡張子
        static readonly string[] movieExts = ["avi", "mpeg", "mp4", "wmv", "mov"];

        // 開ける画像の拡張子
        static readonly string[] ImageExts = ["jpeg", "jpg", "bmp", "png", "gif", "tiff", "tif"];

        static readonly string[] SVGExts = ["svg"];

        // PDFの拡張子
        static readonly string[] PDFExts = ["pdf"];

        //FileTypeEnum fileType;




        static bool IsContain(string filename, string[] exts)
        {
            var extention = System.IO.Path.GetExtension(filename);
            foreach (var target in exts)
            {
                if (String.Compare($".{target}", extention, true) == 0)
                    return true;
            }
            return false;
        }

        static public bool IsImageExt(string filename)
             => IsContain(filename, ImageExts);
        static public bool IsMovieExt(string filename)
             => IsContain(filename, movieExts);
        static public bool IsSVGExt(string filename)
            => IsContain(filename, SVGExts);
        static public bool IsPDFExt(string filename)
            => IsContain(filename, PDFExts);

        static public string CreateFilter()
        {
            var buf = new System.Text.StringBuilder();
            buf.Append("画像ファイル");
            buf.Append('|');
            buf.Append(CreateExtentionsOfFilter(ImageExts));
            buf.Append('|');
            buf.Append("動画ファイル");
            buf.Append('|');
            buf.Append(CreateExtentionsOfFilter(movieExts));
            buf.Append('|');
            buf.Append("SVGファイル");
            buf.Append('|');
            buf.Append(CreateExtentionsOfFilter(SVGExts));
            buf.Append('|');
            buf.Append("PDFファイル");
            buf.Append('|');
            buf.Append(CreateExtentionsOfFilter(PDFExts));
            buf.Append('|');
            buf.Append("All Supported Files");
            buf.Append('|');
            buf.Append(CreateExtentionsOfFilter(PDFExts));
            buf.Append(';');
            buf.Append(CreateExtentionsOfFilter(ImageExts));
            buf.Append(';');
            buf.Append(CreateExtentionsOfFilter(movieExts));
            buf.Append(';');
            buf.Append(CreateExtentionsOfFilter(SVGExts));
            buf.Append('|');
            buf.Append("All Files(*.*)");
            buf.Append('|');
            buf.Append("*.*");

            return buf.ToString();
    }

        static  string CreateExtentionsOfFilter(string[] exts) {
            var buf = new System.Text.StringBuilder();
            Debug.Assert(exts.Length > 0);
            AppendExt(buf, exts[0]);
            for(int i = 1;i < exts.Length; i++)
            {
                buf.Append(';');
                AppendExt(buf, exts[i]);
            }
            return buf.ToString();
        }

        private static void AppendExt(StringBuilder buf, string ext)
        {
            buf.Append("*.");
            buf.Append(ext);
        }
    }
}
