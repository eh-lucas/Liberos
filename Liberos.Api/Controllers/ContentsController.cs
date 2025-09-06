using Liberos.Api.DTOs;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Liberos.Api.Pagination;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Liberos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ContentsController> _logger;

    public ContentsController(IUnitOfWork unitOfWork, ILogger<ContentsController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Content>>> Get()
    {
        var contents = await _unitOfWork.ContentRepository.GetAllAsync();
        if (contents is null || !contents.Any())
            return NotFound("Conteúdos não encontrados.");

        return Ok(contents);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<Content>>> Get([FromQuery] ContentsParameters contentsParams)
    {
        var contents = await _unitOfWork.ContentRepository.GetContentsAsync(contentsParams);

        var metadata = new
        {
            contents.TotalCount,
            contents.PageSize,
            contents.CurrentPage,
            contents.TotalPages,
            contents.HasNext,
            contents.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(contents);
    }

    [HttpGet("{id:int}", Name = "ObterConteudo")]
    public async Task<ActionResult<BookDto>> Get(int id)
    {
        var content = await _unitOfWork.ContentRepository.GetAsync(b => b.Id == id);
        if (content is null)
            return NotFound("Conteúdo não encontrado.");

        return Ok(content);
    }

    [HttpPost]
    public async Task<ActionResult<Content>> Post(Content content)
    {
        var createdContent = _unitOfWork.ContentRepository.Create(content);
        await _unitOfWork.CommitAsync();

        return new CreatedAtRouteResult("ObterConteudo", new { id = createdContent.Id }, createdContent);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Content>> Put(int id, Content content)
    {
        if (id != content.Id)
            return BadRequest("Id informado não corresponde ao id do conteúdo.");

        var updatedContent = _unitOfWork.ContentRepository.Update(content);
        await _unitOfWork.CommitAsync();

        return Ok(updatedContent);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Content>> Delete(int id)
    {
        var content = await _unitOfWork.ContentRepository.GetAsync(b => b.Id == id);
        if (content is null)
            return NotFound("Conteúdo informado não encontrado.");

        var deletedContent = _unitOfWork.ContentRepository.Delete(content);
        await _unitOfWork.CommitAsync();

        return Ok(deletedContent);
    }
}

