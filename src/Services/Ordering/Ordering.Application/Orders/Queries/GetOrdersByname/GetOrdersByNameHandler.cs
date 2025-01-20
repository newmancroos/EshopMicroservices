


using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByname;

public class GetOrdersByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByNameQuery, GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        var orders =await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(query.Name))
            .OrderBy(o => o.OrderName)
            .ToListAsync(cancellationToken);


        //var orderDtos = ProjectToOrderDto(orders);

        //var orderDtos = orders.ToOrderDtoList();

        return new GetOrderByNameResult(orders.ToOrderDtoList());
    }

    //private List<OrderDto> ProjectToOrderDto(List<Order> orders)
    //{

    //    List<OrderDto> result = new();

    //    foreach (var order in orders)
    //    {
    //        var orderDto = new OrderDto(
    //            Id: order.Id.Value,
    //            CustomerId: order.CustomerId.Value,
    //            OrderName: order.OrderName.Value,
    //            ShippingAddress: new AddressDto(
    //                order.ShippingAddress.FirstName,
    //                order.ShippingAddress.LastName,
    //                order.ShippingAddress.EmailAddress,
    //                order.ShippingAddress.AddressLine,
    //                order.ShippingAddress.Country,
    //                order.ShippingAddress.State,
    //                order.ShippingAddress.ZipCode
    //                ),
    //            BillingAddress: new AddressDto
    //            (
    //                order.BillingAddress.FirstName,
    //                order.BillingAddress.LastName,
    //                order.BillingAddress.EmailAddress,
    //                order.BillingAddress.AddressLine,
    //                order.BillingAddress.Country,
    //                order.BillingAddress.State,
    //                order.BillingAddress.ZipCode
    //            ),
    //            Payment: new PaymentDto(
    //                order.Payment.CardName,
    //                order.Payment.CardNumner,
    //                order.Payment.Expiration,
    //                order.Payment.CVV,
    //                order.Payment.PaymentMethod
    //                ),
    //            Status: order.Status,
    //            OrderItems: order.OrderItems.Select(oi => new OrderItemDto(oi.OrderId.Value, oi.ProductId.Value, oi.Quantity, oi.Price)).ToList()
    //            );

    //        result.Add(orderDto); 
    //    }

    //    return result;
    //}
}
