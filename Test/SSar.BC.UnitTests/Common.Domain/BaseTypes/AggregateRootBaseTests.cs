using Shouldly;
using SSar.BC.Common.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SSar.BC.UnitTests.Common.Domain.BaseTypes
{
    public class AggregateRootBaseTests
    {
        [Fact]
        public void Ctor_ShouldSetId()
        {
            var aggregate = new ConcreteAggregate();

            aggregate.Id.ShouldNotBe(Guid.Empty);
        }

        private class ConcreteAggregate : AggregateRootBase
        {
        }
    }

}
