namespace MiniMarket.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    
}