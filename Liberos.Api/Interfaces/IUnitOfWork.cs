namespace Liberos.Api.Interfaces;
public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IBookRepository BookRepository { get; }
    IContentRepository ContentRepository { get; }
    Task CommitAsync();
}
