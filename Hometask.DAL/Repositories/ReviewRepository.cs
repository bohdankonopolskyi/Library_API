using Hometask.DAL.Data;
using Hometask.DAL.Models;

namespace Hometask.DAL.Repositories;

public sealed class ReviewRepository : Repository<Review>
{
    public ReviewRepository(LibraryContext context) : base(context)
    {
    }
}