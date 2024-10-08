
namespace CatalogAPI.Products.GetProducts
{

    public record GetProductsQuery(int? PageNumber, int? PageSize = 10) : IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Product> Products);
    public class GetProductsQueryHandler (IDocumentSession session) 
        : IQueryHandler<GetProductsQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            //logger.LogInformation("GetProductsQueryHandler.Handler called with {@Query}", query);
            var products =await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10,cancellationToken);

            return  new GetProductResult(products);
        }
    }
}
