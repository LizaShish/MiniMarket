using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MiniMarket;

public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
{
    public AppDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();

        // Укажи свою строку подключения к PostgreSQL
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432; Database=MiniMarket3;Username=postgres;Password=Qwertyuiop89");

        return new AppDBContext(optionsBuilder.Options);
    }
}