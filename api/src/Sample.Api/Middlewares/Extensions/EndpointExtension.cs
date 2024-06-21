using Microsoft.AspNetCore.Builder;

namespace Sample.Api.Middlewares.Extensions
{
    /// <summary>
    /// route endpoints middleware extension
    /// </summary>
    public static class EndpointExtension
    {
        public static IApplicationBuilder UseRouteEndpoints(this IApplicationBuilder app) =>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}