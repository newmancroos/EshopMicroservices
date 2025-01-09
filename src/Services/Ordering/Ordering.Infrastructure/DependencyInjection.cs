using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        //Add services to container
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptors>();
        services.AddScoped<ISaveChangesInterceptor,DispatchDomainEventsInterceptor>();


        //We'll get exception when we use options.AddInterceptors(new AuditableEntityInterceptors(), new DispatchDomainEventsInterceptor());
        // because  has IMediator injected but AddInterceptor doesn't have the option to inject it
        //So regsiter the interceptors as above in the AddScope a and using Service provider(sp) and add all interceptors that inhertits ISaveChangesInterceptor
        //services.AddDbContext<ApplicationDbContext>(options =>
        //{
        //    options.AddInterceptors(new AuditableEntityInterceptors(), new DispatchDomainEventsInterceptor());
        //    options.UseSqlServer(connectionString);
        //});

        services.AddDbContext<ApplicationDbContext>((sp,options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}
