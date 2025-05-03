using MiniMarket.DTOs;

namespace MiniMarket.Interfaces;

public interface IOrderService
{
    Task PlaceOrderAsync(int userId);
    Task <IEnumerable<OrderDTO>> GetUsersOrders(int userId);
    Task <OrderDTO?> GetOrderDetails(int orderId);
}