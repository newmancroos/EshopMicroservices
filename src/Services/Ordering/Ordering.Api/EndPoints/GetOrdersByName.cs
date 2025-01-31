
using Ordering.Application.Orders.Queries.GetOrdersByname;

namespace Ordering.Api.EndPoints;

//public record GetOrderByName(String Name);

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
        {
            var result =await sender.Send(new GetOrdersByNameQuery(orderName));

            var response = result.Adapt<GetOrdersByNameResponse>();

            return Results.Ok(response);

        }).WithName("GetOrdersByName")
            .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Name")
            .WithDescription("Get Orders By Name");
    }
}
