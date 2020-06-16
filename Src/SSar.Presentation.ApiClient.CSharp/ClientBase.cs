using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SSar.Presentation.ApiClient.CSharp
{
    public abstract class ClientBase
    {
        public IAccessTokenProvider AccessTokenProvider { get; set; }
        public Func<IAccessTokenProvider, Task<string>> RetrieveAuthorizationToken { get; set; }

        // Called by implementing swagger client classes
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();

            if (RetrieveAuthorizationToken != null)
            {
                string token = await RetrieveAuthorizationToken(AccessTokenProvider);
                msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return msg;
        }
    }
}
