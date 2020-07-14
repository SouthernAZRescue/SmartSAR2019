using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using SSar.Presentation.ApiClient.CSharp.Contracts;

namespace SSar.Presentation.ApiClient.CSharp
{
    public static class ClientFactory
    {
        // TODO: Remove dependency on Microsoft...Authentication
        // Consider my own IAppAccessTokenProvider to inject?

        // CONSIDER: Make this a generic factory, instead of needing to add
        // a separate static method for each API resource type.

        public static IRolesClient CreateRolesClient(
            string baseUrl, 
            HttpClient http, 
            IAccessTokenProvider tokenProvider, 
            Func<IAccessTokenProvider, Task<string>> retrieveAuthorizationToken)
        {
            return new RolesClient(baseUrl, http)
            {
                AccessTokenProvider = tokenProvider,
                RetrieveAuthorizationToken = retrieveAuthorizationToken
            };
        }

        public static IMembersClient CreateMembersClient(
            string baseUrl,
            HttpClient http,
            IAccessTokenProvider tokenProvider,
            Func<IAccessTokenProvider, Task<string>> retrieveAuthorizationToken)
        {
            return new MembersClient(baseUrl, http)
            {
                AccessTokenProvider = tokenProvider,
                RetrieveAuthorizationToken = retrieveAuthorizationToken
            };
        }

        public static IWebCamsClient CreateWebCamsClient(
            string baseUrl,
            HttpClient http,
            IAccessTokenProvider tokenProvider,
            Func<IAccessTokenProvider, Task<string>> retrieveAuthorizationToken)
        {
            return new WebCamsClient(baseUrl, http)
            {
                AccessTokenProvider = tokenProvider,
                RetrieveAuthorizationToken = retrieveAuthorizationToken
            };
        }
    }
}
