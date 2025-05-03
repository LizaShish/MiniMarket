using AutoMapper;
using MiniMarket.DTOs;
using MiniMarket.Interfaces;

namespace MiniMarket.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public CartService(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CartDTO> GetCart(int userId)
    {
        var cart = await _cartRepository.GetCart(userId);
        var itemsDTO = _mapper.Map<List<CartItemDTO>>(cart.Items);
        var cartDTO = new CartDTO
        {
            UserId = userId,
            Items = itemsDTO,
            TotalCount= itemsDTO.Sum(i=>i.Quantity),
            TotalPrice = itemsDTO.Sum(i=>i.Total)
        };
        return cartDTO;
    }

    public async Task AddToCartAsync(int productId, int userId, int quantity )
    {
        var product = await _productRepository.GetById(productId);
        if(product==null)
            throw new Exception("Product not found");

        await _cartRepository.AddToCartAsync(userId, productId, quantity);
    }

    public async Task RemoveFromCartAsync(int productId, int userId)
    {
        await _cartRepository.RemoveFromCartAsync(userId, productId);
    }
    public async Task ClearCartAsync(int userId)
    {
        await _cartRepository.ClearCartAsync(userId);
    }
}