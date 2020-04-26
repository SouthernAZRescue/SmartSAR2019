using SSar.BC.Common.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.MemberMgmt.Domain.Aggregates
{
    public class Member
    {
        private Guid _id;
        private PersonName _name;

        public Member(PersonName name)
        {
            _id = Guid.NewGuid();
            _name = name;
        }

        public Guid Id => _id;
        public PersonName Name => _name;
    }
}
