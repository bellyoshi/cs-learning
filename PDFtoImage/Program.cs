using PdfiumViewer;
using System.Drawing;
using System.Drawing.Imaging;



// PDFファイルが格納されているフォルダのパス
string folderPath = @"C:\Users\catik\Downloads\folder";

// 指定されたフォルダ内のすべてのPDFファイルを取得
string[] pdfFiles = Directory.GetFiles(folderPath, "*.pdf");

foreach (var pdfFilePath in pdfFiles)
{
    using var document = PdfDocument.Load(pdfFilePath);

    // 2ページ目の存在を確認
    if (document.PageCount != 2)
    {
        continue;
    }
    // 1ページ目と2ページ目をイメージとして抽出
    Size imageSize1 = new ((int)document.PageSizes[0].Width, (int)document.PageSizes[0].Height);
    Size imageSize2 = new ((int)document.PageSizes[1].Width, (int)document.PageSizes[1].Height);
    using var image1 = document.Render(page: 0,imageSize1.Width, imageSize1.Height, dpiX:96,dpiY:96,true);
    using var image2 = document.Render(page: 1,imageSize2.Width, imageSize2.Height, dpiX:96,dpiY:96, true);
    
    // 結合後の画像のサイズを計算
    int width = Math.Max(image1.Width , image2.Width);
    int height = (image1.Height +  image2.Height);

    // 新しい画像を作成して2つの画像を横に結合
    using var bitmap = new Bitmap(width, height);
    
    using var g = Graphics.FromImage(bitmap);
        
    g.DrawImage(image1, x:0, y:0);
    g.DrawImage(image2, x:0, y:imageSize1.Height);

    // 結合した画像を左に90度回転
    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

    // 結合した画像をPNG形式で保存
    string savePath = Path.ChangeExtension(pdfFilePath, ".png");
    bitmap.Save(savePath, ImageFormat.Png);
    
 
}


