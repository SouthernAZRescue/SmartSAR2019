using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using SSar.Presentation.ApiClient.CSharp.Contracts;

namespace SSar.Presentation.ApiClient.CSharp
{
    public static class ClientFactory
    {
        // TODO: Remove dependency on Microsoft...Authentication
        // Consider my own IAppAccessTokenProvider to inject?

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
    }
}
