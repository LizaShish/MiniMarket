namespace MiniMarket.Models;

public class OrderItem
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
    public int ProductPrice { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
}