using System;

namespace SSar.BC.Common.Domain.Interfaces
{
    interface IDomainEvent
    {
        Guid DomainEventId { get; }
        Guid CorrelationId { get; } // Typically the request ID
    }
}