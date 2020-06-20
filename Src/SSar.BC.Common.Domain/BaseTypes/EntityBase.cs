using SSar.BC.Common.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.BaseTypes
{
    public abstract class EntityBase : IEntity
    {
        public EntityBase()
        {
           Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
