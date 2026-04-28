namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();


        var assembly = typeof(Application.DependencyInjection).Assembly;
        serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });
        
        return serviceCollection;
    }

    public static WebApplication UseApiServices(
        this WebApplication application
        )
    {
        application.MapControllers();

        application.UseSwagger();
        application.UseSwaggerUI();
        
        application.MapGet("/", () => "Hello World!");
        
        return application; 
    }
}