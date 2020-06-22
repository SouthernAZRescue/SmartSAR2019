using System.Collections.Generic;

namespace SSar.BC.UserMgmt.Application.Roles.Queries
{
    public class RolesListVm
    {
        public IEnumerable<RoleLookupDto> Roles { get; set; } 
            = new List<RoleLookupDto>();
    }
}
