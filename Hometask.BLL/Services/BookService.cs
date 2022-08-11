using AutoMapper;
using System.Linq;
using Hometask.BLL.DTO;
using Hometask.BLL.Services.Abstractions;
using Hometask.DAL.Interfaces;
using Hometask.DAL.Models;

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
        var config = new MapperConfiguration(cnfg => cnfg.CreateMap<Book, BookDto>()
            .ForMember("Id", opt => opt.MapFrom(p => p.Id))
            .ForMember("Title", opt => opt.MapFrom(p=>p.Title))
            .ForMember("Cover", opt=>opt.MapFrom(p=>p.Cover))
            .ForMember("Content", opt=>opt.MapFrom(p=>p.Content))
            .ForMember("Author", opt=>opt.MapFrom(p=>p.Author))
            .ForMember("Genre", opt=>opt.MapFrom(p=>p.Genre))
        );

        var mapper = new Mapper(config);
        
        IEnumerable<Book> books =  _repositoryManager.BookRepository.GetAllAsync().Result;
        IEnumerable<Rating> ratings = _repositoryManager.RatingRepository.GetAllAsync().Result;
        IEnumerable<Review> reviews = _repositoryManager.ReviewRepository.GetAllAsync().Result;
        
        // var booksDto =
        //     mapper.Map<Task<IEnumerable<Book>>, Task<IEnumerable<BookDto>>>(_repositoryManager.BookRepository
        //     .GetAllAsync());
        
        IEnumerable<BookDto> bookDtos = books.GroupJoin(ratings,
            book => book.Id,
            rating => rating.BookId,
            (book, ratings) => new BookDto()
            {
                Id = book.Id, Title = book.Title, Author = book.Author, 
                Rating = ratings.Average(x=>x.Score)
            }
            );

        bookDtos = bookDtos.GroupJoin(reviews,
            book => book.Id,
            review => review.BookId,
            (book, reviews) =>
            {
                book.ReviewsNumber = reviews.Count();
                return book;
            });
        // switch (order)
        // {
        //     case "author":
        //         bookDtos = bookDtos.OrderBy(x => x.Author);
        //         break;
        //     case "title":
        //         bookDtos = bookDtos.OrderBy(x => x.Title);
        //         break;
        // }
        return Task.FromResult(bookDtos);
    }

    public Task<IEnumerable<BookDto>> GetTopBooksAsync()
    {
        var books = this.GetAllBooksAsync().Result;
        var topBooks = books.Where(x => x.ReviewsNumber > 10).OrderBy(x => x.Rating).Take(10);
        return Task.FromResult(topBooks);
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