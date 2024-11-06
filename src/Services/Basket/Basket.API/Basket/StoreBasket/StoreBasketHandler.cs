

using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;


public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string  UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
public class StoreBasketCommandHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //Add Discount grpc by adding Connected Services, so discount.proto file will be copied and build the project will create
        //DiscountService class locally so we can refere that class for our doscount operation
        //We need to register grpxc client opobject into dependency container in program.cs

        await DeductDiscount(command.Cart, cancellationToken);

        await repository.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(command.Cart.UserName);
    }

    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        //TODO: Communicate with Discount.Grpc and calculate latest prices of products into basket
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
            item.Price -= coupon.Amount;
        }
    }

}
