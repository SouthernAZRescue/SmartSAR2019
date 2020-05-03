using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Application.Queries;
using SSar.Presentation.BlazorSpaUI.Exceptions;

namespace SSar.Presentation.BlazorSpaUI.Adapters
{
    public class ApiClient
    {
        private NavigationManager _navigationManager;
        private IAccessTokenProvider _authenticationService;
        private HttpClient _httpClient;
        private bool _initialized = false;

        public ApiClient()
        {
        }

        public ApiClient(NavigationManager navigationManager, 
            IAccessTokenProvider authenticationService, HttpClient httpClient)
        {
            Initialize(navigationManager, authenticationService, httpClient);
        }

        public void Initialize(NavigationManager navigationManager, 
            IAccessTokenProvider authenticationService, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _authenticationService = authenticationService;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_navigationManager.BaseUri);
            _initialized = true;
        }

        public async Task<List<MemberDto>> GetAll()
        {
            VerifyInitialized();

            var tokenResult = await _authenticationService.RequestAccessToken();
            var memberList = new List<MemberDto>();

            if (tokenResult.TryGetToken(out var token, redirect: true))
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Value}");
                }

                memberList = await _httpClient.GetFromJsonAsync<List<MemberDto>>("Members");
            }

            return memberList;
        }

        private void VerifyInitialized()
        {
            if (!_initialized)
            {
                throw new ApiClientNotInitializedException(); 
            }
        }
    }
}
