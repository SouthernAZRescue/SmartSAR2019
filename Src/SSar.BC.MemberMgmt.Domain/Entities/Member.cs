using System;
using SSar.BC.Common.Domain.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;

namespace SSar.BC.MemberMgmt.Domain.Entities
{
    public class Member : IEntity
    {
        public int EntityId { get; set; }
        public PersonName Name { get; set; }
    }
}
