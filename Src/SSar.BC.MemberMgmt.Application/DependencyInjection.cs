using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SSar.BC.MemberMgmt.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBCMemberMgmtApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
