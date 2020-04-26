using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.MemberMgmt.Application;
using Xunit;

namespace SSar.BC.UnitTests.MemberMgmt.Application
{
    public class GetMemberByIdCommandTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var id = Guid.NewGuid();
            var sut = new GetMemberByIdCommand(id);
            sut.Id.ShouldBe(id);
        }
    }
}
