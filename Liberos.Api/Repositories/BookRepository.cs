using Liberos.Api.Data;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Liberos.Api.Pagination;

namespace Liberos.Api.Repositories;
public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(LiberosDbContext context) : base(context)
    {
    }

    public PagedList<Book> GetBooks(BooksParameters booksParams)
    {
        var books = GetAll().OrderBy(p => p.Id).AsQueryable();
        var orderedBooks = PagedList<Book>.ToPagedList(books, booksParams.PageNumber, booksParams.PageSize);

        return orderedBooks;
    }
    //public IEnumerable<Book> GetBooks(BooksParameters booksParams)
    //{
    //    return GetAll()
    //        .OrderBy(b => b.Title)
    //        .Skip((booksParams.PageNumber - 1) * booksParams.PageSize)
    //        .Take(booksParams.PageSize).ToList();
    //}
}
