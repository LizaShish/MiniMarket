using MiniMarket.Models;

namespace MiniMarket.Interfaces;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<Order?> GetOrderByIdAsync(int orderId);
}