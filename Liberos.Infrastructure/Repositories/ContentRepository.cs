using Liberos.Domain.Models;
using Liberos.Domain.Interfaces;
using Liberos.Domain.Pagination;
using Liberos.Infrastructure.Data;

namespace Liberos.Infrastructure.Repositories;
public class ContentRepository : Repository<Content>, IContentRepository
{
    public ContentRepository(LiberosDbContext context) : base(context)
    {
    }

    public async Task<PagedList<Content>> GetContentsAsync(ContentsParameters contentParams)
    {
        var contents = await GetAllAsync();
        var orderedContents = contents.OrderBy(p => p.Id).AsQueryable();
        var result = PagedList<Content>.ToPagedList(orderedContents, contentParams.PageNumber, contentParams.PageSize);

        return result;
    }
}
