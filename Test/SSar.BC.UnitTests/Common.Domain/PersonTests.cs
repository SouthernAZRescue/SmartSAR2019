using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.Common.Domain.ValueTypes;
using Xunit;

namespace SSar.BC.UnitTests.Common.Domain
{
    public class PersonTests
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            var sut = new PersonName("Bill", "Bob", "Stevens", "BillyBob");
            sut.ShouldSatisfyAllConditions(
                () => sut.First.ShouldBe("Bill"),
                () => sut.Middle.ShouldBe("Bob"),
                () => sut.Last.ShouldBe("Stevens"),
                () => sut.Nickname.ShouldBe("BillyBob"));
            sut.Full.ShouldBe("BillyBob Stevens");
        }

        [Fact]
        public void Full_ShouldReturnNicknameAndLast()
        {
            var sut = new PersonName("Bill", "Bob", "Stevens", "BillyBob");
            sut.Full.ShouldBe("BillyBob Stevens");
        }
    }
}
