using Asp.Versioning;
using Microsoft.OpenApi;

namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
    {

        serviceCollection.AddApiVersioning(opt =>
        {
            opt.ReportApiVersions = true;
            opt.AssumeDefaultVersionWhenUnspecified = true;
            // 1.0
            opt.DefaultApiVersion = new ApiVersion(1, 0);
        })
        .AddApiExplorer(opt =>
        {
            opt.GroupNameFormat = "'v'VVV"; // v1
            opt.SubstituteApiVersionInUrl = true;
        });
        
        serviceCollection.AddControllers();
        
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Catalog API",
                Version = "v1"
            });
        });


        var assembly = typeof(Application.DependencyInjection).Assembly;
        var licenseKet = configuration.GetSection("MediatR:LicenseKey").Value;
        serviceCollection.AddMediatR(config =>
        {
            config.LicenseKey = licenseKet;
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