using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TeamRandomizer
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder();
            await host.Services.GetRequiredService<TestApp>().RunAsync();
            return Environment.ExitCode;
        }

        private static IHost CreateHostBuilder()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<TestApp>();
                })
                .UseSerilog()
                .Build();
            
            return host;
        }
    }
}
