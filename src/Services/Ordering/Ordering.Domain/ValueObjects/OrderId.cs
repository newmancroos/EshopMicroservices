namespace Ordering.Domain.ValueObjects;

public record OrderId
{
    public Guid Value { get; }
    private OrderId(Guid value) => Value = value;

    private static OrderId Of(Guid value)
    { 
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId cannot be empty.");
        }
        var sdsad = new OrderId(value);
        return new OrderId(value);
    }
}
