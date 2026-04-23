using Catalog.Infrastructure.Data.Seed;
using Marten;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
    {

        var connectionString = configuration.GetConnectionString("PgConnection");

        serviceCollection.AddMarten(opt =>
        {
            opt.Connection(connectionString);
        })
            .UseLightweightSessions()
            .InitializeWith<InitializeDatabaseAsync>();
        
        
        
        return serviceCollection;
    }
}