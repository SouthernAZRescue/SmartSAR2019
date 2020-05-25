using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SSar.Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: In future, after production is stable,
            // set buffered: true in file writer

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    "Logs/log-host-.txt", 
                    rollingInterval: RollingInterval.Hour,
                    retainedFileCountLimit: 48,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            try
            {
                Log.Information("Starting SmartSAR host from SSar.Presentation.API.Program.Main");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
