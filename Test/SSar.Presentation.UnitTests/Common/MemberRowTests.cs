using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.MemberMgmt.Application.Queries;
using Xunit;
using SSar.Presentation.Common;

namespace SSar.Presentation.UnitTests.Common
{
    public class MemberDtoTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var id = Guid.NewGuid();
            var sut = new MemberDto
            {
                MemberId = id,
                FirstName = "Donald",
                MiddleName = "Lucrecius",
                LastName = "Duck",
                Nickname = "Fuzzy"
            };
            sut.ShouldSatisfyAllConditions(
                () => sut.FirstName.ShouldBe("Donald"),
                () => sut.MiddleName.ShouldBe("Lucrecius"),
                () => sut.LastName.ShouldBe("Duck"),
                () => sut.Nickname.ShouldBe("Fuzzy"));
        }
    }
}
