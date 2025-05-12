using MiniMarket.DTOs;

namespace MiniMarket.Interfaces;

public interface ICartService
{
    Task<CartDTO> GetCart(int userId);
    Task AddToCartAsync(int userId, int productId, int quantity);
    Task RemoveFromCartAsync(int userId, int productId);
    Task ClearCartAsync(int userId);
}