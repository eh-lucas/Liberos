using Liberos.Api.Data;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;

namespace Liberos.Api.Repositories;
public class UserLibraryRepository : Repository<UserLibrary>, IUserLibraryRepository
{
    public UserLibraryRepository(LiberosDbContext context) : base(context)
    {
    }
}
