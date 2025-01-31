using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Api.EndPoints;


public record CreateOrderRequest(OrderDto Order);

public record CreateOrderResponse(Guid Id);

public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
        { 
            var commnad = request.Adapt<CreateOrderCommand>();

            var result = await sender.Send(commnad);

            var response = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/orders/{response.Id}", response);
        }).WithName("CreateOrder")
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Order Created")
            .WithDescription("Order Created");
    }
}
