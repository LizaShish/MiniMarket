namespace MiniMarket.DTOs;

public interface CartItemDTO
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public decimal Total => Quantity * Price;
}