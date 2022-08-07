using Hometask.DAL.Data;
using Hometask.DAL.Interfaces;
using Hometask.DAL.Models;

namespace Hometask.DAL.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IRepository<Book>> _lazyBookRepository;
    private readonly Lazy<IRepository<Review>> _lazyReviewRepository;
    private readonly Lazy<IRepository<Rating>> _lazyRatingRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(LibraryContext dbContext)
    {
        _lazyBookRepository = new Lazy<IRepository<Book>>(() => new BookRepository(dbContext));
        _lazyReviewRepository = new Lazy<IRepository<Review>>(() => new ReviewRepository(dbContext));
        _lazyRatingRepository = new Lazy<IRepository<Rating>>(() => new RatingRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }

    public IRepository<Book> BookRepository => _lazyBookRepository.Value;
    public IRepository<Review> ReviewRepository => _lazyReviewRepository.Value;
    public IRepository<Rating> RatingRepository => _lazyRatingRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}

