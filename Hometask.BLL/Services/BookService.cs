using Hometask.BLL.DTO;
using Hometask.BLL.Services.Abstractions;
using Hometask.DAL.Interfaces;

namespace Hometask.BLL.Services;

public class BookService : IBookService
{
    private readonly IRepositoryManager _repositoryManager;

    public BookService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookDto> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BookDto> CreateBookAsync(BookDto book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}