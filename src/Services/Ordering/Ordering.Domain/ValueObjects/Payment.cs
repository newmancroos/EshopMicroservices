﻿namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string? CardName { get; }= default!;
    public string CardNumner { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;
    public string PaymentMethod { get; } = default!;

    protected Payment() { }

    private Payment(string cardName, string cardNumber, string expiration, string cvv, string paymentMethod)
    {
        CardName = cardName;
        CardNumner = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, string paymentMethod)
    { 
    
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(expiration);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);


        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
    
}