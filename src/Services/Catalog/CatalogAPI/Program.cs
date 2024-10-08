using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Add services to the Container


var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    //config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
});


builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();

//Configure the HTPP request pipeline
app.MapCarter();
app.UseExceptionHandler(options => { });

////We developed CustomeExceptionHandle class under BuildingBlcok project
//app.UseExceptionHandler(exceptionHandlerApp =>
//{
//    exceptionHandlerApp.Run(async context =>
//    {
//        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

//        if (exception == null)
//            return;

//        var problemDetails = new ProblemDetails
//        {
//            Title = exception.Message,
//            Status = StatusCodes.Status500InternalServerError,
//            Detail = exception.StackTrace
//        };

//        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
//        logger.LogError(exception, exception.Message);

//        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
//        context.Response.ContentType = "application/problem+json";

//        await context.Response.WriteAsJsonAsync(problemDetails);
//    });
//});

///Install AspNetCore.Diagnostics.HealthChecks  Nuget package for complete health check AddHealthCheck and UseHealCheck are in build and very basic
///To health check the Api not database and supporting tools
///Got to https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
///Open Postgres Nuget package url and copy the commend to install this Nuget package
///Install-Package AspNetCore.HealthChecks.Npgsql
///https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks  also have UI component to check it in a UI, 
///Install (UI.Client) it for clear view

app.UseHealthChecks("/health",
    new HealthCheckOptions
    { 
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
