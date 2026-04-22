namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
        
        return serviceCollection;
    }

    public static WebApplication UseApiServices(
        this WebApplication application
        )
    {

        application.UseSwagger();
        application.UseSwaggerUI();
        
        application.MapGet("/", () => "Hello World!");
        
        return application; 
    }
}