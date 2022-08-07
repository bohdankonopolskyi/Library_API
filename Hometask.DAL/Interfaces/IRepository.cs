using System.Linq.Expressions;
using Hometask.DAL.Models;

namespace Hometask.DAL.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);

    Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);

}