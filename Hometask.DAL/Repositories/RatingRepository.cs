using Hometask.DAL.Data;
using Hometask.DAL.Models;

namespace Hometask.DAL.Repositories;

public sealed class RatingRepository : Repository<Rating>
{
    public RatingRepository(LibraryContext context) : base(context)
    {
    }
}