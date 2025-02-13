using BuildingBlock.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
        Id: orderId,
        CustomerId: message.CustomerId,
        OrderName: message.UserName,
        ShippingAddress: addressDto,
        BillingAddress: addressDto,
        Payment: paymentDto,
        Status: Ordering.Domain.Enums.OrderStatus.Pending,
        OrderItems:
        [
            new OrderItemDto(orderId, new Guid("6EC1297B-EC0A-4AA1-BE25-6726E3B51A27"), 1, 100),
            new OrderItemDto(orderId, new Guid("4F136E9F-FF8C-4C1F-9A33-D12F689BDAB8"), 1, 100),
        ]);

        return new CreateOrderCommand(orderDto);
    }
}
