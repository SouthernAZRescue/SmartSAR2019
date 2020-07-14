using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using SSar.Presentation.ApiClient.CSharp.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SSar.Presentation.ApiClient.CSharp
{
    public static class ProjectStartup
    {
        public static void AddCSharpApiClient(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var navigationManager = serviceProvider.GetService<NavigationManager>();
            var httpClient = serviceProvider.GetService<HttpClient>();
            var accessTokenProvider = serviceProvider.GetService<IAccessTokenProvider>();

            services.AddSingleton<IRolesClient>(
                ClientFactory.CreateRolesClient(
                    navigationManager.BaseUri,
                    httpClient,
                    accessTokenProvider,
                    RetrieveAuthorizationToken));

            services.AddSingleton<IMembersClient>(
                ClientFactory.CreateMembersClient(
                    navigationManager.BaseUri,
                    httpClient,
                    accessTokenProvider,
                    RetrieveAuthorizationToken));

            services.AddSingleton<IWebCamsClient>(
                ClientFactory.CreateWebCamsClient(
                    navigationManager.BaseUri,
                    httpClient,
                    accessTokenProvider,
                    RetrieveAuthorizationToken));
        }

        // TODO: Move this method out of the ApiClient project to allow consumers to
        // specify their own method of token retrieval. OR, add a method to override
        // this method with options in the startup file.
        private static async Task<string> RetrieveAuthorizationToken(IAccessTokenProvider accessTokenProvider)
        {
            var tokenResult = await accessTokenProvider.RequestAccessToken();
            tokenResult.TryGetToken(out var token);

            return token.Value;
        }
    }
}
