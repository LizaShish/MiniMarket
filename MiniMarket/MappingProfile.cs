using AutoMapper;
using MiniMarket.DTOs;
using MiniMarket.Models;


namespace MiniMarket;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
            // Order → OrderDTO
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TotalPrice, opt 
                    => opt.MapFrom(
                    src => src.Items.Sum(i => i.ProductPrice * i.Quantity)));

            // OrderItem → OrderItemDTO
            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.ProductName, opt 
                    => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<Product, ProductDTO>();

            // CartItem → CartItemDTO
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(dest => dest.ProductName, opt 
                    => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.Price, opt 
                    => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Total, opt 
                    => opt.MapFrom(src => src.Quantity * src.Product.Price));
            
            // CartItem → CartItemDTO
            CreateMap<Cart, CartDTO>().ReverseMap();
            
        
        
    }
}