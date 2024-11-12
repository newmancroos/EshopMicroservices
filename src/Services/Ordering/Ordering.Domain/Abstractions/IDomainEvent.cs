using MediatR;

namespace Ordering.Domain.Abstractions;

internal class IDomainEvent:INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName;
}
