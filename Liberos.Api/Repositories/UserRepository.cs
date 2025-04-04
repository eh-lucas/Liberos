using Liberos.Api.Data;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;

namespace Liberos.Api.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(LiberosDbContext context) : base(context)
    {
    }
}

