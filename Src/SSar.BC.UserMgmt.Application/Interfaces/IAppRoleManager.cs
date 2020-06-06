using System.Linq;

namespace SSar.BC.UserMgmt.Application.Interfaces
{
    public interface IAppRoleManager
    {
        IQueryable<IAppRole> Roles { get; }
    }
}
