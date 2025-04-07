using Liberos.Api.Data;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;

namespace Liberos.Api.Repositories;
public class ContentRepository : Repository<Content>, IContentRepository
{
    public ContentRepository(LiberosDbContext context) : base(context)
    {
    }
}
