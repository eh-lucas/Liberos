using Liberos.Api.Data;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;

namespace Liberos.Api.Repositories;
public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(LiberosDbContext context) : base(context)
    {
    }
}
