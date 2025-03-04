using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shopping.Web.Pages
{
    public class ProductListModel(ICatalogService catalogService, IBasketService basketServices, ILogger<ProductListModel> logger) : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } = [];
        public IEnumerable<string> CategoryList { get; set; } = [];

        [BindProperty(SupportsGet =true)]
        public string SelectedCategory { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var response = await catalogService.GetProducts();
            CategoryList = response.Products.SelectMany(c => c.Category).Distinct();

            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                ProductList = response.Products.Where(c => c.Category.Contains(categoryName)).ToList();
                SelectedCategory = categoryName;
            }
            else
            {
                ProductList = response.Products;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked");

            var productResponse = await catalogService.GetProduct(productId);

            var basket = await basketServices.LoadUserBasket();

            basket.Items.Add(new ShoppingCartItemModel
            {
                ProductId = productId,
                ProductName = productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity =1,
                Color="Black"
            });

            await basketServices.StoreBasket(new StoreBasketRequest(basket));

            return RedirectToPage("Cart");
        }
    }
}
