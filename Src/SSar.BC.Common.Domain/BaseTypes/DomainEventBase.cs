using SSar.BC.Common.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.BaseTypes
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            EventId = Guid.NewGuid();
        }

        public Guid EventId { get; protected set; }
    }
}
