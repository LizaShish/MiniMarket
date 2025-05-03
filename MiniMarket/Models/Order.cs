namespace MiniMarket.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    
    public int UserId { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}