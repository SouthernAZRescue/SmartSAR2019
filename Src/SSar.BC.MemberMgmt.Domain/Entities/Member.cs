using System;
using SSar.BC.Common.Domain.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;

namespace SSar.BC.MemberMgmt.Domain.Entities
{
    public class Member : IEntity
    {
        private int _entityId;
        private PersonName _name;

        /// <summary>
        /// For Entity Framework
        /// </summary>
        public Member()
        {
        }

        public Member(PersonName name)
        {
            _name = name;
        }

        public int EntityId => _entityId;
        public PersonName Name => _name;
    }
}
