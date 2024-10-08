using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);  // We use Username property as Identity/PrimaryKey, We can also use [Identity] in ShoppingCart UserName property
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
}
);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

//builder.Services
var app = builder.Build();

//Configure the HTTP request pipeline

app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();
