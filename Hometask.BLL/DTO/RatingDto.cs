namespace Hometask.BLL.DTO;

public class RatingDto : BaseDto
{
    public int BookId { get; set; }
    public BookDto Book { get; set; }
    public decimal Score { get; set; }
}