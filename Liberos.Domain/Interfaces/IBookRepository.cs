using Liberos.Domain.Models;
using Liberos.Domain.Pagination;

namespace Liberos.Domain.Interfaces;
public interface IBookRepository : IRepository<Book>
{
    //IEnumerable<Book> GetBooks(BooksParameters booksParams);
    Task<PagedList<Book>> GetBooksAsync(BooksParameters booksParams);
}
