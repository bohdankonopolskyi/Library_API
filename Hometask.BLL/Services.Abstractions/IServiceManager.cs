namespace Hometask.BLL.Services.Abstractions;

public interface IServiceManager
{
    IBookService BookService { get; }
    IReviewService ReviewService { get; }
    IRatingService RatingService { get; }
}