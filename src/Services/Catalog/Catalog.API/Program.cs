var builder = WebApplication.CreateBuilder(args);

var configurations = builder.Configuration;

builder.Services
    .AddApiServices(configurations)
    .AddApplicationServices(configurations)
    .AddInfrastructureServices(configurations);

var app = builder.Build();

app.UseApiServices();

app.Run();
