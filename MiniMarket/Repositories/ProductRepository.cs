using MiniMarket.Interfaces;

namespace MiniMarket.Repositories;

public class ProductRepository :IProductRepository
{
    private readonly AppDBContext _appDbContext;

    public ProductRepository(AppDBContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
}