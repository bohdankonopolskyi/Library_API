using Hometask.DAL.Data;
using Hometask.DAL.Interfaces;

namespace Hometask.DAL.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly LibraryContext _context;
    public UnitOfWork(LibraryContext dbContext)
    {
        _context = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}