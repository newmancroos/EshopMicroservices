
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid Id);

    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result =await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            }).WithName("Deleteroduct")
                .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Product Deleted")
                .WithDescription("Product Deleted");
        }
    }
}
