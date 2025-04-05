namespace Liberos.Api.Interfaces;
public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IBookRepository BookRepository { get; }
    void Commit();
}
