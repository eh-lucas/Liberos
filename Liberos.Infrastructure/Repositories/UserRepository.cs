using Liberos.Domain.Models;
using Liberos.Domain.Interfaces;
using Liberos.Infrastructure.Data;

namespace Liberos.Infrastructure.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(LiberosDbContext context) : base(context)
    {
    }
}

