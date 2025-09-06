using Liberos.Domain.Models;
using Liberos.Domain.Interfaces;
using Liberos.Infrastructure.Data;
using Liberos.Domain.Pagination;

namespace Liberos.Infrastructure.Repositories;
public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(LiberosDbContext context) : base(context)
    {
    }

    public async Task<PagedList<Book>> GetBooksAsync(BooksParameters booksParams)
    {
        var books = await GetAllAsync();
        var orderedBooks = books.OrderBy(p => p.Id).AsQueryable();
        var result = PagedList<Book>.ToPagedList(orderedBooks, booksParams.PageNumber, booksParams.PageSize);

        return result;
    }
    //public IEnumerable<Book> GetBooks(BooksParameters booksParams)
    //{
    //    return GetAll()
    //        .OrderBy(b => b.Title)
    //        .Skip((booksParams.PageNumber - 1) * booksParams.PageSize)
    //        .Take(booksParams.PageSize).ToList();
    //}
}
