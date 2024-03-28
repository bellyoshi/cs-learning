using System.Runtime.InteropServices;

namespace pdfiumWrapper2;

internal class Win32Api
{
    [DllImport("pdfium.dll", EntryPoint = "FPDF_InitLibrary", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_InitLibrary();

    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_LIBRARY_CONFIG
    {
        public int version;
        public IntPtr m_pUserFontPaths;
        public IntPtr m_pIsolate;
        public uint m_v8EmbedderSlot;
    }

    [DllImport("pdfium.dll", EntryPoint = "FPDF_InitLibraryWithConfig", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_InitLibraryWithConfig(ref FPDF_LIBRARY_CONFIG config);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_DestroyLibrary", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_DestroyLibrary();

    [DllImport("pdfium.dll", EntryPoint = "FPDF_LoadDocument", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr FPDF_LoadDocument(Byte[] file_path, Byte[] password);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_CloseDocument", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_CloseDocument(IntPtr document);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_GetPageCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern int FPDF_GetPageCount(IntPtr document);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_LoadPage", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr FPDF_LoadPage(IntPtr document, int page_index);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_ClosePage", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_ClosePage(IntPtr page);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_GetPageWidth", CallingConvention = CallingConvention.Cdecl)]
    public static extern double FPDF_GetPageWidth(IntPtr page);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_GetPageHeight", CallingConvention = CallingConvention.Cdecl)]
    public static extern double FPDF_GetPageHeight(IntPtr page);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_RenderPage", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_RenderPage(IntPtr hDC, IntPtr page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_RenderPageBitmap", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FPDF_RenderPageBitmap(IntPtr bitmap, IntPtr page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

    [DllImport("pdfium.dll", EntryPoint = "FPDFBitmap_Create", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr FPDFBitmap_Create(int width, int height, bool isUseAlpha);

    [DllImport("pdfium.dll", EntryPoint = "FPDF_GetLastError", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint FPDF_GetLastError();

    [DllImport("pdfium.dll", EntryPoint = "FPDF_LoadMemDocument", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr FPDF_LoadMemDocument(byte[] file_content,    int content_size,    byte[] password);

}
