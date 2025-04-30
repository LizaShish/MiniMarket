using MiniMarket.Models;

namespace MiniMarket.DTOs;

public class ProductDTO
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    
}