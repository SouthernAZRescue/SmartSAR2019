using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SSar.Presentation.BlazorSpaUI.Services;
using Syncfusion.Blazor;
using SSar.Presentation.ApiClient.CSharp;

namespace SSar.Presentation.BlazorSpaUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ModalService>();
            builder.Services.AddApiAuthorization();
            builder.Services.AddCSharpApiClient();

            builder.Services.AddSyncfusionBlazor();

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}
