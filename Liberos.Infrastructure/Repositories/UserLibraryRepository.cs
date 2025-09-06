using Liberos.Domain.Models;
using Liberos.Domain.Interfaces;
using Liberos.Infrastructure.Data;

namespace Liberos.Infrastructure.Repositories;
public class UserLibraryRepository : Repository<UserLibrary>, IUserLibraryRepository
{
    public UserLibraryRepository(LiberosDbContext context) : base(context)
    {
    }
}
