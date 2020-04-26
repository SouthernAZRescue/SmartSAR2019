using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.Presentation.Common
{
    public class MemberRow
    {
        /// <summary>
        /// Parameterless constructor required for deserialization
        /// </summary>
        public MemberRow()
        {
        }

        public MemberRow(string firstName, string middleName, string lastName, string nickname)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
