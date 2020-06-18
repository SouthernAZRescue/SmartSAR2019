using Shouldly;
using SSar.BC.Common.Domain.ValueTypes;
using Xunit;

namespace SSar.BC.UnitTests.Common.Domain
{
    public class PhoneNumberTests
    {
        [Fact]
        public void PhoneNumber_ShouldImplicitlyReturnFullNumber()
        {
            var numberString = "111-222-3333";
            var phoneNumber = new PhoneNumber{ Number = numberString };

            ((string)phoneNumber).ShouldBe(numberString);

        }
    }
}
