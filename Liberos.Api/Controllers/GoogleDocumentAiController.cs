using Liberos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GoogleDocumentAiController : ControllerBase
{
    public GoogleDocumentAiController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        //// tesseract
        //var tesseract = new TesseractReaderService();
        //var content = tesseract.Quickstart();

        //// google vision
        //var gDocAi = new GoogleDocumentAiService();
        //var document = gDocAi.Quickstart();
        //var content = document.Content;

        // google vision
        var vision = new GoogleVisionAiService();
        var content = vision.Quickstart();


        return Ok(content);
    }
}
