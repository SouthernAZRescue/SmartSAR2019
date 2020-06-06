using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList;
using SSar.Presentation.BlazorSpaUI.Exceptions;
using SSar.Presentation.BlazorSpaUI.Extensions;

namespace SSar.Presentation.BlazorSpaUI.Services
{
    public class ApiClient2
    {
        private HttpClient _httpClient;
        private bool _initialized = false;

        public ApiClient2(NavigationManager navigationManager,
            IAccessTokenProvider authenticationService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
            var task = AddAccessTokenToHeaders(authenticationService, httpClient);

            _initialized = true;
        }
        
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

            if (tokenResult.TryGetToken(out var token))
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Value}");
                }
            }
        }

        private void VerifyInitialized()
        {
            // TODO: See if there is a better way to handle DI into the constructor to avoid
            // requiring this test with every call.

            // Unable to use a factory because the services aren't yet available at start of Program.cs?
            if (!_initialized)
            {
                throw new ApiClientNotInitializedException();
            }
        }

        public async Task<int> CreateAsync(MemberLookupDto memberLookupDto) // TODO: BREAK THIS DEPENDENCY WITH THE APPLICATION LAYER
        {
            VerifyInitialized();

            var httpResponse = await _httpClient.PostAsJsonAsync("Members", memberLookupDto);

            await httpResponse.ThrowIfErrorResponse();

            // Return the new EntityId assigned to the just-saved Member entity
            return await httpResponse.Content.ReadFromJsonAsync<int>();
        }

        public async Task<MembersListVm> GetAllAsync()
        {
            VerifyInitialized();

            return await _httpClient.GetFromJsonAsync<MembersListVm>("Members");
        }

        public async Task UpdateAsync(MemberLookupDto memberLookupDto) // TODO: BREAK THIS DEPENDENCY WITH THE APPLICATION LAYER
        {
            VerifyInitialized();

            var httpResponse = await _httpClient.PutAsJsonAsync($"Members/{memberLookupDto.EntityId}", memberLookupDto);

            await httpResponse.ThrowIfErrorResponse();
        }

        public async Task DeleteAsync(int entityId)
        {
            VerifyInitialized();
            
            var httpResponse = await _httpClient.DeleteAsync($"Members/{entityId}");

            await httpResponse.ThrowIfErrorResponse();
        }


    }
}
