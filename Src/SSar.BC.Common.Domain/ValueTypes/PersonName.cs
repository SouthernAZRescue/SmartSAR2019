using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.ValueTypes
{
    public class PersonName
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Nickname { get; set; }
        public string Full => Nickname + " " + Last;
    }
}
