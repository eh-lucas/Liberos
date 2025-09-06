using Tesseract;

namespace Liberos.Application.Services
{
    public class TesseractReaderService
    {
        public string Quickstart()
        {
            string tessDataPath = @"C:\Users\LucasHergessel\AppData\Local\Programs\Tesseract-OCR\tessdata"; // ajuste conforme sua instalação
            string localPath = @"C:\Users\LucasHergessel\Downloads\poetica.png";
            using var engine = new TesseractEngine(tessDataPath, "por", EngineMode.Default);
            using var img = Pix.LoadFromFile(localPath);
            using var page = engine.Process(img);

            var text = page.GetText();
            return text;
        }
    }
}
