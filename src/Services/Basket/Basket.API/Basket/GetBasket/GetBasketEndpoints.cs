
namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string Username);

public record GetBasketRespone(ShoppingCart Cart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{UserName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var response = result.Adapt<GetBasketRespone>();

            return Results.Ok(response);       
         }).WithName("GetBasket")
            .Produces<GetBasketRespone>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
    }
}
