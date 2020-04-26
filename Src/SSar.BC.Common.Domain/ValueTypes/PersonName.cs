using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.ValueTypes
{
    public class PersonName
    {
        public string First { get; }
        public string Middle { get; }
        public string Last { get; }
        public string Nickname { get; }
        public string Full => Nickname + " " + Last;

        /// <summary>
        /// For Entity Framework
        /// </summary>
        public PersonName()
        {
        }

        public PersonName(string first, string middle, string last, string nickname)
        {
            First = first;
            Middle = middle;
            Last = last;
            Nickname = nickname;
        }
    }
}
