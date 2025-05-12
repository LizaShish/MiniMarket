using Microsoft.AspNetCore.Identity;
namespace MiniMarket;

public static class DbInitializer
{
    public static async Task SeedRolesAndAdminAsync(this IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        
        string[]  roles = { "Admin", "User" };
        IdentityResult roleResult;
        foreach (var role in roles)
        {
           
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole<int>(role));
            
        }
        // Создание администратора
        var adminEmail = "admin@minimarket.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        
        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = "Admin", 
                Email = adminEmail,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}