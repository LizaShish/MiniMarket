using MiniMarket.DTOs;
using MiniMarket.Interfaces;
using MiniMarket.Models;

namespace MiniMarket.Services;
public class ProductService : IProductService
{
    public IQueryable<ProductDTO> GetProduct()
    {
        var products = new List<ProductDTO>
        {
            new ProductDTO
            {
                Name = "Name",
                Price = 100,
                Description = "Description",
                Image = "Image"
            }
        };
        return products.AsQueryable();
    }

}