using Hometask.DAL.Models;

namespace Hometask.DAL.Interfaces;

public interface IRepositoryManager
{
     IRepository<Book> BookRepository { get; }
    IRepository<Review> ReviewRepository { get; }
    IRepository<Rating> RatingRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}