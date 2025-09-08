using Google.Cloud.DocumentAI.V1;
using Google.Protobuf;

namespace Liberos.Application.Services;
public class GoogleDocumentAiService
{
    public Document Quickstart(
        string projectId = "151329425318",
        string locationId = "us",
        string processorId = "de1fd1945a1456f1",
        string localPath = @"C:\Users\LucasHergessel\Downloads\poetica.png",
        string mimeType = "image/png"
    )
    {
        // Create client
        var client = new DocumentProcessorServiceClientBuilder
        {
            Endpoint = $"{locationId}-documentai.googleapis.com"
        }.Build();

        // Read in local file
        using var fileStream = File.OpenRead(localPath);
        var rawDocument = new RawDocument
        {
            Content = ByteString.FromStream(fileStream),
            MimeType = mimeType
        };

        // Initialize request argument(s)
        var request = new ProcessRequest
        {
            Name = ProcessorName.FromProjectLocationProcessor(projectId, locationId, processorId).ToString(),
            RawDocument = rawDocument
        };

        // Make the request
        var response = client.ProcessDocument(request);

        var document = response.Document;
        Console.WriteLine(document.Text);
        return document;
    }
}
