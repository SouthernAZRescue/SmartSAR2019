using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.Services;

namespace SSar.BC.WebCams.Core
{
    public static class ProjectStartup
    {
        public static IServiceCollection AddWebCams(this IServiceCollection services)
        {
            services.AddHttpClient<IWebCamImageRetrievalService, WebCamImageRetrievalService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
