using Microsoft.AspNetCore.Identity;
using System;
using SSar.BC.Common.Domain.Interfaces;

namespace SSar.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>, IAggregateRoot
    {
        public AppUser()
        {

        }
    }
}
