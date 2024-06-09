using Dotnet_4.APIs;

namespace Dotnet_4;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IMorsService, MorsService>();
        services.AddScoped<IOrdersService, OrdersService>();
    }
}
