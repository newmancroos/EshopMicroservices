using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
using Ordering.Domain.Models;
using Ordering.Domain.Enums;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            orderId => orderId.Value,
            oId => OrderId.Of(oId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany<OrderItem>()
            .WithOne()
            .HasForeignKey(o => o.OrderId);

        builder.ComplexProperty(
            o => o.OrderName, nameBuilder =>
            {
                nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
            });

        builder.ComplexProperty(
        o => o.ShippingAddress, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            nameBuilder.Property(n => n.LastName)
                .HasMaxLength(50)
                .IsRequired();

            nameBuilder.Property(n => n.EmailAddress)
                .HasMaxLength(50);

            nameBuilder.Property(n => n.AddressLine)
                .HasMaxLength(180)
                .IsRequired();

            nameBuilder.Property(n => n.Country)
                .HasMaxLength(50);

            nameBuilder.Property(n => n.State)
                .HasMaxLength(50);

            nameBuilder.Property(n => n.ZipCode)
                .HasMaxLength(5)
                .IsRequired();

        });

        builder.ComplexProperty(
            o => o.BillingAddress, nameBuilder =>
            {
                nameBuilder.Property(n => n.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.EmailAddress)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                nameBuilder.Property(n => n.Country)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.State)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();

            });

        builder.ComplexProperty(
            o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(n => n.CardNumner)
                    .HasMaxLength(50);

                paymentBuilder.Property(n => n.CardNumner)
                    .HasMaxLength(24)
                    .IsRequired(); 

                paymentBuilder.Property(n => n.Expiration)
                    .HasMaxLength(10);

                paymentBuilder.Property(n => n.CVV)
                    .HasMaxLength(3);

                paymentBuilder.Property(n => n.PaymentMethod);
            });

        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(o => o.TotalPrice);
    }
}
