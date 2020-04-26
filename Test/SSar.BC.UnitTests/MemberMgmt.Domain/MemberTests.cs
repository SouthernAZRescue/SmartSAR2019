using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Shouldly.Configuration;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Aggregates;
using Xunit;

namespace SSar.BC.UnitTests.MemberMgmt.Domain
{
    public class MemberTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var name = new PersonName("Bill", "Bob", "Stevens", "BillyBob");
            var sut = new Member(name);
            sut.Name.ShouldBe(name);
            sut.Id.ShouldNotBe(Guid.Empty);
        }
    }
}
