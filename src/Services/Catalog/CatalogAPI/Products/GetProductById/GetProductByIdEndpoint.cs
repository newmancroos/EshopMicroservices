

namespace CatalogAPI.Products.GetProductById
{
   // public record GetProductByIdRequest()

    public record GetProductByIdResponse(Product Product);
    public class GetProductByQueryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/{id}", async (Guid id, ISender sender) =>
            {
                //var result = await sender.Send(new GetProductByIdQuery(id));
                var result = sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
                .WithName("GetProductById")
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Id")
                .WithDescription("Get Product By Id");
        }
    }
}
