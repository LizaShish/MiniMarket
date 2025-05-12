using AutoMapper;
using MiniMarket.DTOs;
using MiniMarket.Interfaces;
using MiniMarket.Models;
using System.Linq;


namespace MiniMarket.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductDTO>> GetProduct()
    {
        string search = "";
        int page = 1;
        int pageSize = 10;
        
        var products = await _productRepository.GetAll(search, page, pageSize);
        return _mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO?> GetProductById(int id)
    {
        var product = await _productRepository.GetById(id);
        return product == null? null:_mapper.Map<ProductDTO>(product);
    }

    public async Task CreateAsync(ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        await _productRepository.AddAsync(product);
    }
    public async Task UpdateAsync(ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        await _productRepository.UpdateAsync(product);
    }
    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
    
    public IQueryable<ProductDTO> GetFilteredProducts(string? category, string? searchQuery)
    {
        var query = _productRepository.GetQueryable();

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category == category);

        if (!string.IsNullOrWhiteSpace(searchQuery))
            query = query.Where(p => p.ProductName.Contains(searchQuery));

        return query.Select(p => new ProductDTO
        {
            Id = p.Id,
            Name = p.ProductName,
            Price = p.Price,
            ImageUrl = p.ImageUrl
        });
    }
}