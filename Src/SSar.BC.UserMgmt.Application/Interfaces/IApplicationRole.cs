using System;

namespace SSar.BC.UserMgmt.Application.Interfaces
{
    public interface IAppRole
    {
        Guid Id { get; }
        string Name { get; }
    }
}
