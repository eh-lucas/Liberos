using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookController> _logger;

    public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        var books = _unitOfWork.BookRepository.GetAll();
        if (books is null || !books.Any())
            return NotFound("Livros não encontrados.");

        return Ok(books);
    }

    [HttpGet("{id:int}", Name = "ObterLivro")]
    public ActionResult<Book> Get(int id)
    {
        var book = _unitOfWork.BookRepository.Get(b => b.Id == id);
        if (book is null)
            return NotFound("Livro não encontrado.");

        return Ok(book);
    }

    [HttpPost]
    public ActionResult Post(Book book)
    {
        if (book is null)
        {
            _logger.LogWarning($"Dados inválidos.");
            return BadRequest("Livro informado inválido");
        }

        var createdBook = _unitOfWork.BookRepository.Create(book);
        _unitOfWork.Commit();

        return new CreatedAtRouteResult("ObterLivro", new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest("Id informado não corresponde ao id do livro.");

        _unitOfWork.BookRepository.Update(book);
        _unitOfWork.Commit();

        return Ok(book);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var book = _unitOfWork.BookRepository.Get(b => b.Id == id);
        if (book is null)
            return NotFound("Livro informado não encontrado.");

        var deletedBook = _unitOfWork.BookRepository.Delete(book);
        _unitOfWork.Commit();

        return Ok(deletedBook);
    }
}
