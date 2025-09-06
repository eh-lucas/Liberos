namespace Liberos.Domain.Interfaces;
public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IBookRepository BookRepository { get; }
    IContentRepository ContentRepository { get; }
    IUserLibraryRepository UserLibraryRepository { get; }
    Task CommitAsync();
}
