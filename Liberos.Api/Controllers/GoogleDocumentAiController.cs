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
        var tesseract = new TesseractReaderService();
        var content = tesseract.Quickstart();
        //var gDocAi = new GoogleDocumentAiService();
        //var document = gDocAi.Quickstart();
        //var content = document.Content;
        return Ok(content);
    }
}
