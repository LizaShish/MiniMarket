using Microsoft.EntityFrameworkCore;
using MiniMarket.Interfaces;
using MiniMarket.Models;

namespace MiniMarket.Repositories;

public class CartRepository:ICartRepository
{
    private readonly AppDBContext _appDbContext;

    public CartRepository(AppDBContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Cart> GetCart(int userId)
    {
        var cart =  await _appDbContext.Carts
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId,
                Items = new List<CartItem>()
            };
            await _appDbContext.Carts.AddAsync(cart);
            await _appDbContext.SaveChangesAsync();
        }
        return cart;
    }

    public async Task AddToCartAsync(int userId, int productId, int quantity)
    {
        var cart =  await _appDbContext.Carts
            .FirstOrDefaultAsync(x => x.UserId == userId);
        var productInCart = cart?.Items.FirstOrDefault(x => x.ProductId == productId);
        if (productInCart != null)
        {
            productInCart.Quantity += quantity;
        }
        else
        {
            cart?.Items.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity
            });
        }
        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveFromCartAsync(int userId, int productId)
    {
        var cart =  await _appDbContext.Carts
            .FirstOrDefaultAsync(x => x.UserId == userId);
        var productInCart = cart?.Items.FirstOrDefault(x => x.ProductId == productId);
        if (productInCart != null)
        {
            cart?.Items.Remove(productInCart);
        }
        await _appDbContext.SaveChangesAsync();
    }

    public async Task ClearCartAsync(int userId)
    {
        var cart =  await _appDbContext.Carts
            .FirstOrDefaultAsync(x => x.UserId == userId);
        cart?.Items.Clear();
        await _appDbContext.SaveChangesAsync();
    }
}