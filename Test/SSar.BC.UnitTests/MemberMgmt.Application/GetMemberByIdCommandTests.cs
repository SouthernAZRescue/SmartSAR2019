using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMemberDetails;
using Xunit;

namespace SSar.BC.UnitTests.MemberMgmt.Application
{
    public class GetMemberByIdCommandTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var id = 7;
            var sut = new GetMemberDetailQuery(){EntityId = id};
            sut.EntityId.ShouldBe(id);
        }
    }
}
