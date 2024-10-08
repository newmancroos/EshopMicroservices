
namespace Basket.API.Basket.DeletBasket
{

   // public record DeleteBasketRequest(string UIserName);
   public record DeleteBasketResponse(bool IsSuccess);

    public class DeleteBasketEndpointes : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{UserName}", async (string UserName, ISender sender) =>
            {
                var result = sender.Send(new DeleteBasketCommand(UserName));
                var response = result.Adapt<DeleteBasketResponse>();

                return Results.Ok(response);
            })
             .WithName("DeleteProduct")
             .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Delete Product")
             .WithDescription("Delete Product");
        }
    }
}
