using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Api.Installers
{
    public interface IInstaller
    {
        /// <summary>
        /// Install Services based on environment variable
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment);
    }
}