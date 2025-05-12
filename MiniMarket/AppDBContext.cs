using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniMarket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MiniMarket;

public class AppDBContext: IdentityDbContext<ApplicationUser,IdentityRole<int>, int>
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    
}