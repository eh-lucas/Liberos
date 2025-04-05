using Liberos.Api.Models;

namespace Liberos.Api.Services;

public class BookService
{
    private static readonly List<Book> Books = new()
    {
    };

    public IEnumerable<Book> GetAllBooks() => Books;

    public Book? GetBookById(int id) => Books.FirstOrDefault(b => b.Id == id);
}
