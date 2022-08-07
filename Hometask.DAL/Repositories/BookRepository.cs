using Hometask.DAL.Data;
using Hometask.DAL.Models;

namespace Hometask.DAL.Repositories;

public sealed class BookRepository : Repository<Book>
{
    public BookRepository(LibraryContext context) : base(context)
    {
    }
}