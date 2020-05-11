using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.Common.Application.Behaviors;
using FluentValidation;

namespace SSar.BC.Common.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBCCommonApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
