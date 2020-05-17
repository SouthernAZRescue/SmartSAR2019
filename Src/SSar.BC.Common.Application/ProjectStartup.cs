using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.Common.Application.Behaviors;

namespace SSar.BC.Common.Application
{
    public static class ProjectStartup
    {
        public static IServiceCollection AddBoundedContextCommonFeatures(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}