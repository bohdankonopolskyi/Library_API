using Hometask.BLL.DTO;

namespace Hometask.BLL.Services.Abstractions;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
    Task<IEnumerable<BookDto>> GetTopBooksAsync();
    Task<BookDto> GetBookByIdAsync(int id);
    Task<BookDto> CreateBookAsync(BookDto book);
    Task DeleteBookByIdAsync(int id);
}