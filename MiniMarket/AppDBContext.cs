using Microsoft.EntityFrameworkCore;
using MiniMarket.Models;

namespace MiniMarket;

public class AppDBContext: DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}
    
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
}