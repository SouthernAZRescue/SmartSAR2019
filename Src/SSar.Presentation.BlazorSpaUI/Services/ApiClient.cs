using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using SSar.BC.MemberMgmt.Application;
using SSar.Presentation.BlazorSpaUI.Exceptions;

namespace SSar.Presentation.BlazorSpaUI.Services
{
    public class ApiClient
    {
        private HttpClient _httpClient;
        private bool _initialized = false;
        
        public async Task InitializeAsync(NavigationManager navigationManager, 
            IAccessTokenProvider authenticationService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
            await AddAccessTokenToHeaders(authenticationService, httpClient);

            _initialized = true;
        }

        private async Task AddAccessTokenToHeaders(IAccessTokenProvider authenticationService, HttpClient httpClient)
        {
            var tokenResult = await authenticationService.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token, redirect: true))
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Value}");
                }
            }
        }

        private void VerifyInitialized()
        {
            if (!_initialized)
            {
                throw new ApiClientNotInitializedException();
            }
        }

        public async Task<IEnumerable<MemberDto>> GetAll()
        {
            VerifyInitialized();

            return await _httpClient.GetFromJsonAsync<IEnumerable<MemberDto>>("Members");
        }
    }
}
