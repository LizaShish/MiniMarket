using MiniMarket.DTOs;
using MiniMarket.Models;

namespace MiniMarket.Interfaces;

public interface IProductService
{
    IQueryable<ProductDTO> GetProduct();
}