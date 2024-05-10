using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FoodAllergies.Application;

public static class DependencyContainer
{
    public static IServiceCollection RegisterApplicationDependency(this IServiceCollection services)
    {
        _ = services.AddMediatR(mediatR =>
        {
            _ = mediatR.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}