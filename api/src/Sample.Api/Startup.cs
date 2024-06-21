using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sample.Api.Installers;
using Sample.Api.Middlewares.Extensions;
using Sample.Common.Enums;
using Serilog;
using System.Linq;

namespace Sample.Api
{
    public class Startup
    {
        private ILogger<Startup> _logger;

        private readonly string[] _devEnvironments =
            { EnvironmentNames.LocalDev.ToString(), EnvironmentNames.Development.ToString() };

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddOptions();

            services.AddCustomHealthChecks();

            services.InstallServicesInAssembly(Configuration, CurrentEnvironment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            _logger = logger;

            var envName = CurrentEnvironment.EnvironmentName;
            _logger.LogInformation($"Running app under {envName} environment");

            if (_devEnvironments.Contains(envName))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseUpdateDatabase();

            app.UseSerilogRequestLogging();

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCorsPolicy();

            app.UseSwaggerWithUI();

            app.UseRouteEndpoints();

            app.UseCustomHealthChecks();
        }
    }
}