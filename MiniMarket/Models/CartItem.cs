namespace MiniMarket.Models;

public class CartItem
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}