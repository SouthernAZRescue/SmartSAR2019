using Shouldly;
using SSar.BC.Common.Domain.BaseTypes;
using System;
using Xunit;

namespace SSar.BC.UnitTests.Common.Domain.BaseTypes
{
    public class EntityBaseTests
    {
        [Fact]
        public void Ctor_ShouldSetId()
        {
            var entity = new ConcreteEntity();

            entity.Id.ShouldNotBe(Guid.Empty);
        }


        private class ConcreteEntity : EntityBase
        {
            public ConcreteEntity() : base()
            {
            }
        }
    }
}
