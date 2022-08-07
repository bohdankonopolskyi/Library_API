namespace Hometask.DAL.Models;

public class Rating : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public decimal Score { get; set; }
}