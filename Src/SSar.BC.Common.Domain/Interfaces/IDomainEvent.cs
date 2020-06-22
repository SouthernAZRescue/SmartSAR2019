using System;

namespace SSar.BC.Common.Domain.Interfaces
{
    interface IDomainEvent
    {
        Guid EventId { get; }
    }
}