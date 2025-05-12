using AutoMapper;
using MiniMarket.DTOs;
using MiniMarket.Models;

namespace MiniMarket.MappingProfiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        CreateMap<CartItem, CartItemDTO>().ReverseMap();
        CreateMap<Cart, CartDTO>().ReverseMap();
    }
}