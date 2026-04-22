namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
    {
        return serviceCollection;
    }
}