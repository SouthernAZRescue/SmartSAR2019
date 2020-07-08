using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SSar.BC.Common.Application;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.UserMgmt.Application;
using SSar.BC.WebCams.Core;
using SSar.Infrastructure;
using SSar.Presentation.API.Filters;
using SSar.Presentation.API.Middleware;
using SSar.Presentation.API.Services;

namespace SSar.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application,
        // visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // DI and init for this (API) project

            services.AddScoped<ICurrentUserService, CurrentUserService>(); // CONSIDER: Move this to AddInfrastructure
            
            // Add DI and init from individual bounded contexts and other projects

            // TODO: Use options pattern instead of passing in Configuration
            services.AddInfrastructure(Configuration);
            services.AddMemberManagement();
            services.AddUserManagement();
            services.AddWebCams(Configuration);
            services.AddBoundedContextCommonFeatures();

            // API/web host setup

            services.AddControllersWithViews( options =>
                options.Filters.Add(new ApiExceptionFilter()));
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddRazorPages();

            services.AddSwaggerDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "SmartSAR API";
                    document.Info.Description = "Primarily for use by the SmartSAR UI client, but can be used by other authorized apps as desired.";
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();


            app.UseEndpointLogging(LogLevel.Debug);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
