using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Data;
using Sample.Data.Entities;
using Sample.Orchestrator.Repositories;
using Sample.Orchestrator.Repositories.Interfaces;
using Sample.Orchestrator.Services;
using Sample.Orchestrator.Services.Interfaces;

namespace Sample.Api.Installers
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            // register all orchestrator services
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<IMeasurementService, MeasurementService>();

            // register all model entities repositories
            services.AddScoped<IRepository<Audit>, Repository<Audit>>();
            services.AddScoped<IRepository<Measurement>, Repository<Measurement>>();

            // register data entity context
            services.AddScoped<IDatabaseContext, DatabaseContext>();
        }
    }
}