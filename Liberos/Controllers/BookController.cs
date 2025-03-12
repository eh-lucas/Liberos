using Liberos.Models;
using Liberos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService = new();

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(_bookService.GetAllBooks());
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
        var book = _bookService.GetBookById(id);
        return book is not null ? Ok(book) : NotFound("Livro não encontrado");
    }
}
