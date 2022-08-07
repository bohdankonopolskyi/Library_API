namespace Hometask.BLL.DTO;

public class ReviewDto : BaseDto
{
    public string Message { get; set; }
    public int BookId { get; set; }
    public BookDto Book { get; set; }
    public string Reviewer { get; set; }
}