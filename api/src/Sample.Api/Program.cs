using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sample.Common.Constants;
using Serilog;

namespace Sample.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            catch (Exception ex)
            {
                if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
                {
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .CreateLogger();
                }

                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .CaptureStartupErrors(true)
                        .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            var envName = hostingContext.HostingEnvironment.EnvironmentName;

                            config
                                .AddJsonFile("appsettings.json", true, true)
                                .AddJsonFile($"appsettings.{envName}.json", true, true);

                            config.AddEnvironmentVariables();

                            if (args != null)
                            {
                                config.AddCommandLine(args);
                            }
                        })
                        .UseSerilog((hostingContext, loggerConfiguration) =>
                        {
                            loggerConfiguration
                                .ReadFrom.Configuration(hostingContext.Configuration)
                                .Enrich.FromLogContext()
                                .Enrich.WithCorrelationIdHeader(InputRequest.CorrelationIdHeaderName)
                                .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment)
                                .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name);
#if DEBUG
                            // Used to filter out potentially bad data due debugging.
                            loggerConfiguration.Enrich.WithProperty("DebuggerAttached", Debugger.IsAttached);
#endif
                        });
                });
    }
}