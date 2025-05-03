using MiniMarket.Models;


namespace MiniMarket.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCart(int userId);
    Task AddToCartAsync(int userId, int productId, int quantity);
    Task RemoveFromCartAsync(int userId, int productId);
    Task ClearCartAsync(int userId);
}

