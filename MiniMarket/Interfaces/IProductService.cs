using MiniMarket.DTOs;
using MiniMarket.Models;

namespace MiniMarket.Interfaces;

public interface IProductService
{
    Task<IQueryable<ProductDTO>> GetProduct();
    Task<ProductDTO?> GetProductById(int id);
    Task CreateAsync(ProductDTO productDTO);
    Task UpdateAsync(ProductDTO productDTO);
    Task DeleteAsync(int id);
}