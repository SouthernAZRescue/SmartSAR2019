using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.Services;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core
{
    public static class ProjectStartup
    {
        public static IServiceCollection AddWebCams(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IWebCamImageRetrievalService, WebCamImageRetrievalService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IWebCamCatalog>(new WebCamCatalog(
                configuration.GetSection("WebCams:CameraGroups").Get<List<CameraGroup>>(),
                configuration.GetSection("WebCams:Cameras").Get<List<Camera>>()));

            return services;
        }
    }
}
