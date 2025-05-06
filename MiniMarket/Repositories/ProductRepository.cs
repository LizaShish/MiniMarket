using Microsoft.EntityFrameworkCore;
using MiniMarket.Interfaces;
using MiniMarket.Models;

namespace MiniMarket.Repositories;

public  class ProductRepository :IProductRepository
{
    private readonly AppDBContext _appDbContext;

    public ProductRepository(AppDBContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Product>> GetAll(string searchString, int page, int pageSize)
    {
        return await _appDbContext.Products
            .Where(p => string.IsNullOrEmpty(searchString) || p.ProductName.Contains(searchString))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _appDbContext.Products.FindAsync(id);
    }
    
    public async Task AddAsync(Product product) // Admin
    {
        var addProduct = new Product()
        {
            ProductName = product.ProductName,
            CategoryId = product.CategoryId,
            ProductDescription = product.ProductDescription,
            Price = product.Price,
            ProductImageUrl = product.ProductImageUrl,
            QuantityOnStock = product.QuantityOnStock
        };
        await _appDbContext.Products.AddAsync(addProduct);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product) // Admin
    {
        var updateProduct = await _appDbContext.Products.FindAsync(product.Id);
        if (updateProduct != null)
        {
            updateProduct.ProductName = product.ProductName;
            updateProduct.CategoryId = product.CategoryId;
            updateProduct.ProductDescription = product.ProductDescription;
            updateProduct.Price = product.Price;
            updateProduct.ProductImageUrl = product.ProductImageUrl;
            updateProduct.QuantityOnStock = product.QuantityOnStock;
            await _appDbContext.SaveChangesAsync();
        }
    }
    public IQueryable<Product> GetQueryable()
    {
        return _appDbContext.Products.AsQueryable();
    }
    public async Task DeleteAsync(int id) // Admin
    {
        var product = await _appDbContext.Products.FindAsync(id);
        if (product != null)
        {
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}