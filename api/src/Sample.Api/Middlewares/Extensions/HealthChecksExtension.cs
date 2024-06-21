using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sample.Api.HealthChecks;

namespace Sample.Api.Middlewares.Extensions
{
    public static class HealthChecksExtension
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();

            return services;
        }

        public static IApplicationBuilder UseCustomHealthChecks(this IApplicationBuilder app) =>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", HealthCheckOption.Create);
            });
    }
}