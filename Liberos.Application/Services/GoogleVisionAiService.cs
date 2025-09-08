using Google.Cloud.Vision.V1;

namespace Liberos.Application.Services
{
    public class GoogleVisionAiService
    {
        public string Quickstart()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS",
                @"C:\Users\LucasHergessel\source\repos\LiberosSolution\model-aria-471318-g3-99482b8e9004.json");
            var client = ImageAnnotatorClient.Create();
            string localPath = @"C:\Users\LucasHergessel\Downloads\poetica.png";
            var image = Image.FromFile(localPath);

            var response = client.DetectDocumentText(image);

            return response.Text;
        }
    }
}
