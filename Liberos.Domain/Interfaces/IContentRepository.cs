using Liberos.Domain.Models;
using Liberos.Domain.Pagination;

namespace Liberos.Domain.Interfaces;
public interface IContentRepository : IRepository<Content>
{
    Task<PagedList<Content>> GetContentsAsync(ContentsParameters contentParams);
}

