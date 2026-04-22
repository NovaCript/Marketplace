namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
    {
        return serviceCollection;
    }
}