using Liberos.Api.Models;
using Liberos.Api.Pagination;

namespace Liberos.Api.Interfaces;
public interface IBookRepository : IRepository<Book>
{
    //IEnumerable<Book> GetBooks(BooksParameters booksParams);
    Task<PagedList<Book>> GetBooksAsync(BooksParameters booksParams);
}
