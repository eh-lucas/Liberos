using Liberos.Api.DTOs;
using Liberos.Api.DTOs.Mappings;
using Liberos.Api.Interfaces;
using Liberos.Api.Pagination;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAsync()
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync();
        if (books is null || !books.Any())
            return NotFound("Livros não encontrados.");

        var booksDto = books.ToBookDtoList();

        return Ok(booksDto);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<BookDto>>> Get([FromQuery] BooksParameters booksParams)
    {
        var books = await _unitOfWork.BookRepository.GetBooksAsync(booksParams);

        var metadata = new
        {
            books.TotalCount,
            books.PageSize,
            books.CurrentPage,
            books.TotalPages,
            books.HasNext,
            books.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        var booksDto = books.ToBookDtoList();

        return Ok(booksDto);
    }

    [HttpGet("{id:int}", Name = "ObterLivro")]
    public async Task<ActionResult<BookDto>> Get(int id)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(b => b.Id == id);
        if (book is null)
            return NotFound("Livro não encontrado.");

        var bookDto = book.ToBookDto();

        return Ok(bookDto);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Post(BookDto bookDto)
    {
        var book = bookDto.ToBook();

        var createdBook = _unitOfWork.BookRepository.Create(book);

        var newBookDto = createdBook.ToBookDto();

        await _unitOfWork.CommitAsync();

        return new CreatedAtRouteResult("ObterLivro", new { id = newBookDto.Id }, newBookDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BookDto>> Put(int id, BookDto bookDto)
    {
        if (id != bookDto.Id)
            return BadRequest("Id informado não corresponde ao id do livro.");

        var book = bookDto.ToBook();

        var updatedBook = _unitOfWork.BookRepository.Update(book);
        await _unitOfWork.CommitAsync();

        var updatedBookDto = updatedBook.ToBookDto();

        return Ok(updatedBookDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<BookDto>> Delete(int id)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(b => b.Id == id);
        if (book is null)
            return NotFound("Livro informado não encontrado.");

        var deletedBook = _unitOfWork.BookRepository.Delete(book);
        await _unitOfWork.CommitAsync();

        var deletedBookDto = deletedBook.ToBookDto();

        return Ok(deletedBookDto);
    }
}
