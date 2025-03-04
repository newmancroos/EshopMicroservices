namespace Shopping.Web.Services;

public interface ICatalogService
{
    [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetProductsResponse> GetProducts(int? pageNumber=1, int? pageSize = 10);

    [Get("/catalog-Service/products/{id}")]
    Task<GetProductByIdResponse> GetProduct(Guid id);

    [Get("/catalog-Service/products/category/{category}")]
    Task<GetProductByCategoryResponse> GetProductsByCategory(string category);

}
