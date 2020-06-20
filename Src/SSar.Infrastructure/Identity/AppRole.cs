using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SSar.BC.UserMgmt.Application.Interfaces;

namespace SSar.Infrastructure.Identity
{
    public class AppRole : IdentityRole<Guid>, IAppRole
    {
    }
}
