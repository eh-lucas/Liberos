using Liberos.Api.Data;
using Liberos.Api.Interfaces;

namespace Liberos.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IUserRepository? _userRepo;

    private IBookRepository? _bookRepo;

    private IContentRepository? _contentRepo;

    private IUserLibraryRepository? _userLibraryRepo;

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

    public IContentRepository ContentRepository
    {
        get { return _contentRepo = _contentRepo ?? new ContentRepository(Context); }
    }
    public IUserLibraryRepository UserLibraryRepository
    {
        get { return _userLibraryRepo = _userLibraryRepo ?? new UserLibraryRepository(Context); }
    }

    public async Task CommitAsync()
    {
        await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
