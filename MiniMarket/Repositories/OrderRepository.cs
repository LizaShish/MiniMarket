using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniMarket.Interfaces;
using MiniMarket.Models;

namespace MiniMarket.Repositories;

public class OrderRepository:IOrderRepository
{
    private readonly AppDBContext _appDbContext;
    public OrderRepository(AppDBContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddOrderAsync(Order order)
    {
        await _appDbContext.Orders.AddAsync(order);
        await _appDbContext.SaveChangesAsync();
    }

    public  async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        return await _appDbContext.Orders
            .Where(o => o.UserId.ToString() == userId)   
            .Include(o => o.Items)             
            .ThenInclude(i => i.Product)       
            .ToListAsync();                 
    }
    
    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _appDbContext.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
    
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _appDbContext.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .ToListAsync();
    }

    public async Task UpdateOrderStatusAsync(int orderId, string newStatus)
    {
        var order = await _appDbContext.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = newStatus;
            await _appDbContext.SaveChangesAsync();
        }
    }
}