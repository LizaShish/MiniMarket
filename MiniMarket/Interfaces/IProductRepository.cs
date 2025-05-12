using MiniMarket.Models;

namespace MiniMarket.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAll(string searchString, int page, int pageSize);
    Task<Product?> GetById(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    IQueryable<Product> GetQueryable();
    
}