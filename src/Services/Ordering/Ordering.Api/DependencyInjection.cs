using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;

namespace Ordering.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Add services to container

        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddHealthChecks() //This line only health for Api, Adding Aspnetcore.HealthCheck.SqlServer and Aspnetcore.Healthcheck.UI we can do more
            .AddSqlServer(configuration.GetConnectionString("Database")!);

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();
        app.UseExceptionHandler(options => { });
        //app.UseHealthChecks("/health"); // After adding Sql server and UI we need to configurare it here
        app.UseHealthChecks("/health",
            new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions 
            { 
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        return app;
    }
}
