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

    public PagedList<Content> GetContents(ContentsParameters contentParams)
    {
        var contents = GetAll().OrderBy(p => p.Id).AsQueryable();
        var orderedContents = PagedList<Content>.ToPagedList(contents, contentParams.PageNumber, contentParams.PageSize);

        return orderedContents;
    }
}
