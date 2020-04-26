using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Xunit;
using SSar.Presentation.Common;

namespace SSar.Presentation.UnitTests.Common
{
    public class MemberRowTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var sut = new MemberRow("Donald", "Lucrecius", "Duck", "Fuzzy");
            sut.ShouldSatisfyAllConditions(
                () => sut.FirstName.ShouldBe("Donald"),
                () => sut.MiddleName.ShouldBe("Lucrecius"),
                () => sut.LastName.ShouldBe("Duck"),
                () => sut.Nickname.ShouldBe("Fuzzy"));
        }
    }
}
