using Shouldly;
using SSar.BC.Common.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SSar.BC.UnitTests.Common.Domain.BaseTypes
{
    public class DomainEventBaseTests
    {
        [Fact]
        public void Ctor_ShouldGenerateDomainEventId()
        {
            var domainEvent = new ConcreteDomainEvent();

            domainEvent.EventId.ShouldNotBe(Guid.Empty);
        }

        private class ConcreteDomainEvent : DomainEventBase
        {
        }
    }
}
