using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.UserMgmt.Application.Interfaces;
using SSar.Infrastructure.Identity;
using SSar.Infrastructure.Persistence;

namespace SSar.Infrastructure
{
    public static class ProjectStartup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Persistence

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("SaraSharedSqlDb")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            // Identity

            services.AddDefaultIdentity<AppUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<AppUser, ApplicationDbContext>();

            services.AddScoped<IAppRoleManager>(sp => 
                new AppRoleManager(
                    sp.GetRequiredService<RoleManager<AppRole>>()
            ));

            // Authentication

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
