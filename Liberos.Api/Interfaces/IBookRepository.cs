using Liberos.Api.Models;
using Liberos.Api.Pagination;

namespace Liberos.Api.Interfaces;
public interface IBookRepository : IRepository<Book>
{
    //IEnumerable<Book> GetBooks(BooksParameters booksParams);
    PagedList<Book> GetBooks(BooksParameters booksParams);
}
