using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMemberDetails;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList;
using Xunit;

namespace SSar.Presentation.UnitTests.Common
{
    public class MemberDtoTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var sut = new MemberLookupDto
            {
                EntityId = 353117,
                FirstName = "Donald",
                MiddleName = "Lucrecius",
                LastName = "Duck",
                Nickname = "Fuzzy"
            };
            sut.ShouldSatisfyAllConditions(
                () => sut.EntityId.ShouldBe(353117),
                () => sut.FirstName.ShouldBe("Donald"),
                () => sut.MiddleName.ShouldBe("Lucrecius"),
                () => sut.LastName.ShouldBe("Duck"),
                () => sut.Nickname.ShouldBe("Fuzzy"));
        }
    }
}
