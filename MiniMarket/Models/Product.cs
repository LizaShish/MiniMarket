namespace MiniMarket.Models;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal Price { get; set; }
    public string ProductImageUrl { get; set; }
    public int CategoryId { get; set; }
    public int QuantityOnStock { get; set; }
    
    
}