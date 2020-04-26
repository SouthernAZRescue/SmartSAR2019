using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Aggregates;
using SSar.Infrastructure.Identity;
using System.Linq;

namespace SSar.Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            // MEMBERS
            if (!context.Members.Any())
            {
                context.Members.Add(
                    new Member(
                        new PersonName("John", "Jacob", "Jingleheimer-Schmidt", "JJ")));
            }

            return Task.CompletedTask;
        }
    }
}
