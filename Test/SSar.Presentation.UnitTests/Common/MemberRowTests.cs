using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.MemberMgmt.Application.Queries;
using Xunit;

namespace SSar.Presentation.UnitTests.Common
{
    public class MemberDtoTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var sut = new MemberDto
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
