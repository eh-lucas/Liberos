using Liberos.Models;

namespace Liberos.Services;

public class BookService
{
    private static readonly List<Book> Books = new()
    {
        new Book
        {
            Id = 1, Title = "1984", Author = "George Orwell",
            Content = "It was a bright cold day in April, and the clocks were striking thirteen."
        },
        new Book
        {
            Id = 2, Title = "Brave New World", Author = "Aldous Huxley",
            Content = "A squat grey building of only thirty-four stories."
        }
    };

    public IEnumerable<Book> GetAllBooks() => Books;

    public Book? GetBookById(int id) => Books.FirstOrDefault(b => b.Id == id);
}
