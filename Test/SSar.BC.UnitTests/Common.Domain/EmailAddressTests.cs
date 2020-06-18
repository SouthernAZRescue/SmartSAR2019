using Shouldly;
using SSar.BC.Common.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SSar.BC.UnitTests.Common.Domain
{
    public class EmailAddressTests
    {
        [Fact]
        public void EmailAddress_ShouldImplicitlyReturnAddressString()
        {
            var addressString = "sleepy@sientrehombres.com";
            var emailAddress = new EmailAddress { Address = addressString };

            ((string)emailAddress).ShouldBe(addressString);
        }
    }
}
