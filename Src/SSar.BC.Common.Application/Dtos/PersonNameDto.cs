using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Application.Dtos
{
    public class PersonNameDto
    {
        public string First { get; private set; }
        public string Middle { get; private set; }
        public string Last { get; private set; }
        public string Nickname { get; private set; }
    }
}
