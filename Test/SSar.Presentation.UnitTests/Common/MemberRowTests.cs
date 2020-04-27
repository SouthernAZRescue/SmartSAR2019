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
            var sut = new MemberDto("Donald", "Lucrecius", "Duck", "Fuzzy");
            sut.ShouldSatisfyAllConditions(
                () => sut.FirstName.ShouldBe("Donald"),
                () => sut.MiddleName.ShouldBe("Lucrecius"),
                () => sut.LastName.ShouldBe("Duck"),
                () => sut.Nickname.ShouldBe("Fuzzy"));
        }
    }
}
