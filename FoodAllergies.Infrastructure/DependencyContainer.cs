using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Infrastructure.Persistence.Contexts;
using FoodAllergies.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodAllergies.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection RegisterInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddDbContext<FoodAllergiesDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FoodAllergiesDbContext"));
        });

        _ = services.AddScoped<IUserRepository, UserRepository>().
            AddScoped<IFoodRepository, FoodRepository>()
            .AddScoped<IIngredientRepository, IngredientRepository>();

        return services;
    }
}