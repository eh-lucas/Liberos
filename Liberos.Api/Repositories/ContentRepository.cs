using Liberos.Api.Data;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Liberos.Api.Pagination;

namespace Liberos.Api.Repositories;
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
