using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.MemberMgmt.Domain.Entities;
using SSar.Infrastructure.Identity;
using SSar.Infrastructure.Persistence.TypeConfigurations;

namespace SSar.Infrastructure.Persistence
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<AppUser, AppRole, int>, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
