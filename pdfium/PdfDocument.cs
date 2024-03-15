using System.Drawing;

namespace pdfium;

public class PdfDocument
{
    private static bool initialized = false;
    private string filePath;  // PDFファイル名
    private IntPtr PdfDocumentPtr = (IntPtr)0;
    private IntPtr m_pdfPage = (IntPtr)0;
    public double PageWidth { get; private set; } = 0;
    public double PageHeight { get; private set; } = 0;

    public int PagesCount { get; private set; } = 0;
    public int PageIndex { get; set; } = -1;
    private byte[] data = Array.Empty<byte>();
    public static PdfDocument Load(string filename)
    {
        return new PdfDocument(filename);
    }
    private PdfDocument(string file) {
        // ファイルロード
        CloseFile();  // 既にロード済みなら閉じる
        filePath = file;
        LoadFile();
    }
    public void End()
    {
        CloseFile();
        Win32Api.FPDF_DestroyLibrary();
    }
   
    private bool LoadFile()
    {
        Initialize();

        //FPDF_LoadDocumentはマルチバイトのファイル名のファイルを読み込むことができず
        //Error code 2となるため
        //LoadMemDocumentを使用する。
        data = File.ReadAllBytes(filePath);
        PdfDocumentPtr = Win32Api.FPDF_LoadMemDocument(data, data.Length, Array.Empty<byte>());

        if (PdfDocumentPtr == (IntPtr)0)
        {
            throw new Exception($"file open error code {Win32Api.FPDF_GetLastError()} code 2 is  file not found or could not be opened");
            {

            };
        }

        PagesCount = Win32Api.FPDF_GetPageCount(PdfDocumentPtr);


        // ページロード
        if (!LoadPage(0))
            return false;

        return true;
    }

    private static void Initialize()
    {
        if (!initialized)
        {
            Win32Api.FPDF_InitLibrary();
            initialized = true;
        }
    }

    private bool LoadPage(int page)
    {
        System.Diagnostics.Debug.Assert(0 <= page  && page < PagesCount);

        PageIndex = page;

        ClosePage();
        m_pdfPage = Win32Api.FPDF_LoadPage(PdfDocumentPtr, PageIndex);
        PageWidth = Win32Api.FPDF_GetPageWidth(m_pdfPage);
        PageHeight = Win32Api.FPDF_GetPageHeight(m_pdfPage);
        return true;
    }
    private void ClosePage()
    {
        if (m_pdfPage != (IntPtr)0)
        {
            Win32Api.FPDF_ClosePage(m_pdfPage);
            m_pdfPage = (IntPtr)0;
        }
    }
    private void CloseFile()
    {
        ClosePage();
        if (PdfDocumentPtr != (IntPtr)0)
        {
            Win32Api.FPDF_CloseDocument(PdfDocumentPtr);
            PdfDocumentPtr = (IntPtr)0;
            filePath = "";
        }
    }



    public Image RenderPage(int pageIndex, int renderWidth, int renderHeight)
    {
        PDFRender pDFRender = new(this.PdfDocumentPtr);
        return pDFRender.RenderPage(pageIndex, renderWidth, renderHeight);
    }



}
