using MiniMarket.DTOs;
namespace MiniMarket.Models;
public class ProductListViewModel
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public string? Category { get; set; }
    public List<ProductDTO> Products { get; set; }
    
}