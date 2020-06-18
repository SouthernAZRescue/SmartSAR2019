using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.ValueTypes
{
    public class EmailAddress
    {
        public string Address = "";

        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress.Address;
        }
    }
}
