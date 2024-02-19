using System.Diagnostics;
using System.Text;

namespace ListReactiveProperty;


//サポートするファイルの種類
public class FileTypes
{

    /// 開ける動画の拡張子
    static readonly string[] movieExts = ["mp4","wmv","avi", "mpg", "mpeg", "mov"];
    // *.mp4;*.wmv;*.avi;*.mpg;*.mpeg;*.mov;*.mkv;*.flv;*.swf;*.3gp;*.3g2;*.asf;*.m4v;*.m2ts;*.mts;*.ts;*.vob;*.divx;*.xvid|"
    // 開ける画像の拡張子
    static readonly string[] ImageExts = [
        "jpg", "jpeg",  // JPEG images
"png",           // Portable Network Graphics
"gif",           // Graphics Interchange Format
"bmp",           // Bitmap
"tiff", "tif",  // Tagged Image File Format
//    "webp",          // WebP format
//    "heif", ".heic", // High Efficiency Image File Format
//    "raw",           // RAW images
"cr2",           // Canon RAW format
//    "nef",           // Nikon Electronic Format
//    "arw",           // Sony Alpha Raw
//    "raf",           // Fuji RAW format
//    "orf",           // Olympus Raw Format
//    "dng",           // Digital Negative
//    "rw2",           // Panasonic RAW format
//    "pef",           // Pentax Electronic Format
//    "psd",           // Adobe Photoshop Document
//    "ai",            // Adobe Illustrator Document
//    "eps",           // Encapsulated PostScript
//    "indd",          // Adobe InDesign Document
//×    "xcf"            // GIMP Image File
//icon
];

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

    static System.Text.StringBuilder? buf;
    static public string CreateFilter()
    {
        buf = new System.Text.StringBuilder();

        buf.Append("画像ファイル");
        buf.Append('|');
        CreateExtentionsOfFilter(ImageExts);
        buf.Append('|');
        buf.Append("動画ファイル");
        buf.Append('|');
        CreateExtentionsOfFilter(movieExts);
        buf.Append('|');
        buf.Append("SVGファイル");
        buf.Append('|');
        CreateExtentionsOfFilter(SVGExts);
        buf.Append('|');
        buf.Append("PDFファイル");
        buf.Append('|');
        CreateExtentionsOfFilter(PDFExts);
        buf.Append('|');
        buf.Append("All Supported Files");
        buf.Append('|');
        CreateExtentionsOfFilter(ImageExts);
        buf.Append(';');
        CreateExtentionsOfFilter(movieExts);
        buf.Append(';');
        CreateExtentionsOfFilter(SVGExts);
        buf.Append(';');
        CreateExtentionsOfFilter(PDFExts);
        buf.Append('|');
        buf.Append("All Files(*.*)");
        buf.Append('|');
        buf.Append("*.*");

        return buf.ToString();
}

    static  string CreateExtentionsOfFilter(string[] exts) {
        Debug.Assert(buf != null);
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

    public static FileViewParam GetFileViewParam(string filename)
    {
        if (IsImageExt(filename))
            return new ImageFileViewParam(filename);
        if (IsMovieExt(filename))
            return new MovieFileViewParam(filename);
        if (IsSVGExt(filename))
            return new SvgFileViewParam(filename);
        if (IsPDFExt(filename))
            return new PdfFileViewParam(filename);
        throw new ArgumentException("filename");
    }
    
}
