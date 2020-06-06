using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.UserMgmt.Application.Interfaces;

namespace SSar.Infrastructure.Identity
{
    public class AppRoleManager : IAppRoleManager
    {
        private readonly RoleManager<AppRole> _efRoleManager;

        public AppRoleManager(RoleManager<AppRole> entityFrameworkRoleManager)
        {
            _efRoleManager = entityFrameworkRoleManager ?? throw new ArgumentException(nameof(entityFrameworkRoleManager));
        }

        public IQueryable<IAppRole> Roles => _efRoleManager.Roles;
    }
}
