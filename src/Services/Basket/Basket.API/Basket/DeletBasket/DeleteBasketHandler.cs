
namespace Basket.API.Basket.DeletBasket
{
    public record DeleteBasketCommand(string UserName): ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketDeleteValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketDeleteValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName required");
        }
    }

    public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteBasket(command.UserName,cancellationToken);
            return new DeleteBasketResult(true);
        }
    }
}
