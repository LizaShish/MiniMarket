using AutoMapper;
using MiniMarket.Interfaces;
using MiniMarket.Models;
using MiniMarket.DTOs;

namespace MiniMarket.Services;

public class OrderService : IOrderService
{
  private  readonly IProductRepository _productRepository;
  private readonly IMapper _mapper;
  private readonly ICartService _cartService;
  private readonly IOrderRepository _orderRepository;


  public OrderService(IProductRepository productRepository, IMapper mapper, ICartService cartService, IOrderRepository orderRepository)
  {
    _productRepository = productRepository;
    _mapper = mapper;
    _cartService = cartService;
    _orderRepository = orderRepository;
  }

  public async Task PlaceOrderAsync(int userId)
  {
    var cart = await _cartService.GetCart(userId);
    
    if(cart.Items.Count()==0)
      throw new Exception("Cart is empty");

    var order = new Order
    { 
      UserId = userId,  
      OrderDate = DateTime.Now,
      Items = cart.Items.Select(item => new OrderItem
      {
        ProductId = item.ProductId,
        Quantity = item.Quantity,
        ProductPrice = item.Price  
      }).ToList()
    };

    await _orderRepository.AddOrderAsync(order);
    await _cartService.ClearCartAsync(userId);
  }

  public async Task<IEnumerable<OrderDTO>> GetUsersOrders(int userId)
  {
    var orders = await _orderRepository.GetOrderByIdAsync(userId);
    return _mapper.Map<IEnumerable<OrderDTO>>(orders);
  }

  public async Task<OrderDTO?> GetOrderDetails(int orderId)
  {
    var order = await _orderRepository.GetOrderByIdAsync(orderId);
    if(order == null)
      return null;
    return _mapper.Map<OrderDTO>(order);
  }

  public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
  {
    var orders = await _orderRepository.GetAllOrdersAsync();
    return _mapper.Map<IEnumerable<OrderDTO>>(orders);
  }

  public async Task UpdateOrderStatusAsync(int orderId, string newStatus)
  {
    await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus);
  }
  
}