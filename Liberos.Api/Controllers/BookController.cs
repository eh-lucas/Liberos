using Liberos.Api.DTOs;
using Liberos.Api.DTOs.Mappings;
using Liberos.Api.Interfaces;
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
    public ActionResult<IEnumerable<BookDto>> Get()
    {
        var books = _unitOfWork.BookRepository.GetAll();
        if (books is null || !books.Any())
            return NotFound("Livros não encontrados.");

        var booksDto = books.ToBookDtoList();

        return Ok(booksDto);
    }

    [HttpGet("{id:int}", Name = "ObterLivro")]
    public ActionResult<BookDto> Get(int id)
    {
        var book = _unitOfWork.BookRepository.Get(b => b.Id == id);
        if (book is null)
            return NotFound("Livro não encontrado.");

        var bookDto = book.ToBookDto();

        return Ok(bookDto);
    }

    [HttpPost]
    public ActionResult<BookDto> Post(BookDto bookDto)
    {
        var book = bookDto.ToBook();

        var createdBook = _unitOfWork.BookRepository.Create(book);

        var newBookDto = createdBook.ToBookDto();

        _unitOfWork.Commit();

        return new CreatedAtRouteResult("ObterLivro", new { id = newBookDto.Id }, newBookDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<BookDto> Put(int id, BookDto bookDto)
    {
        if (id != bookDto.Id)
            return BadRequest("Id informado não corresponde ao id do livro.");

        var book = bookDto.ToBook();

        var updatedBook = _unitOfWork.BookRepository.Update(book);
        _unitOfWork.Commit();

        var updatedBookDto = updatedBook.ToBookDto();

        return Ok(updatedBookDto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<BookDto> Delete(int id)
    {
        var book = _unitOfWork.BookRepository.Get(b => b.Id == id);
        if (book is null)
            return NotFound("Livro informado não encontrado.");

        var deletedBook = _unitOfWork.BookRepository.Delete(book);
        _unitOfWork.Commit();

        var deletedBookDto = deletedBook.ToBookDto();

        return Ok(deletedBookDto);
    }
}
