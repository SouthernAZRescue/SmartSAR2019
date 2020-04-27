using System;
using SSar.BC.Common.Domain.ValueTypes;

namespace SSar.BC.MemberMgmt.Domain.Entities
{
    public class Member
    {
        private Guid _id;
        private PersonName _name;

        /// <summary>
        /// For Entity Framework
        /// </summary>
        public Member()
        {
        }

        public Member(PersonName name)
        {
            _id = Guid.NewGuid();
            _name = name;
        }

        public Guid Id => _id;
        public PersonName Name => _name;
    }
}
