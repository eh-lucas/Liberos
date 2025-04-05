using Liberos.Api.Data;
using Liberos.Api.Interfaces;

namespace Liberos.Api.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private IUserRepository? _userRepo;

    private IBookRepository? _bookRepo;

    public LiberosDbContext _context;
    public UnitOfWork(LiberosDbContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepo = _userRepo ?? new UserRepository(_context);
        }
    }
    public IBookRepository BookRepository
    {
        get
        {
            return _bookRepo = _bookRepo ?? new BookRepository(_context);
        }
    }
    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
