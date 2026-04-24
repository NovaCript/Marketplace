using Catalog.Domain.Repository;
using Catalog.Infrastructure.Data.Seed;
using Catalog.Infrastructure.Repositories;
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
            opt.Connection(connectionString!);
        })
            .UseLightweightSessions()
            .InitializeWith<InitializeDatabaseAsync>();


        serviceCollection.AddScoped<CatalogRepository>();
        
        serviceCollection.AddScoped<IBrandRepository>(sp =>
            sp.GetRequiredService<CatalogRepository>());
        serviceCollection.AddScoped<ICategoryRepository>(sp =>
            sp.GetRequiredService<CatalogRepository>());
        serviceCollection.AddScoped<ICatalogItemRepository>(sp =>
            sp.GetRequiredService<CatalogRepository>());
        
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return serviceCollection;
    }
}