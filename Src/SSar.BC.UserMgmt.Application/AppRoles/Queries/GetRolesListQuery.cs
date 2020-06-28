using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.UserMgmt.Application.Interfaces;

namespace SSar.BC.UserMgmt.Application.AppRoles.Queries
{
    public class GetRolesListQuery : IRequest<RolesListVm>
    {
        public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, RolesListVm>
        {
            private readonly IAppRoleManager _roleManager;

            public GetRolesListQueryHandler(IAppRoleManager roleManager)
            {
                _roleManager = roleManager;
            }
            public Task<RolesListVm> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(
                        new RolesListVm()
                        {
                            Roles = _roleManager.Roles
                                .Select(r => new RoleLookupDto()
                                {
                                    Id = r.Id,
                                    Name = r.Name
                                })
                                .ToList()
                        }
                    );
            }
        }
    }
}
