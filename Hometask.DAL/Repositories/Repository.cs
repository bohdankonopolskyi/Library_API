using System.Linq.Expressions;
using Hometask.DAL.Data;
using Hometask.DAL.Interfaces;
using Hometask.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Hometask.DAL.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly LibraryContext _context;


    protected Repository(LibraryContext context)
    {
        _context = context;
    }


    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return  Task.FromResult<IEnumerable<TEntity>>(_context.Set<TEntity>().AsNoTracking());
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
    }
    public Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate) => Task.FromResult(_context.Set<TEntity>().Where(predicate).AsNoTracking());

    public void Add(TEntity entity)
    {
        if (entity != null) 
            _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        if (entity != null) 
            _context.Set<TEntity>().Update(entity);
    }

    public  void Delete(TEntity entity)
    {
        if (entity != null) 
            _context.Set<TEntity>().Remove(entity);
    }
}