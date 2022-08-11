namespace Hometask.BLL.DTO;

public class GetBooksResponse : BaseDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Rating { get; set; }
    public decimal ReviewsNumber { get; set; }
}