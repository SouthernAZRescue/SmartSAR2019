using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SSar.Presentation.BlazorSpaUI.Services;
using Syncfusion.Blazor;

namespace SSar.Presentation.BlazorSpaUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ApiClient>();
            builder.Services.AddScoped<ModalService>();
            builder.Services.AddApiAuthorization();

            builder.Services.AddSyncfusionBlazor();
            var host = builder.Build();

            // Setup API Client serviceB
            var apiService = host.Services.GetRequiredService<ApiClient>();
            await apiService.InitializeAsync(
                host.Services.GetService<NavigationManager>(),
                host.Services.GetService<IAccessTokenProvider>(),
                host.Services.GetService<HttpClient>());

            await host.RunAsync();
        }
    }
}
