using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.ValueTypes
{
    public class PhoneNumber
    {
        public string Number = "";

        public static implicit operator string(PhoneNumber phoneNumber)
        {
            return phoneNumber.Number;
        }
    }
}
