using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Shouldly.Configuration;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Entities;
using Xunit;

namespace SSar.BC.UnitTests.MemberMgmt.Domain
{
    public class MemberTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var name = new PersonName
            {
                First = "Bill",
                Middle = "Bob",
                Last = "Stevens",
                Nickname = "BillyBob"
            };
            var sut = new Member(){Name = name};
            sut.Name.ShouldBe(name);
            
            // Not yet implemented for this test entity
            //sut.EntityId.ShouldNotBe(default(int));
        }
    }
}
