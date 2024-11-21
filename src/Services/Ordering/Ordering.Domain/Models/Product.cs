namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; } = default!;

    public static Product Create(ProductId productId, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        return new Product
        {
            Id = productId,
            Name = name,
            Price = price
        };
    }
}
