using Liberos.Api.DTOs;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<Content>> Get()
    {
        var contents = _unitOfWork.ContentRepository.GetAll();
        if (contents is null || !contents.Any())
            return NotFound("Conteúdos não encontrados.");

        return Ok(contents);
    }

    [HttpGet("{id:int}", Name = "ObterConteudo")]
    public ActionResult<BookDto> Get(int id)
    {
        var content = _unitOfWork.ContentRepository.Get(b => b.Id == id);
        if (content is null)
            return NotFound("Conteúdo não encontrado.");

        return Ok(content);
    }

    [HttpPost]
    public ActionResult<Content> Post(Content content)
    {
        var createdContent = _unitOfWork.ContentRepository.Create(content);
        _unitOfWork.Commit();

        return new CreatedAtRouteResult("ObterConteudo", new { id = createdContent.Id }, createdContent);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Content> Put(int id, Content content)
    {
        if (id != content.Id)
            return BadRequest("Id informado não corresponde ao id do conteúdo.");

        var updatedContent = _unitOfWork.ContentRepository.Update(content);
        _unitOfWork.Commit();

        return Ok(updatedContent);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Content> Delete(int id)
    {
        var content = _unitOfWork.ContentRepository.Get(b => b.Id == id);
        if (content is null)
            return NotFound("Conteúdo informado não encontrado.");

        var deletedContent = _unitOfWork.ContentRepository.Delete(content);
        _unitOfWork.Commit();

        return Ok(deletedContent);
    }
}

