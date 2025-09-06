using Liberos.Api.Models;
using Liberos.Api.Pagination;

namespace Liberos.Api.Interfaces;
public interface IContentRepository : IRepository<Content>
{
    Task<PagedList<Content>> GetContentsAsync(ContentsParameters contentParams);
}

