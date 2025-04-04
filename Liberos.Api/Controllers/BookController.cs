using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IRepository<Book> _repository;
    private readonly ILogger<BookController> _logger;

    public BookController(IRepository<Book> repository, ILogger<BookController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        var books = _repository.GetAll();
        if (books is null || !books.Any())
            return NotFound("Livros não encontrados.");

        return Ok(books);
    }

    [HttpGet("{id:int}", Name = "ObterLivro")]
    public ActionResult<Book> Get(int id)
    {
        var book = _repository.Get(b => b.Id == id);
        if (book is null)
            return NotFound("Livro não encontrado.");

        return Ok(book);
    }

    [HttpPost("{id:int}")]
    public ActionResult Post(Book book)
    {
        if (book is null)
        {
            _logger.LogWarning($"Dados inválidos.");
            return BadRequest("Livro informado inválido");
        }

        var createdBook = _repository.Create(book);

        return new CreatedAtRouteResult("ObterLivro", new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest("Id informado não corresponde ao id do livro.");

        _repository.Update(book);

        return Ok(book);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var book = _repository.Get(b => b.Id == id);
        if (book is null)
            return NotFound("Livro informado não encontrado.");

        var deletedBook = _repository.Delete(book);

        return Ok(deletedBook);
    }
}
