using MiniMarket.DTOs;
using MiniMarket.Models;

namespace MiniMarket.Interfaces;

public interface IProductService
{
    Task<List<ProductDTO>> GetProduct();
    Task<ProductDTO?> GetProductById(int id);
    Task CreateAsync(ProductDTO productDTO);
    Task UpdateAsync(ProductDTO productDTO);
    Task DeleteAsync(int id);
    IQueryable<ProductDTO> GetFilteredProducts(string? category, string? searchQuery);
}