using MiniMarket.Models;

namespace MiniMarket.DTOs;

public class CartDTO
{
    public int UserId { get; set; }
    public List<CartItemDTO> Items { get; set; } = new();
    public int TotalCount { get; set; }
    public decimal TotalPrice { get; set; }
}