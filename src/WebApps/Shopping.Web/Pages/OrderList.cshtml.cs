namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger) : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("189DC8DC-990F-48E0-A37B-E6F2B60B9D7D");

            var response= await orderingService.GetOrdersByCustomr(customerId);
            Orders = response.Orders;

            return Page();

        }
    }
}
