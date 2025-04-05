using Liberos.Api.Data;
using Liberos.Api.Interfaces;

namespace Liberos.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IUserRepository? _userRepo;

    private IBookRepository? _bookRepo;

    public LiberosDbContext Context;

    public UnitOfWork(LiberosDbContext context)
    {
        Context = context;
    }

    public IUserRepository UserRepository
    {
        get { return _userRepo = _userRepo ?? new UserRepository(Context); }
    }

    public IBookRepository BookRepository
    {
        get { return _bookRepo = _bookRepo ?? new BookRepository(Context); }
    }

    public void Commit()
    {
        Context.SaveChanges();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
