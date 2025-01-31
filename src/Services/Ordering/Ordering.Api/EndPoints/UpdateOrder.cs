
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.Api.EndPoints;


public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderResponse(bool IsSuccess);
public class UpdateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("Orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            var order = request.Adapt<UpdateOrderCommand>();

            var result = await sender.Send(order);

            var response = result.Adapt<UpdateOrderResponse>();

            return Results.Ok(response);

        }).WithName("UpdateOrder")
            .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Order Updated")
            .WithDescription("Order Updated");
    }
}
